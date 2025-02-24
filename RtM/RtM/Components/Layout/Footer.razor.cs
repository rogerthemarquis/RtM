using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RtM.Components.Layout
{
    public partial class Footer
    {
        private bool toggleDark = false;

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
                    // Check the system preference
                    var mediaQueryList = await JSRuntime!.InvokeAsync<IJSObjectReference>("window.matchMedia", "(prefers-color-scheme: dark)").AsTask();
                    bool prefersDarkScheme = await mediaQueryList.InvokeAsync<bool>("matches");
                    toggleDark = prefersDarkScheme;
                    await LocalStorage.SetItemAsStringAsync("theme", toggleDark ? "dark" : "light");
                }
                else
                {
                    toggleDark = storedTheme == "dark";
                }
                StateHasChanged();
            }
        }

        private async Task ChangeTheme()
        {
            if (LocalStorage != null)
            {
                toggleDark = !toggleDark;
                await LocalStorage.SetItemAsStringAsync("theme", toggleDark ? "dark" : "light");
                await JSRuntime!.InvokeVoidAsync("toggleDarkMode", toggleDark);
                StateHasChanged();
            }
        }
    }
}