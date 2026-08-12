# ModTemplate_SE

Lightweight Space Engineers **ModAPI** C# mod template with a Rich Hud Terminal category.

## Quick start

1. Copy or symlink this folder into `%APPDATA%\SpaceEngineers\Mods\`.
2. Rich Hud **Full** Client 1.3.0.0 is already in `Data/Scripts/ModTemplate/RichHudFramework/` — see [RICHHUD.md](RICHHUD.md).
3. In a world, enable this mod and **Rich HUD Master** (workshop `1965654081`).
4. Chat should show `Session loaded…` then `Rich Hud registered…`. Open the Rich Hud Terminal (default **F2**) and select **Template** — it shows **Hello World**.

## Agent / API docs

- ModAPI truth: [SELIB.md](SELIB.md) → `T:/Cursor Projects/SELib/docs/AGENT.md`
- Rich Hud: [RICHHUD.md](RICHHUD.md)

## Layout

```
Data/Scripts/ModTemplate/
  ModSession.cs          # session entry + Template terminal page
  RichHudFramework/       # Full Client 1.3.0.0 (Shared/ + Client/)
```
