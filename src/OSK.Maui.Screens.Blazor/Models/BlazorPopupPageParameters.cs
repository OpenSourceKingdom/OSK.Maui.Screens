using System.Numerics;

namespace OSK.Maui.Screens.Blazor.Models;

public class BlazorPopupPageParameters(Type popupType, Vector2 dimensions, Vector2? translations)
{
    public Type PopupType { get; } = popupType;
    public Vector2 Dimensions { get; } = dimensions;
    public Vector2? Translations { get; } = translations;
}
