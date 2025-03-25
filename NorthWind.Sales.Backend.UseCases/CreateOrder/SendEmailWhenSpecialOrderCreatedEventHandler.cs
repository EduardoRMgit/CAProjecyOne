using NorthWind.DomainEvents;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;
using NorthWind.Sales.Backend.UseCases.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    public class SendEmailWhenSpecialOrderCreatedEventHandler(
        IMailService mailService): 
        IDomainEventHandler<SpecialOrderCreatedEvent>
    {
        public Task Handle(SpecialOrderCreatedEvent createOrder)
            =>mailService.SendEmailToAdministrator(CreateOrderMessages.SendEmailSubject,
                string.Format(CreateOrderMessages.SendEmailBodyTemplate,
                    createOrder.OrderId, createOrder.ProductsCount));
    }
}
