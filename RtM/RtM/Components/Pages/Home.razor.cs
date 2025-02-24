using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace RtM.Components.Pages
{
    public partial class Home
    {
        private bool toggleDark = false;

        [Inject]
        private ILocalStorageService? LocalStorage { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && LocalStorage != null)
            {
                // Try reading the theme from LocalStorage first
                string? storedTheme = await LocalStorage.GetItemAsStringAsync("theme");
                if (string.IsNullOrEmpty(storedTheme))
                {
                    // If no theme is stored, then default to dark and store it.
                    storedTheme = "dark";
                    await LocalStorage.SetItemAsStringAsync("theme", storedTheme);
                }

                toggleDark = storedTheme == "dark";
                StateHasChanged();
            }
        }
    }
}

