# Uniblox Backlog
Backlog for Uniblox development.

## Opcode support
✅ - Supported<br>
⚠️ - Possibly inaccurate<br>
✖️ - Ignored<br>
❌ - Unsupported, will halt execution if ran into<br>

✖️ `LOP_NOP`
✖️ `LOP_BREAK`
❌ `LOP_LOADNIL` `LOP_LOADB` `LOP_LOADN` `LOP_LOADK`
❌ `LOP_MOVE`
❌ `LOP_GETGLOBAL` `LOP_SETGLOBAL`
❌ `LOP_GETUPVAL` `LOP_SETUPVAL`
❌ `LOP_CLOSEUPVALS`
❌ `LOP_GETIMPORT`
❌ `LOP_GETTABLE` `LOP_SETTABLE`
❌ `LOP_GETTABLEKS` `LOP_SETTABLEKS`
❌ `LOP_GETTABLEN` `LOP_SETTABLEN`
❌ `LOP_NEWCLOSURE` `LOP_DUPCLOSURE`
❌ `LOP_NAMECALL`
❌ `LOP_CALL`
❌ `LOP_RETURN`
❌ `LOP_JUMP` `LOP_JUMPBACK`
❌ `LOP_JUMPIF` `LOP_JUMPIFNOT`
❌ `LOP_JUMPIFEQ` `LOP_JUMPIFLE` `LOP_JUMPIFLT` `LOP_JUMPIFNOTEQ` `LOP_JUMPIFNOTLE` `LOP_JUMPIFNOTLT`
❌ `LOP_ADD` `LOP_SUB` `LOP_MUL` `LOP_DIV` `LOP_MOD` `LOP_POW`
❌ `LOP_ADDK` `LOP_SUBK` `LOP_MULK` `LOP_DIVK` `LOP_MODK` `LOP_POWK`
❌ `LOP_AND` `LOP_OR`
❌ `LOP_ANDK` `LOP_ORK`
❌ `LOP_CONCAT`
❌ `LOP_NOT`
❌ `LOP_MINUS`
❌ `LOP_LENGTH`
❌ `LOP_NEWTABLE` `LOP_DUPTABLE`
❌ `LOP_SETLIST`
❌ `LOP_FORNPREP` `LOP_FORGPREP`
❌ `LOP_FORGPREP_NEXT` `LOP_FORGPREP_INEXT`
❌ `LOP_FORNLOOP` `LOP_FORGLOOP`
❌ `LOP_NATIVECALL`
❌ `LOP_GETVARARGS`
✖️ `LOP_PREPVARARGS`
❌ `LOP_LOADKX`
❌ `LOP_JUMPX`
❌ `LOP_FASTCALL`
❌ `LOP_COVERAGE`
❌ `LOP_CAPTURE`
❌ `LOP_SUBRK` `LOP_DIVRK`
❌ `LOP_FASTCALL1`
❌ `LOP_FASTCALL2`
❌ `LOP_FASTCALL2K`
❌ `LOP_FASTCALL3`
❌ `LOP_JUMPXEQKNIL` `LOP_JUMPXEQKB` `LOP_JUMPXEQKN` `LOP_JUMPXEQKS`
❌ `LOP_IDIV`
❌ `LOP_IDIVK`

## Globals
`Uniblox` (`table`)<br>
A table containing all custom Uniblox features, can be used in a `if Uniblox then` in your game check to detect emulation.
- `Uniblox.Config` (`table`)<br>
A table containing various configs for Uniblox. Changing these through a script will not affect the config state on the emulator.
  - `Uniblox.Config.EditableImageMaxRes` (`number`)<br>
  A number linked to the current limit for EditableImage resolution per-axis. Normally limited to 1024 on the Roblox game engine.
