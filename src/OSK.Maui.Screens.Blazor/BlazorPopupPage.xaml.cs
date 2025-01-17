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

    public void SetPopupType(Type popupType)
    {
        blazorWebView.RootComponents.Add(new RootComponent()
        {
            ComponentType = popupType,
            Selector = "#app"
        });

        Content = blazorWebView;
    }

    #endregion
}