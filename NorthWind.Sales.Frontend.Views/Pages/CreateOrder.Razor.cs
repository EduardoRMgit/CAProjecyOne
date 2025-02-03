namespace NorthWind.Sales.Frontend.Views.Pages;

public partial class CreateOrder(CreateOrderViewModel viewModel)
{
    ErrorBoundary ErrorBoundaryRef;

    void Recover()
    {
        ErrorBoundaryRef?.Recover();
    }
}
