using NorthWind.DomainValidation.Implementations;
using NorthWind.DomainValidation.Interfaces;
using NorthWind.DomainValidation.ValueObjects;
using NorthWind.Sales.Backend.UseCases.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    internal class CreateOrderCustomerSpecifications : DomainSpecificationBase<CreateOrderDto>
    {
        readonly IQueriesRepository Repository;

        public CreateOrderCustomerSpecifications(
            IQueriesRepository repository) : base(true)
        {
            Repository = repository;
        }

        protected override async Task<List<SpecificationError>> ValidateSpecificationAsync(CreateOrderDto entity)
        {
            List<SpecificationError> Errors = new List<SpecificationError>();

            var CurrentBalance = await Repository.GetCustomerCurrentBalance(
                entity.CustomerId);

            if (CurrentBalance == null)
            {
                Errors.Add(new SpecificationError(
                    nameof(entity.CustomerId),
                    CreateOrderMessages.CustomerIdNotFoundError));
            }
            else if (CurrentBalance > 0)
            {
                Errors.Add(new SpecificationError(
                    nameof(entity.CustomerId), string.Format(
                        CreateOrderMessages.CustomerWithBalanceError,
                         entity.CustomerId, CurrentBalance)));
            }

            return Errors;
        }
    }
}
