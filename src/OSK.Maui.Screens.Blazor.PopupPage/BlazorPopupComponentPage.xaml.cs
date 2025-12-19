using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Options;
using OSK.Maui.Screens.Blazor.Models;
using OSK.Maui.Screens.Blazor.PopupPage.Options;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.PopupPage;

public partial class BlazorWebViewPopupComponentPage : ContentPage, IBlazorPopupComponentPage
{
    #region Variables

    private readonly IOptions<BlazorPopupPageOptions> _options;

    #endregion

    #region Constructors

    public BlazorWebViewPopupComponentPage(IOptions<BlazorPopupPageOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;

        InitializeComponent();
    }

    #endregion

    #region IBlazorPopupComponentPage

    public Page SetPopup(BlazorPopupPageParameters parameters)
    {
        WidthRequest = parameters.Dimensions.X;
        HeightRequest = parameters.Dimensions.Y;
        TranslationX += parameters.Translations?.X ?? 0;
        TranslationY += parameters.Translations?.Y ?? 0;

        blazorWebView.HostPage = _options.Value.HostPage;
        blazorWebView.RootComponents.Add(new RootComponent()
        {
            ComponentType = parameters.PopupType,
            Selector = "#app"
        });

        Content = blazorWebView;

        return this;
    }

    #endregion
}