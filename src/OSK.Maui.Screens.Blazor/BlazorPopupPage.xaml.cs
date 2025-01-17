using Microsoft.AspNetCore.Components.WebView.Maui;

namespace OSK.Maui.Screens.Blazor;

public partial class BlazorPopupComponentPage : ContentPage
{
    #region Constructors

    public BlazorPopupComponentPage()
    {
        InitializeComponent();

        WidthRequest = Application.Current!.MainPage!.Width / 2;
        HeightRequest = Application.Current.MainPage.Height / 2;
        TranslationX += Application.Current.MainPage.Width * .1;
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