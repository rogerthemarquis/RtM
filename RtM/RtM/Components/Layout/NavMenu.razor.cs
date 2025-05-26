using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RtM.Components.Layout
{
    public partial class NavMenu
    {
        // If the theme is true, dark mode is enabled and the cookie is set to "dark".
        // Otherwise, light mode is enabled and the cookie is set to "light".
        [Parameter]
        public bool theme { get; set; }

        [Parameter]
        public EventCallback ChangeTheme { get; set; }
        private async Task ScrollToTop()
        {
            await JS.InvokeVoidAsync("scrollToSection", "top");
        }

        private async Task ScrollToAbout()
        {
            await JS.InvokeVoidAsync("scrollToSection", "about");
        }

        private async Task ScrollToProfileSkills()
        {
            await JS.InvokeVoidAsync("scrollToSection", "skills");
        }
    }
}