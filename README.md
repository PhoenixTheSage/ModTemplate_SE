# ModTemplate_SE

Lightweight Space Engineers **ModAPI** C# mod template with a Rich Hud "Hello World" Label.

## Quick start

1. Copy or symlink this folder into `%APPDATA%\SpaceEngineers\Mods\`.
2. Drop the Rich Hud **Full** Client into `Data/Scripts/ModTemplate/RichHudFramework/` — see [RICHHUD.md](RICHHUD.md).
3. In a world, enable this mod and **Rich HUD Master** (workshop `1965654081`).
4. You should see chat `Session loaded…` and an on-screen **Hello World** label.

## Agent / API docs

- ModAPI truth: [SELIB.md](SELIB.md) → `T:/Cursor Projects/SELib/docs/AGENT.md`
- Rich Hud: [RICHHUD.md](RICHHUD.md)

## Layout

```
Data/Scripts/ModTemplate/
  ModSession.cs          # session entry + Hello World Label
  RichHudFramework/       # drop Shared/ + Client/ here (not vendored)
```
