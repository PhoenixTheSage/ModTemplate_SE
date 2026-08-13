using RichHudFramework.UI;
using VRageMath;

namespace Lobbies.UI
{
    /// <summary>
    /// Placeholder Halo-style colors and text formats. Replace with real art later.
    /// </summary>
    public static class LobbyPalette
    {
        public static readonly Color Backdrop = new Color(6, 10, 16, 235);
        public static readonly Color Panel = new Color(14, 20, 30, 230);
        public static readonly Color ListBg = new Color(8, 12, 18, 220);
        public static readonly Color Accent = new Color(232, 180, 80);
        public static readonly Color Border = new Color(232, 180, 80, 180);
        public static readonly Color Button = new Color(42, 32, 16, 255);
        public static readonly Color ButtonHighlight = new Color(86, 62, 22, 255);
        public static readonly Color Text = new Color(236, 230, 214);
        public static readonly Color Muted = new Color(168, 162, 148);

        public static readonly GlyphFormat Header = new GlyphFormat(Accent, TextAlignment.Left, 1.35f);
        public static readonly GlyphFormat Subheader = new GlyphFormat(Muted, TextAlignment.Left, 0.95f);
        public static readonly GlyphFormat Body = new GlyphFormat(Text, TextAlignment.Left, 1.05f);
        public static readonly GlyphFormat ButtonText = new GlyphFormat(Accent, TextAlignment.Center, 1.1f);
        public static readonly GlyphFormat Status = new GlyphFormat(Muted, TextAlignment.Left, 0.95f);
    }
}
