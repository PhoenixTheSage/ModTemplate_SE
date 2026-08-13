# Rich HUD Framework (this mod)

Every mod from this template uses **Rich HUD** (Dark Helmet / Zach Hembree) for UI.

## Runtime dependency (required)

Subscribe to **[Rich HUD Master](https://steamcommunity.com/workshop/filedetails/?id=1965654081)** (workshop id `1965654081`) and enable it in the world.  
When publishing, add Master as a Workshop dependency. Load order does not matter.

Embedded Client source alone does nothing without Master.

## Client module (compile-time)

**Full** Client **1.3.0.0** is in `Data/Scripts/Lobbies/RichHudFramework/` (`Shared/` + `Client/`).

To refresh: download from [Releases](https://zachhembree.github.io/RichHudFramework.Client/Releases.html) or [GitHub](https://github.com/ZachHembree/RichHudFramework.Client) and replace those two folders.

Initialize from **one** session component only (`RichHudClient.Init` in `ModSession`).

## Documentation

| Need | Link |
|---|---|
| Overview | https://zachhembree.github.io/RichHudFramework.Client/ |
| Install / integration | https://zachhembree.github.io/RichHudFramework.Client/articles/Installation-and-Mod-Integration.html |
| API reference | https://zachhembree.github.io/RichHudFramework.Client/api/RichHudFramework.html |
| Client repo | https://github.com/ZachHembree/RichHudFramework.Client |
