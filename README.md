# OSK.Maui.Screens
Screens is the core library that handles screen routing, registration, and other related management responsibilities. To add
the core services to the dependency container, consumers can use either the `MauiAppBuilderExtensions.AddScreenNavigation`
or the `ServiceCollectionExtensions.AddScreenNavigation`. The main goal is to provide a common set of logic that can be used
to interact with popups and screens of different types with a single source vs. needing to access them directly.

It is important that any page, popup, or other screen wanting to be navigated to has been registered with the internal library
using one of the `AddScreen` or `AddPopupHandler` methods in the `ServiceCollectionExtensions`. These extensions will require that
consuming libraries have inherited `IScreen` or `IScreenPopup` respectively, when the methods are called.
The library will throw errors in the event this is not the case. Most integrations will provide a base class to extend for popup related usage.

# OSK.Maui.Screens.Blazor
This adds an integration for screen and popup related management using blazor components that are used with Maui Blazor Hybrid applications.
Consumers should add the blazor handlers using the `AddBlazorScreens` extensions in the MauiAppBuilderExtensions/ServiceCollectionExtensions.

Additionally, to utilize the blazor specific handling, consumers will want to mark their components with `BlazorComponent` for normal screens
or `BlazorComponentPopup` for popups.

When displaying a popup for blazor, users can adjust the width/height and x/y translations using the `ShowBlazorPopupAsync` extension, if the default
popup navigation is insufficient

# OSK.Maui.Screens.CommunityToolkit
This adds an integration for popups using the community toolkit popups. Consumers should add the community toolkit handler using `AddCommunityScreens`
in the MauiAppBuilderExtensions
See https://github.com/CommunityToolkit/Maui for more information.

# OSK.Maui.Screens.Mopups
This adds an integration for popups using the Mopups library. Consumers should add the mopups handler using the `AddMopupsScreens` in the
MauiAppBuilderExtensions
See https://github.com/LuckyDucko/Mopups for more information.

# Contributions and Issues
Any and all contributions are appreciated! Please be sure to follow the branch naming convention OSK-{issue number}-{deliminated}-{branch}-{name} as current workflows rely on it for automatic issue closure. Please submit issues for discussion and tracking using the github issue tracker.