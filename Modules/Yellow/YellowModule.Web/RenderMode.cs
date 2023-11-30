using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace YellowModule.Web;

public sealed class RenderModeInteractiveServer : RenderModeAttribute
{
    public override IComponentRenderMode Mode
        => RenderMode.InteractiveServer;
}

public sealed class RenderModeInteractiveAuto : RenderModeAttribute
{
    public override IComponentRenderMode Mode
        => RenderMode.InteractiveAuto;
}

public sealed class RenderModeInteractiveWebAssembly : RenderModeAttribute
{
    public override IComponentRenderMode Mode
        => RenderMode.InteractiveWebAssembly;
}
