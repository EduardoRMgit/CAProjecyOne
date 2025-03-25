using Northwind.Sales.Entities.Dtos.CreateOrder;
using Northwind.Sales.Entities.Resoueces;
using NorthWind.DomainValidation.Implementations;
using NorthWind.DomainValidation.Interfaces;
using NorthWind.DomainValidation.PropertySpecificationTreeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Entities.Specifications
{
    internal class CreateOrderDtoSpecification: DomainSpecificationBase<CreateOrderDto>
    {

        public CreateOrderDtoSpecification(
            IDomainSpecificationValidator<CreateOrderDetailDto> detailValidator)
        {
            Property(c => c.CustomerId)
                .NotEmpty(CreateOrderMessages.CustomerIdRequired)
                .HasFixedLength(5, CreateOrderMessages.CustomerIdRequiredLength);

            Property(c => c.ShipAddress)
                .NotEmpty(CreateOrderMessages.ShipCityRequired)
                .HasMinLength(3, CreateOrderMessages.ShipCityMinimunLength)
                .HasMaxLength(15, CreateOrderMessages.ShipCityMaximumLength);

            Property(c => c.ShipCity)
                .NotEmpty(CreateOrderMessages.ShipCityRequired)
                .HasMinLength(3, CreateOrderMessages.ShipCityMinimunLength)
                .HasMaxLength(15, CreateOrderMessages.ShipCityMaximumLength);

            Property(c => c.ShipCountry)
                .NotEmpty(CreateOrderMessages.ShipCountryRequired)
                .HasMinLength(3, CreateOrderMessages.ShipCountryMinimumLength)
                .HasMaxLength(15, CreateOrderMessages.ShipCountryMaximumLength);

            Property(c => c.ShipPostalCode)
                .HasMaxLength(10, CreateOrderMessages.ShipPostalCodeMaximumLength);

            Property(c => c.OrderDetailDtos)
                .NotEmpty(CreateOrderMessages.OrderDetailsNotEmpty);

            Property(c => c.OrderDetailDtos)
                .SetValidator(detailValidator);
        }
    }
}
