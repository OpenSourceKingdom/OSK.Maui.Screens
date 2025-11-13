using OSK.Maui.Screens.Blazor.Models;
using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public static class ScreenServiceExtensions
{
    /// <summary>
    /// Performs a custom blazor popup navigation that allows for more control over the popup screen associated with 
    /// the blazor component
    /// </summary>
    /// <typeparam name="TPopup">The blazor component type to show in the popup</typeparam>
    /// <param name="screenService">The screen service performing the action</param>
    /// <param name="width">
    /// The desired popup width. If the value is less than or equal to 1, it will be treated as a percentage against 
    /// the parent. If it is greater than 1, the value will be treated as an absolute value.
    /// </param>
    /// <param name="height">
    /// The desired popup height. If the value is less than or equal to 1, it will be treated as a percentage against
    /// the parent. If it is greater than 1, the value will be treated as an absolute value.
    /// </param>
    /// <param name="xTranslation">
    /// The amount of translation for the popup across the x axis. If the value is less than or equal to 1, it will
    /// be treated as a percentage against the parent. If it is greater than 1, the value will be treated as an absolute value. 
    /// </param>
    /// <param name="yTranslation">
    /// The amount of translation for the popup across the y axis. If the value is less than or equal to 1, it will
    /// be treated as a percentage against the parent. If it is greater than 1, the value will be treated as an absolute value.
    /// </param>
    /// <param name="parent">The parent page for the popup</param>
    /// <param name="cancellationToken">The token to cancel the operation</param>
    /// <returns>The result of the popup, if any is returned</returns>
    public static async Task<object?> ShowBlazorPopupAsync<TPopup>(this IScreenService screenService,
        Page? parent = null, float? width = null, float? height = null, float? xTranslation = null, float? yTranslation = null,
        CancellationToken cancellationToken = default)
        where TPopup : BlazorPopupComponent
    {
        var popupWaiter = await screenService.ShowPopupAsync(
            new BlazorPopupNavigation(typeof(TPopup), parent)
            {
                Width = width,
                Height = height,
                XTranslation = xTranslation,
                YTranslation = yTranslation
            },
            cancellationToken);
        return await popupWaiter.WaitForCloseAsync();
    }

    /// <summary>
    /// Performs a custom blazor popup navigation that allows for more control over the popup screen associated with 
    /// the blazor component
    /// </summary>
    /// <typeparam name="TPopup">The blazor component type to show in the popup</typeparam>
    /// <typeparam name="TParameters">The type of parameters to initialize the popup with</typeparam>
    /// <param name="screenService">The screen service performing the action</param>
    /// <param name="parameters">The parameters to initialize popups with</param>
    /// <param name="width">
    /// The desired popup width. If the value is less than or equal to 1, it will be treated as a percentage against 
    /// the parent. If it is greater than 1, the value will be treated as an absolute value.
    /// </param>
    /// <param name="height">
    /// The desired popup height. If the value is less than or equal to 1, it will be treated as a percentage against
    /// the parent. If it is greater than 1, the value will be treated as an absolute value.
    /// </param>
    /// <param name="xTranslation">The amount of translation for the popup across the x axis</param>
    /// <param name="yTranslation">The amount of translation for the popup across the y axis</param>
    /// <param name="parent">The parent page for the popup</param>
    /// <param name="cancellationToken">The token to cancel the operation</param>
    /// <returns>The result of the popup, if any is returned</returns>
    /// <exception cref="ScreenPopupNavigationException"></exception>
    public static async Task<object?> ShowBlazorPopupAsync<TPopup, TParameters>(this IScreenService screenService, TParameters parameters,
        Page? parent = null, float? width = null, float? height = null, float? xTranslation = null, float? yTranslation = null,
        CancellationToken cancellationToken = default)
        where TPopup : BlazorPopupComponent<TParameters>
    {
        var popupWaiter = await screenService.ShowPopupAsync(
            new BlazorPopupNavigation(typeof(TPopup), parent)
            {
                Width = width,
                Height = height,
                XTranslation = xTranslation,
                YTranslation = yTranslation
            },
            cancellationToken); 
        
        if (popupWaiter.Popup is IScreenPopup<TParameters> typedPopup)
        {
            await typedPopup.InitializePopupAsync(parameters);
            return await popupWaiter.WaitForCloseAsync();
        }

        throw new ScreenPopupNavigationException($"Unable to show popup since the popup was expected to be of type {typeof(IScreenPopup<TParameters>).FullName} but was {popupWaiter.GetType().FullName}.");
    }
}
