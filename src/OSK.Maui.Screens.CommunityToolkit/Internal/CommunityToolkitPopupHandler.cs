using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace OSK.Maui.Screens.CommunityToolkit.Internal
{
    internal class CommunityToolkitPopupHandler(Popup popup, Page parent) : PopupHandler
    {
        public override Task CloseAsync(object? result = null)
        {
            return popup.CloseAsync(result);
        }

        public override Task<object?> WaitForCloseAsync()
        {
            return parent.ShowPopupAsync(popup);
        }
    }
}
