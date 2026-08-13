using System.Collections.Generic;
using RichHudFramework.UI;
using Sandbox.ModAPI;
using VRage.Game.ModAPI;
using VRageMath;

namespace Lobbies.UI
{
    /// <summary>
    /// Right-hand lobby column: live roster of human players on this session.
    /// </summary>
    public sealed class PlayerListPanel : HudElementBase
    {
        private const int RefreshIntervalFrames = 45;

        private readonly Label _header;
        private readonly ListBox<ulong> _roster;
        private readonly List<IMyPlayer> _players = new List<IMyPlayer>();
        private int _framesUntilRefresh;

        public PlayerListPanel() : base(null)
        {
            new TexturedBox(this)
            {
                DimAlignment = DimAlignments.Size,
                Color = LobbyPalette.Panel,
            };

            new BorderBox(this)
            {
                DimAlignment = DimAlignments.Size,
                Color = LobbyPalette.Border,
                Thickness = 2f,
            };

            var stack = new HudChain(true, this)
            {
                DimAlignment = DimAlignments.UnpaddedSize,
                Padding = new Vector2(20f, 20f),
                Spacing = 10f,
                SizingMode = HudChainSizingModes.FitMembersOffAxis,
            };

            _header = new Label
            {
                AutoResize = true,
                Format = LobbyPalette.Header,
                Text = "PLAYERS",
            };

            _roster = new ListBox<ulong>
            {
                Color = LobbyPalette.ListBg,
                Format = LobbyPalette.Body,
                HighlightColor = LobbyPalette.ButtonHighlight,
            };

            stack.Add(_header);
            stack.Add(_roster, 1f);
        }

        public void Refresh()
        {
            _framesUntilRefresh = RefreshIntervalFrames;
            _players.Clear();

            var players = MyAPIGateway.Players;
            if (players != null)
                players.GetPlayers(_players, IsHumanPlayer);

            _header.Text = "PLAYERS (" + _players.Count + ")";
            _roster.ClearEntries();

            for (int i = 0; i < _players.Count; i++)
            {
                IMyPlayer player = _players[i];
                string name = player.DisplayName;
                if (string.IsNullOrEmpty(name))
                    name = "Player";

                _roster.Add(name, player.SteamUserId);
            }
        }

        protected override void HandleInput(Vector2 cursorPos)
        {
            _framesUntilRefresh--;
            if (_framesUntilRefresh <= 0)
                Refresh();
        }

        private static bool IsHumanPlayer(IMyPlayer player)
        {
            return player != null && !player.IsBot;
        }
    }
}
