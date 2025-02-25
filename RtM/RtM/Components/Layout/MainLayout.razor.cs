using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RtM.Components.Layout
{
    public partial class MainLayout
    {
        private bool? theme;

        [Inject]
        private ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && LocalStorage != null)
            {
                string? storedTheme = await LocalStorage.GetItemAsStringAsync("theme");

                if (string.IsNullOrEmpty(storedTheme))
                {
                    // Use the helper function to check the system preference.
                    bool prefersDarkScheme = await JSRuntime!.InvokeAsync<bool>("getMediaQueryMatches", "(prefers-color-scheme: dark)");
                    theme = prefersDarkScheme;
                    // Store the system-preferred theme in local storage.
                    await LocalStorage.SetItemAsStringAsync("theme", prefersDarkScheme ? "dark" : "light");
                }
                else
                {
                    // Parse the stored theme.
                    theme = storedTheme == "dark";
                }

                // Apply the theme using your JavaScript function.
                await JSRuntime!.InvokeVoidAsync("toggleDarkMode", theme);
                StateHasChanged();
            }
        }
        private async Task ChangeTheme()
        {
            if (LocalStorage != null)
            {
                theme = !theme;
                // Store the value as "dark" if true; otherwise "light".
                var themeValue = theme == true ? "dark" : "light";
                await LocalStorage.SetItemAsStringAsync("theme", themeValue);
                await JSRuntime!.InvokeVoidAsync("toggleDarkMode", theme);
                StateHasChanged();
            }
        }
    }
}
