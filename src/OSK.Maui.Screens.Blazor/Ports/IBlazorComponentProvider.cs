using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Blazor.Ports;

[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
public interface IBlazorComponentProvider
{
    void Reset();

    void SetInitializedComponent(BlazorComponent component);

    Task<BlazorComponent> AwaitComponentInitializationAsync();
}
