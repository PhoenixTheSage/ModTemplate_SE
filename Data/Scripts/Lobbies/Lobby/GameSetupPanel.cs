using System;
using RichHudFramework.UI;
using VRageMath;

namespace Lobbies.UI
{
    /// <summary>
    /// Left-hand lobby column: placeholder gametype, map, and vote/ready controls.
    /// </summary>
    public sealed class GameSetupPanel : HudElementBase
    {
        private readonly ListBox<string> _gametypes;
        private readonly ListBox<string> _maps;
        private readonly Label _status;

        public GameSetupPanel() : base(null)
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

            var header = new Label
            {
                AutoResize = true,
                Format = LobbyPalette.Header,
                Text = "GAME SETUP",
            };

            var gametypeLabel = new Label
            {
                AutoResize = true,
                Format = LobbyPalette.Subheader,
                Text = "GAMETYPE",
            };

            _gametypes = CreateList();
            _gametypes.Add("Slayer", "Slayer");
            _gametypes.Add("Capture the Flag", "Capture the Flag");
            _gametypes.Add("Oddball", "Oddball");
            _gametypes.Add("King", "King");
            _gametypes.SetSelectionAt(0);
            _gametypes.ValueChanged += OnSelectionChanged;

            var mapLabel = new Label
            {
                AutoResize = true,
                Format = LobbyPalette.Subheader,
                Text = "MAP",
            };

            _maps = CreateList();
            _maps.Add("Construct", "Construct");
            _maps.Add("Guardian", "Guardian");
            _maps.Add("The Pit", "The Pit");
            _maps.SetSelectionAt(0);
            _maps.ValueChanged += OnSelectionChanged;

            var actions = new HudChain(false)
            {
                Height = 44f,
                Spacing = 12f,
                SizingMode = HudChainSizingModes.FitMembersOffAxis,
            };

            var vote = CreateButton("VOTE");
            vote.MouseInput.LeftClicked += OnVoteClicked;

            var ready = CreateButton("READY");
            ready.MouseInput.LeftClicked += OnReadyClicked;

            actions.Add(vote);
            actions.Add(ready);

            _status = new Label
            {
                AutoResize = true,
                Format = LobbyPalette.Status,
                Text = "Placeholder: pick a gametype and map, then Vote / Ready.",
            };

            stack.Add(header);
            stack.Add(gametypeLabel);
            stack.Add(_gametypes, 1f);
            stack.Add(mapLabel);
            stack.Add(_maps, 1f);
            stack.Add(actions);
            stack.Add(_status);
        }

        private static ListBox<string> CreateList()
        {
            return new ListBox<string>
            {
                Color = LobbyPalette.ListBg,
                Format = LobbyPalette.Body,
                HighlightColor = LobbyPalette.ButtonHighlight,
            };
        }

        private static LabelBoxButton CreateButton(string text)
        {
            return new LabelBoxButton
            {
                AutoResize = false,
                Size = new Vector2(150f, 40f),
                Color = LobbyPalette.Button,
                HighlightColor = LobbyPalette.ButtonHighlight,
                Format = LobbyPalette.ButtonText,
                Text = text,
            };
        }

        private void OnSelectionChanged(object sender, EventArgs args)
        {
            _status.Text = "Selected " + SelectedName(_gametypes) + " on " + SelectedName(_maps) + ".";
        }

        private void OnVoteClicked(object sender, EventArgs args)
        {
            _status.Text = "Vote stub: " + SelectedName(_gametypes) + " / " + SelectedName(_maps) + ".";
        }

        private void OnReadyClicked(object sender, EventArgs args)
        {
            _status.Text = "Ready stub: waiting for match start (not implemented).";
        }

        private static string SelectedName(ListBox<string> list)
        {
            if (list.Value == null)
                return "(none)";

            return list.Value.AssocMember ?? "(none)";
        }
    }
}
