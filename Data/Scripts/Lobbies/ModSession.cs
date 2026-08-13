// ModAPI session entry + Rich Hud lobby overlay.
// SELib: docs/cheatsheets/session.md · docs/recipes/minimal-mod.md
// Rich Hud: see RICHHUD.md
using System;
using Lobbies.UI;
using RichHudFramework.Client;
using RichHudFramework.UI;
using RichHudFramework.UI.Client;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components; // Whitelisted internal: MySessionComponentBase
using VRage.Input;

namespace Lobbies
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public sealed class ModSession : MySessionComponentBase
    {
        private LobbyScreen _lobby;

        public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Utilities != null && MyAPIGateway.Utilities.IsDedicated)
                return;

            RichHudClient.Init("Lobbies", HudInit, ClientReset);
        }

        public override void BeforeStart()
        {
            var utilities = MyAPIGateway.Utilities;
            if (utilities == null || utilities.IsDedicated)
                return;

            utilities.ShowMessage("Lobbies", "Session loaded. Press Shift+F3 to toggle the lobby (rebindable).");
        }

        private void HudInit()
        {
            var bindInit = new BindGroupInitializer
            {
                { "ToggleLobby", MyKeys.Shift, MyKeys.F3 },
            };

            var binds = BindManager.GetOrCreateGroup("Lobbies");
            binds.RegisterBinds(bindInit);
            binds["ToggleLobby"].NewPressed += OnToggleLobby;

            RichHudTerminal.Root.Name = "Lobbies";
            RichHudTerminal.Root.Add(new RebindPage
            {
                Name = "Binds",
                Enabled = true,
                GroupContainer =
                {
                    { binds, bindInit.GetBindDefinitions(), true },
                },
            });
            RichHudTerminal.Root.Enabled = true;

            _lobby = new LobbyScreen(HudMain.HighDpiRoot);

            MyAPIGateway.Utilities?.ShowMessage("Lobbies", "Rich Hud registered. Shift+F3 toggles the lobby; F2 opens Terminal binds.");
        }

        private void OnToggleLobby(object sender, EventArgs args)
        {
            _lobby?.Toggle();
        }

        private void ClientReset()
        {
            if (_lobby != null)
            {
                _lobby.Close();
                _lobby = null;
            }
        }
    }
}
