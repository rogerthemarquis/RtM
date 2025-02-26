using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RtM.Components.Layout
{
    public partial class MainLayout
    {
        private bool? theme;

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                string? storedTheme = await JSRuntime!.InvokeAsync<string?>("getThemeFromCookie");

                if (string.IsNullOrEmpty(storedTheme))
                {
                    // Use the helper function to check the system preference.
                    theme = await JSRuntime!.InvokeAsync<bool>("getPrefersDarkScheme");
                    // Store the system-preferred theme in cookie.
                    await JSRuntime!.InvokeVoidAsync("setThemeInCookie", (bool)theme ? "dark" : "light");
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
            theme = !theme;
            // Store the value as "dark" if true; otherwise "light".
            var themeValue = theme == true ? "dark" : "light";
            await JSRuntime!.InvokeVoidAsync("setThemeInCookie", themeValue);
            await JSRuntime!.InvokeVoidAsync("toggleDarkMode", theme);
            StateHasChanged();
        }
    }
}