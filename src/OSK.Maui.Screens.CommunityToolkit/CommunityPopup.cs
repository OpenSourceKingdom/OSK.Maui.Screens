﻿using CommunityToolkit.Maui.Views;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.CommunityToolkit
{
    public class CommunityPopup : Popup, IScreenPopup
    {
        public required IPopupHandler PopupHandler { set; protected get; }
    }
}
