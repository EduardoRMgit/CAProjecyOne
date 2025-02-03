using Northwind.Sales.Entities.Dtos.CreateOrder;
using Northwind.Sales.Entities.ValueObjects;
using NorthWind.Sales.Frontend.BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Frontend.WebApiGateways
{
    internal class CreateOrderGateway(HttpClient client) : ICreateOrderGateway
    {
        public async Task<int> CreateOrderAsync(CreateOrderDto order)
        {
            int OrderId = 0;

            // voy a enviar una petición post, asincrona, pero trabajando como json, json com web api, en un método http post
            // cualquier metodo personalizado

            // serializa el objeto order a json, y viaja a la red como web api.tiene que tomar como json 
            // serializar
            var Response = await client.PostAsJsonAsync(Endpoints.CreateOrder, order);

            if (Response.IsSuccessStatusCode)
            { 
                // serializar es lacción de tomar algo que tienes en memoria y lo transforma que puedes transportar
                // deserializar
                OrderId = await Response.Content.ReadFromJsonAsync<int>();
            }

            return OrderId;
        }
    }
}
