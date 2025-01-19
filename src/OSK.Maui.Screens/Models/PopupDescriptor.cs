using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Maui.Screens.Models
{
    public class PopupDescriptor(Type popupType, Type popupProviderType)
    {
        public Type PopupType => popupType;

        public Type PopupProviderType => popupProviderType;
    }
}
