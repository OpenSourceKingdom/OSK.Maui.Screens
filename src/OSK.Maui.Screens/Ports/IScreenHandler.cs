using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Represents both am <see cref="IPopupProvider"/> and am <see cref="IScreenNavigationHandler"/>. This object performs
/// all screen handling available for a screens
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.IntegrationOptional)]
public interface IScreenHandler: IPopupProvider, IScreenNavigationHandler
{
}
