# Uniblox Backlog
Backlog for Uniblox development.

## Opcode support
✅ - Supported<br>
⚠️ - Possibly inaccurate<br>
✖️ - Ignored<br>
❌ - Unsupported, will halt execution if ran into<br>

✖️ `LOP_NOP`<br>
✖️ `LOP_BREAK`<br>
❌ `LOP_LOADNIL` `LOP_LOADB` `LOP_LOADN` `LOP_LOADK`<br>
❌ `LOP_MOVE`<br>
❌ `LOP_GETGLOBAL` `LOP_SETGLOBAL`<br>
❌ `LOP_GETUPVAL` `LOP_SETUPVAL`<br>
❌ `LOP_CLOSEUPVALS`<br>
❌ `LOP_GETIMPORT`<br>
❌ `LOP_GETTABLE` `LOP_SETTABLE`<br>
❌ `LOP_GETTABLEKS` `LOP_SETTABLEKS`<br>
❌ `LOP_GETTABLEN` `LOP_SETTABLEN`<br>
❌ `LOP_NEWCLOSURE` `LOP_DUPCLOSURE`<br>
❌ `LOP_NAMECALL`<br>
❌ `LOP_CALL`<br>
❌ `LOP_RETURN`<br>
❌ `LOP_JUMP` `LOP_JUMPBACK`<br>
❌ `LOP_JUMPIF` `LOP_JUMPIFNOT`<br>
❌ `LOP_JUMPIFEQ` `LOP_JUMPIFLE` `LOP_JUMPIFLT` `LOP_JUMPIFNOTEQ` `LOP_JUMPIFNOTLE` `LOP_JUMPIFNOTLT`<br>
❌ `LOP_ADD` `LOP_SUB` `LOP_MUL` `LOP_DIV` `LOP_MOD` `LOP_POW`<br>
❌ `LOP_ADDK` `LOP_SUBK` `LOP_MULK` `LOP_DIVK` `LOP_MODK` `LOP_POWK`<br>
❌ `LOP_AND` `LOP_OR`<br>
❌ `LOP_ANDK` `LOP_ORK`<br>
❌ `LOP_CONCAT`<br>
❌ `LOP_NOT`<br>
❌ `LOP_MINUS`<br>
❌ `LOP_LENGTH`<br>
❌ `LOP_NEWTABLE` `LOP_DUPTABLE`<br>
❌ `LOP_SETLIST`<br>
❌ `LOP_FORNPREP` `LOP_FORGPREP`<br>
❌ `LOP_FORGPREP_NEXT` `LOP_FORGPREP_INEXT`<br>
❌ `LOP_FORNLOOP` `LOP_FORGLOOP`<br>
❌ `LOP_NATIVECALL`<br>
❌ `LOP_GETVARARGS`<br>
✖️ `LOP_PREPVARARGS`<br>
❌ `LOP_LOADKX`<br>
❌ `LOP_JUMPX`<br>
❌ `LOP_FASTCALL`<br>
❌ `LOP_COVERAGE`<br>
❌ `LOP_CAPTURE`<br>
❌ `LOP_SUBRK` `LOP_DIVRK`<br>
❌ `LOP_FASTCALL1`<br>
❌ `LOP_FASTCALL2`<br>
❌ `LOP_FASTCALL2K`<br>
❌ `LOP_FASTCALL3`<br>
❌ `LOP_JUMPXEQKNIL` `LOP_JUMPXEQKB` `LOP_JUMPXEQKN` `LOP_JUMPXEQKS`<br>
❌ `LOP_IDIV`<br>
❌ `LOP_IDIVK`<br>

## Globals
`Uniblox` (`table`)<br>
A table containing all custom Uniblox features, can be used in a `if Uniblox then` in your game check to detect emulation.
- `Uniblox.Config` (`table`)<br>
A table containing various configs for Uniblox. Changing these through a script will not affect the config state on the emulator.
  - `Uniblox.Config.EditableImageMaxRes` (`number`)<br>
  A number linked to the current limit for EditableImage resolution per-axis. Normally limited to 1024 on the Roblox game engine.
