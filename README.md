# Uniblox Backlog
Backlog for Uniblox development.

## Opcode support

## Globals
`Uniblox` (`table`)<br>
A table containing all custom Uniblox features, can be used in a `if Uniblox then` in your game check to detect emulation.
- `Uniblox.Config` (`table`)<br>
A table containing various configs for Uniblox. Changing these through a script will not affect the config state on the emulator.
  - `Uniblox.Config.EditableImageMaxRes` (`number`)<br>
  A number linked to the current limit for EditableImage resolution per-axis. Normally limited to 1024 on the Roblox game engine.
