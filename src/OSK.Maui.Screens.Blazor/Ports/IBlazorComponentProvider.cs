using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace OSK.Maui.Screens.Blazor.Ports
{
    public interface IBlazorComponentProvider
    {
        void SetInitializedComponent(ComponentBase component);

        Task<ComponentBase> AwaitComponentInitializationAsync();
    }
}
