using Microsoft.AspNetCore.Components;
using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Blazor.Ports
{
    [HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
    public interface IBlazorComponentProvider
    {
        void Reset();

        void SetInitializedComponent(ComponentBase component);

        Task<ComponentBase> AwaitComponentInitializationAsync();
    }
}
