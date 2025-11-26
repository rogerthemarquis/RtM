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
                string? storedTheme = await JSRuntime!.InvokeAsync<string?>("getThemeFromLocalStorage");

                if (string.IsNullOrEmpty(storedTheme))
                {
                    // Use the helper function to check the system preference.
                    theme = await JSRuntime!.InvokeAsync<bool>("getPrefersDarkScheme");
                    // Store the system-preferred theme in localStorage.
                    await JSRuntime!.InvokeVoidAsync("setThemeInLocalStorage", (bool)theme ? "dark" : "light");
                }
                else
                {
                    // Parse the stored theme.
                    theme = storedTheme == "dark";
                }

                // Apply the theme using your JavaScript function.
                await JSRuntime!.InvokeVoidAsync("toggleDarkMode", theme);
                StateHasChanged();
                // Wait for DOM update
                await Task.Yield();
                await JSRuntime!.InvokeVoidAsync("initParticles");
            }
        }

        private async Task ChangeTheme()
        {
            theme = !theme;
            // Store the value as "dark" if true; otherwise "light".
            var themeValue = theme == true ? "dark" : "light";
            await JSRuntime!.InvokeVoidAsync("setThemeInLocalStorage", themeValue);
            await JSRuntime!.InvokeVoidAsync("toggleDarkMode", theme);
            StateHasChanged();
        }

        private async Task ScrollToAbout()
        {
            await JSRuntime!.InvokeVoidAsync("scrollToSection", "about");
        }
    }
}