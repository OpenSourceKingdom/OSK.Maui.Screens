using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Blazor.Models
{
    public class BlazorPopupNavigation(Type popupType, Page? parentPage = null): PopupNavigation(popupType, parentPage)
    {
        /// <summary>
        /// Sets the width of the blazor popup page. If not set, the default will be half the parent width
        /// 
        /// Note: Values between 0 and 1 will be treated as percentages against the parent width. 
        ///       Values > 1 will be treated as absolute values.
        /// </summary>
        public float? Width { get; set; }

        /// <summary>
        /// Sets the height of the blazor popup page. If not set, the default will be half the parent height
        /// 
        /// Note: Values between 0 and 1 will be treated as percentages against the parent height. 
        ///       Values > 1 will be treated as absolute values.
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// The amount of translation for the popup across the x axis.
        /// 
        /// Note: If the value is less than or equal to 1, it will be treated as a percentage against the parent. 
        /// If it is greater than 1, the value will be treated as an absolute value. 
        /// </summary>
        public float? XTranslation { get; set; }

        /// <summary>
        /// The amount of translation for the popup across the y axis.
        /// 
        /// Note: If the value is less than or equal to 1, it will be treated as a percentage against the parent. 
        /// If it is greater than 1, the value will be treated as an absolute value. 
        /// </summary>
        public float? YTranslation { get; set; }
    }
}
