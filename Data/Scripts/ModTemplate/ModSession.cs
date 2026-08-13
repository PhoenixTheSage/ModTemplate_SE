// ModAPI session entry + Rich Hud Terminal category.
// SELib: docs/cheatsheets/session.md · docs/recipes/minimal-mod.md
// Rich Hud: see RICHHUD.md (drop Client into RichHudFramework/ before loading)
using Sandbox.ModAPI;
using RichHudFramework.Client;
using RichHudFramework.UI;
using RichHudFramework.UI.Client;
using VRage.Game.Components; // Whitelisted internal: MySessionComponentBase
using VRage.Game;

namespace ModTemplate_SE.Data.Scripts.ModTemplate
{
    // Game constructs this via MySessionComponentDescriptor (reflection).
    // ReSharper disable once UnusedType.Global
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public sealed class ModSession : MySessionComponentBase
    {
        public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
        {
            RichHudClient.Init("Template", HudInit, ClientReset);
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
            RichHudTerminal.Root.Enabled = true;
            RichHudTerminal.Root.Add(new TextPage
            {
                Name = "Hello World",
                HeaderText = "Hello World",
                Text = "Hello World",
                Enabled = true,
            });

            var binds = BindManager.GetOrCreateGroup("main");
            binds.RegisterBinds(new BindGroupInitializer
            {
                { "Template" },
            });

            RichHudTerminal.Root.Add(new RebindPage
            {
                Name = "Binds",
                Enabled = true,
                GroupContainer =
                {
                    { binds, true },
                },
            });

            var utilities = MyAPIGateway.Utilities;
            utilities?.ShowMessage("ModTemplate", "Rich Hud registered. Open the Terminal and select Template.");
        }

        private void ClientReset()
        {
        }
    }
}
