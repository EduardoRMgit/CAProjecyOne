using NorthWind.DomainValidation.Interfaces;
using NorthWind.DomainValidation.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class SpecialOrderSpecification : ISpecification<OrderAggregate>
{
    public IEnumerable<SpecificationError> Errors => default;

    public bool IsSatisfiedBy(OrderAggregate order) =>
        order.OrderDetails.Count > 3;

}
