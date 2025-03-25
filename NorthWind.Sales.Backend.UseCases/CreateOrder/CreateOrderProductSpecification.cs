using NorthWind.DomainValidation.Implementations;
using NorthWind.DomainValidation.ValueObjects;
using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;
using NorthWind.Sales.Backend.UseCases.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder
{
    internal class CreateOrderProductSpecification : DomainSpecificationBase<CreateOrderDto>
    {
        readonly IQueriesRepository Repository;
        public CreateOrderProductSpecification(IQueriesRepository repository) : base(true)
        {
            Repository = repository;

        }

        protected override async Task<List<SpecificationError>> ValidateSpecificationAsync(CreateOrderDto entity)
        {
            List<SpecificationError> Errors = new List<SpecificationError>();

            IEnumerable<ProductUnitsInStock> RequiredQuanties =
                entity.OrderDetailDtos
                .GroupBy(d => d.ProductId)
                .Select(d => new ProductUnitsInStock(
                    d.Key, (short)d.Sum(d => d.Quantity)));

            IEnumerable<int> ProductIds = RequiredQuanties.Select(d => d.ProductID);

            IEnumerable<ProductUnitsInStock> InStockQuantities =
                await Repository.GetProductsUnitsInStock(ProductIds);

            // los left joins, toman los datos de una tabla, y los unen con los datos de otra tabla
            // el join te devuelve aquellos registros en ambas tablas
            // si encuentra el resulatdo es la información la información de la izquierda unida con la derecha, 
            // pero si hay un elemento de la izquierda que no tenga su correspondiente, no aparece.


            // left => todos los que estan en la tabla de la izquierda y la información que puede encontrar en la tabla de la derecha
            // todos los registro de la izquierda, y la información que pueda encontrar en la tabla de la derecha


            // right = todos los de la derecha y los que coincidan con la izquierda.

            // buscala tantas con elementos tengas.

            // si ya encontraste un producto que no existe, debes agregar un error, y tienes que decir, que propiedad es la que no se cumpló, ProductID, o
            // orderdetail.{. quantity

            var result = RequiredQuanties.GroupJoin(
                InStockQuantities,
                // keys
                requiredProduct => requiredProduct.ProductID,
                inStockProduct => inStockProduct.ProductID,
                (requiredProduct, matchingStockProducts) => new
                {
                    RequiredProduct = requiredProduct,
                    MatchingStockProducts = matchingStockProducts
                })
                .SelectMany(
                    x => x.MatchingStockProducts.DefaultIfEmpty(),
                    (x, InStockProduct) => new
                    {
                        RequiredProductId = x.RequiredProduct.ProductID,
                        RequiredProductUnitsInStock = x.RequiredProduct.UnitsInStock,
                        InStockProductProductId = InStockProduct?.ProductID,
                        InStockProductUnitsInStock = InStockProduct?.UnitsInStock ?? 0
                    });

            foreach (var Item in result)
            {

                if (Item.InStockProductProductId == null)
                {
                    string PropertyName = GetPropertyNameWithWindex(entity, Item.RequiredProductId, nameof(CreateOrderDetailDto.ProductId));
                    Errors.Add(new SpecificationError(PropertyName, string.Format(
                        CreateOrderMessages.ProductIdNotFoundErrorTemplate, Item.RequiredProductId)));
                }
                else if (Item.RequiredProductUnitsInStock > Item.InStockProductUnitsInStock)
                {
                    string PropertyName = GetPropertyNameWithWindex(entity, Item.RequiredProductId, nameof(CreateOrderDetailDto.Quantity));
                    Errors.Add(new SpecificationError(PropertyName, string.Format(
                    CreateOrderMessages.UnitsInStockLessThanQuantityErrorTemplate, Item.RequiredProductUnitsInStock,
                        Item.InStockProductUnitsInStock,
                        Item.InStockProductProductId)));
                }

            }




            //foreach (var Item in RequiredQuanties)
            //{ 
            //    // con este lo encontramos
            //    var Found = InStockQuantities.FirstOrDefault(I => I.ProductID == Item.ProductID);

            //    if(Found == null)
            //    {
            //        // NOMBRE DE LA PROPIEDAD CON SU INDICE
            //        string PropertyName = GetPropertyNameWithWindex(entity, Item.ProductID, nameof(CreateOrderDetailDto.ProductId));
            //        Errors.Add(new SpecificationError(PropertyName, string.Format(
            //            CreateOrderMessages.ProductIdNotFoundErrorTemplate, Item.ProductID)));
            //    }
            //    else if(Item.UnitsInStock > Found.UnitsInStock)
            //    {
            //        // NOMBRE DE LA PROPIEDAD CON SU INDICE
            //        string PropertyName = GetPropertyNameWithWindex(entity, Item.ProductID, nameof(CreateOrderDetailDto.Quantity));
            //        Errors.Add(new SpecificationError(PropertyName, string.Format(
            //            CreateOrderMessages.UnitsInStockLessThanQuantityErrorTemplate, Item.UnitsInStock,
            //            Found.UnitsInStock,
            //            Item.ProductID)));
            //    }
            //}

            return Errors;


        }

        string GetPropertyNameWithWindex(CreateOrderDto entity, int productId, string propertyName)
        {
            // ENCONTRAR ELEMENTO CON EL ID DEL ERROR
            var OrderDetail = entity.OrderDetailDtos
                .First(i => i.ProductId == productId);
            // descubrir el elemento que causó el error

            var OrderDetailIndex = entity.OrderDetailDtos.ToList()
                .IndexOf(OrderDetail);

            return string.Format("{0}[{1}].{2}", 
                nameof(entity.OrderDetailDtos),
                OrderDetailIndex, propertyName);
        }

    }
}
