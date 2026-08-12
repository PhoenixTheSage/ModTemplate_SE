// ModAPI session entry + Rich Hud Hello World.
// SELib: docs/cheatsheets/session.md · docs/recipes/minimal-mod.md
// Rich Hud: see RICHHUD.md (drop Client into RichHudFramework/ before loading)
using Sandbox.ModAPI;
using RichHudFramework.Client;
using RichHudFramework.UI;
using RichHudFramework.UI.Client;
using VRage.Game.Components; // Whitelisted internal: MySessionComponentBase
using VRage.Game;

[MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
public sealed class ModSession : MySessionComponentBase
{
    private Label _hello;

    public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
    {
        RichHudClient.Init(DebugName, HudInit, ClientReset);
    }

    public override void BeforeStart()
    {
        var utilities = MyAPIGateway.Utilities;
        if (utilities == null)
            return;

        utilities.ShowMessage("ModTemplate", "Session loaded. Waiting for Rich Hud…");
    }

    private void HudInit()
    {
        _hello = new Label(HudMain.HighDpiRoot)
        {
            Text = "Hello World",
        };
    }

    private void ClientReset()
    {
        _hello = null;
    }

    protected override void UnloadData()
    {
        _hello = null;
    }
}
