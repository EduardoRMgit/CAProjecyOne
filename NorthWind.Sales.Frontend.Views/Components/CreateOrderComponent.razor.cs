namespace NorthWind.Sales.Frontend.Views.Components;

public partial class CreateOrderComponent
{
    // capturar los datos de una orden
    [Parameter]
    public CreateOrderViewModel Order { get; set; }

}
