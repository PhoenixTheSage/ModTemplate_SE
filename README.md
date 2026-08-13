# Lobbies

Space Engineers **ModAPI** lobby overlay: a Halo 3-style social screen built with Rich HUD. This pass is a toggleable full-screen placeholder (no auto-open, no match start).

## Quick start

1. Copy or symlink this folder into `%APPDATA%\SpaceEngineers\Mods\`.
2. Rich Hud **Full** Client 1.3.0.0 is already in `Data/Scripts/Lobbies/RichHudFramework/` — see [RICHHUD.md](RICHHUD.md).
3. In a world, enable this mod and **Rich HUD Master** (workshop `1965654081`).
4. Chat should show `Session loaded…` then `Rich Hud registered…`.
5. Press **Shift+F3** to open/close the lobby overlay. Vanilla HUD hides while it is open. Rebind **ToggleLobby** in the Rich Hud Terminal (default **F2**) under **Lobbies → Binds**.

## Agent / API docs

- ModAPI truth: [SELIB.md](SELIB.md) → `T:/Cursor Projects/SELib/docs/AGENT.md`
- Rich Hud: [RICHHUD.md](RICHHUD.md)

## Layout

```
Data/Scripts/Lobbies/
  ModSession.cs          # session entry, Shift+F3 toggle, Rich Hud binds
  Lobby/
    LobbyScreen.cs       # full-screen overlay (hidden until toggled)
    GameSetupPanel.cs    # left: gametype / map / vote stubs
    PlayerListPanel.cs   # right: live player roster
    LobbyPalette.cs      # placeholder colors and text formats
  RichHudFramework/      # Full Client 1.3.0.0 (Shared/ + Client/)
```
