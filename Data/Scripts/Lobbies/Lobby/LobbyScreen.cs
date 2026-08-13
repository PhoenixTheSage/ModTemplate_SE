using RichHudFramework.UI;
using RichHudFramework.UI.Client;
using VRageMath;

namespace Lobbies.UI
{
    /// <summary>
    /// Full-screen lobby overlay. Hidden until toggled; does not open on session start.
    /// Vanilla HUD hide is not available: <c>MyHud.IsVisible</c> / <c>SetHudState</c> are not on
    /// AllowMembers (SELib: docs/types/MyHud.md). The overlay covers the screen instead.
    /// </summary>
    public sealed class LobbyScreen : HudElementBase
    {
        private readonly PlayerListPanel _players;
        private bool _open;
        private bool _wasCursorEnabled;
        private SeBlacklistModes _wasBlacklist;

        public bool IsOpen => _open;

        public LobbyScreen(HudParentBase parent) : base(parent)
        {
            Visible = false;
            UseCursor = true;
            ShareCursor = false;
            ZOffset = 16;
            Size = HudMain.ScreenDimHighDPI;

            new TexturedBox(this)
            {
                DimAlignment = DimAlignments.Size,
                Color = LobbyPalette.Backdrop,
            };

            var columns = new HudChain(false, this)
            {
                DimAlignment = DimAlignments.UnpaddedSize,
                Padding = new Vector2(36f, 36f),
                Spacing = 24f,
                SizingMode = HudChainSizingModes.FitMembersOffAxis,
            };

            var setup = new GameSetupPanel();
            _players = new PlayerListPanel();

            columns.Add(setup, 1.7f);
            columns.Add(_players, 1f);
        }

        public void Toggle()
        {
            if (_open)
                Close();
            else
                Open();
        }

        public void Open()
        {
            if (_open)
                return;

            _wasCursorEnabled = HudMain.EnableCursor;
            _wasBlacklist = BindManager.BlacklistMode;

            Size = HudMain.ScreenDimHighDPI;
            Visible = true;
            HudMain.EnableCursor = true;
            BindManager.BlacklistMode = SeBlacklistModes.Full;

            _players.Refresh();
            _open = true;
        }

        public void Close()
        {
            if (!_open)
                return;

            Visible = false;
            HudMain.EnableCursor = _wasCursorEnabled;
            BindManager.BlacklistMode = _wasBlacklist;
            _open = false;
        }

        protected override void Layout()
        {
            Size = HudMain.ScreenDimHighDPI;
        }
    }
}
