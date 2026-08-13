# SELib quick start (this mod)

Space Engineers **ModAPI** truth for agents lives in the local SELib clone - not guesses.

## Open first

| Need | Open |
|---|---|
| **Docs router** (preferred) | `T:/Cursor Projects/SELib/docs/AGENT.md` |
| **Browsable site** | `T:/Cursor Projects/SELib/site/_site/index.html` (rebuild: `T:/Cursor Projects/SELib/scripts/refresh.cmd`) |
| **Site agent mirror** | `T:/Cursor Projects/SELib/site/articles/agent.md` |
| **Sources** | `T:/Cursor Projects/SELib/docs/sources.md` |
| **Malforge ModAPI** (secondary) | https://malforge.github.io/spaceengineers/modapi/ |

Local extract + `dotnet selib check` win over Keen/Malforge/wiki.

## SELib path

`T:/Cursor Projects/SELib`
## Agent rules of thumb

1. Start at `T:/Cursor Projects/SELib/docs/AGENT.md` - follow the task row (cheat sheet -> recipe -> at most 2 type pages).
2. Escalate member signatures via `T:/Cursor Projects/SELib/site/api/<FullName>.md` or the HTML site.
3. Whitelist gate: from the SELib repo, `dotnet selib check <TypeOrMember>`. `member-only-gap` / `unknown` means do not use. See `T:/Cursor Projects/SELib/docs/whitelist/blacklist.md`.
4. Never load all of `data/modapi-catalog.json`. Prefer ModAPI over whitelisted internals; never mix `*.Ingame` usings with ModAPI. `site/api` member tables are not the whitelist.

Installed by: `T:/Cursor Projects/SELib/scripts/install-consumer-rule.cmd`.
