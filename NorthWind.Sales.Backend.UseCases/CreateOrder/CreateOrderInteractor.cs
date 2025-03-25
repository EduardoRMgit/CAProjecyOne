

using NorthWind.DomainEvents;
using NorthWind.DomainLogs.Abstractions.Interfaces;
using NorthWind.DomainLogs.Abstractions.ValueObjects;
using NorthWind.DomainTransactions;
using NorthWind.DomainValidation.Interfaces;
using NorthWind.DomainValidation.Wards;
using NorthWind.Sales.Backend.UseCases.Resources;
using NorthWind.UserServices.Abstractions.Guards;
using NorthWind.UserServices.Abstractions.Interfaces;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    // Qué necesita?
    internal class CreateOrderInteractor(
        ICreateOrderOutputPort outputPort,
        ICreateOrderRepository repository,
        IDomainSpecificationValidator<CreateOrderDto> validator,
        IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
        IDomainLogger domainLogger,
        IUserService userService) : ICreateOrderInputPort
    {
        public async Task Handle(CreateOrderDto order)
        {
            GuardUser.AgainstUnathorized(userService);

            // Result => True
            // Result => IEnumerable<SpecificationError>
            // validator.ValidateAsync(order)
            // Result R = validator.ValidateAsync(order)
            // Result.HandleResult();

            await Guard.AgainstInvalidSpecification(validator, order,
                CreateOrderMessages.ValidationExceptionMessage);

            domainLogger.Log(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation, userService.UserName));

            // tomar el dto y volverlo un agregado.
            OrderAggregate Order = OrderAggregate.From(order);

            await using (var Scope = new DomainTransactionScope())
            {
                try
                {
                    // si mas repos tenemos, le agregas los repositoios, 
                    await Scope.EnlistAsync(repository);
                    await repository.CreateOrderAsync(Order);
                    await repository.SaveChangesAsync();

                    if (new SpecialOrderSpecification().IsSatisfiedBy(Order))
                    {
                        await domainEventHub.Raise(new SpecialOrderCreatedEvent(
                            Order.Id, Order.OrderDetails.Count));
                    }

                    // Completamos // commit
                    Scope.Complete();

                    domainLogger.Log(new DomainLog(string.Format(
                    CreateOrderMessages.PurchaseOrderCreatedTemplate, Order.Id), userService.UserName));

                    await domainLogger.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    string ErrorMessage = Order.Id == 0 
                        ? string.Format(CreateOrderMessages.OrderCreationErrorTemplate, ex)
                        : string.Format(CreateOrderMessages.OrderCreationCancelledTemplate, Order.Id, ex);

                    domainLogger.Log(new DomainLog(ErrorMessage, userService.UserName));
                    await domainLogger.SaveChangesAsync();
                    throw;
                }
            }
            await outputPort.Handle(Order);
        }
    }
}
