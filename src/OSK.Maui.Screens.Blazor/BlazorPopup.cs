using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public abstract class BlazorPopup : ComponentBase
    {
        #region Variables

        [Inject]
        public required IBlazorComponentProvider ComponentProvider { get; set; }


        #endregion

        #region Helpers

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ComponentProvider.SetInitializedComponent(this);
        }

        #endregion
    }
}
