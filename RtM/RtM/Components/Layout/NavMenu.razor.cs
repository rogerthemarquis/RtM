using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RtM.Components.Layout
{
    public partial class NavMenu
    {
        [Parameter]
        public bool? Theme { get; set; }

        [Parameter]
        public EventCallback ChangeTheme { get; set; }
    }
}