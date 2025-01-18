using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Maui.Screens.Exceptions
{
    public class ScreenPopupNavigationException(string message): ScreenNavigationException(message)
    {
    }
}
