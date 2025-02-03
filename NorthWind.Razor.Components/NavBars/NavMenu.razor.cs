﻿namespace NorthWind.Razor.Components.NavBars;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment NavBarBrand { get; set; }

    [Parameter]
    public RenderFragment NavBarItems { get; set; }

    bool CollapseNavMenu = true;

    string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    void ToggleNavMenu()
    {
        CollapseNavMenu = !CollapseNavMenu;
    }
}