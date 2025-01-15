using Microsoft.AspNetCore.Components.WebView.Maui;

namespace OSK.Maui.Screens.Blazor;

public partial class BlazorPopupPage : ContentPage
{
    #region Constructors

    public BlazorPopupPage()
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