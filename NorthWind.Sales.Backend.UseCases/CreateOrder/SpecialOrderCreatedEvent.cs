﻿using NorthWind.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    public class SpecialOrderCreatedEvent(int orderId, int productsCount): IDomainEvent
    {
        public int OrderId => orderId;
        public int ProductsCount => productsCount;

        // un evento es una simple estructura de datos que guarda información respecto del evento
    }
}
