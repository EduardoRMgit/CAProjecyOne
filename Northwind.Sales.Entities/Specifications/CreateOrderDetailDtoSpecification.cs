using Northwind.Sales.Entities.Dtos.CreateOrder;
using Northwind.Sales.Entities.Resoueces;
using NorthWind.DomainValidation.Implementations;
using NorthWind.DomainValidation.PropertySpecificationTreeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Sales.Entities.Specifications
{
    internal class CreateOrderDetailDtoSpecification: DomainSpecificationBase<CreateOrderDetailDto>
    {
        public CreateOrderDetailDtoSpecification()
        {
            Property(d => d.ProductId)
                .GreaterThan(0, CreateOrderMessages.ProductIdGreaterThanZero);

            Property(d => d.Quantity)
                .GreaterThan((short)0, CreateOrderMessages.QuantityGreaterThanZero);

            Property(d => d.UnitPrice)
                .GreaterThan(0, CreateOrderMessages.UnitPriceGreaterThanZero);
        }


    }
}
