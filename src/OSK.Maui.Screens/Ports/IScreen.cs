using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Represents a main screen presented to a user. This should be inherited by any screen being displayed to a user, if the
/// screen service is being used for navigation
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.ConsumerOptional)]
public interface IScreen
{
}
