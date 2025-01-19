using System.Numerics;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace OSK.Maui.Screens.Blazor;

public partial class BlazorPopupComponentPage : ContentPage
{
    #region Constructors

    public BlazorPopupComponentPage()
    {
        InitializeComponent();
    }

    #endregion

    #region Helpers

    public void SetPopup(Type popupType, Vector2 dimensions, Vector2? translations)
    {
        WidthRequest = dimensions.X;
        HeightRequest = dimensions.Y;
        TranslationX += translations?.X ?? 0;
        TranslationY += translations?.Y ?? 0;

        blazorWebView.RootComponents.Add(new RootComponent()
        {
            ComponentType = popupType,
            Selector = "#app"
        });

        Content = blazorWebView;
    }

    #endregion
}