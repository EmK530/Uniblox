# Uniblox
Roblox RBXL importer and Luau emulator in Unity 6.2

## What is this repository?
This is a repository for the upcoming project Uniblox, that emulates non-humanoid Roblox games<br>
in Unity by parsing instances from an RBXL file and emulating Luau code.

At the moment, the repository will only contain the code related to the engine for eventual contributions.<br>
When the project is finalized and ready for release, it will be updated to contain the Unity project files.

## GameLoader Property Support
Table of property types that the RBXL parser currently is able to parse from the binary.<br>

✅ - Supported<br>
❌ - Unsupported, will be ignored if ran into<br>

✅ `0x01: String`<br>
✅ `0x02: Bool`<br>
✅ `0x03: Int32`<br>
❌ `0x04: Float32`<br>
❌ `0x05: Float64`<br>
❌ `0x06: UDim`<br>
❌ `0x07: UDim2`<br>
❌ `0x08: Ray`<br>
❌ `0x09: Faces`<br>
❌ `0x0A: Axes`<br>
❌ `0x0B: BrickColor`<br>
❌ `0x0C: Color3`<br>
❌ `0x0D: Vector2`<br>
❌ `0x0E: Vector3`<br>
❌ `0x10: CFrame`<br>
❌ `0x12: Enum`<br>
❌ `0x13: Referent`<br>
❌ `0x14: Vector3int16`<br>
❌ `0x15: NumberSequence`<br>
❌ `0x16: ColorSequence`<br>
❌ `0x17: NumberRange`<br>
❌ `0x18: Rect`<br>
❌ `0x19: PhysicalProperties`<br>
❌ `0x1A: Color3uint8`<br>
❌ `0x1B: Int64`<br>
❌ `0x1C: SharedString`<br>
✅ `0x1D: Bytecode`<br>
❌ `0x1E: OptionalCoordinateFrame`<br>
❌ `0x1F: UniqueId`<br>
❌ `0x20: Font`<br>
❌ `0x22: Content`<br>

## Luau Opcode Support
Table of opcodes detailing what the Luau emulator currently supports.<br>
This should not be used as a measurement of completion, because Luau is more than opcodes.

✅ - Supported<br>
⚠️ - Possibly inaccurate<br>
ℹ️ - Work in progress<br>
✖️ - Ignored<br>
❌ - Unsupported, will halt execution if ran into<br>

✖️ `LOP_NOP`<br>
✖️ `LOP_BREAK`<br>
✅ `LOP_LOADNIL` `LOP_LOADB` `LOP_LOADN` `LOP_LOADK`<br>
❌ `LOP_MOVE`<br>
❌ `LOP_GETGLOBAL` `LOP_SETGLOBAL`<br>
❌ `LOP_GETUPVAL` `LOP_SETUPVAL`<br>
❌ `LOP_CLOSEUPVALS`<br>
✅ `LOP_GETIMPORT`<br>
❌ `LOP_GETTABLE` `LOP_SETTABLE`<br>
❌ `LOP_GETTABLEKS` `LOP_SETTABLEKS`<br>
❌ `LOP_GETTABLEN` `LOP_SETTABLEN`<br>
❌ `LOP_NEWCLOSURE`<br>
✅ `LOP_DUPCLOSURE`<br>
✅ `LOP_NAMECALL`<br>
ℹ️ `LOP_CALL`<br>
ℹ️ `LOP_RETURN`<br>
✅ `LOP_JUMP` `LOP_JUMPBACK`<br>
✅ `LOP_JUMPIF` `LOP_JUMPIFNOT`<br>
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
