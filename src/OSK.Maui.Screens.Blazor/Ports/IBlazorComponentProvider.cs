﻿using Microsoft.AspNetCore.Components;

namespace OSK.Maui.Screens.Blazor.Ports
{
    public interface IBlazorComponentProvider
    {
        void SetInitializedComponent(ComponentBase component);

        Task<ComponentBase> AwaitComponentInitializationAsync();
    }
}
