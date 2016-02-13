Ultimate Ninja Storm Mod Manager
================

This is a simple mod management utility for the Naruto Shippuden: Ultimate Ninja Storm games, 3, Revolution, and 4 specifically, based off of MainMemory's SA2 Mod Manager. The manager functions by copying the contents of enabled mod folders to the root of the game before launching, allowing the user to avoid lots of manual work in managing their mods.

Installation
------------

You can install the manager either by downloading and compiling the source code from this repository, or downloading the latest release package for the corresponding game from [here.](https://github.com/wolfy852/unsr-mod-manager/releases) The latter is highly recommended.

1. Download the zip from the releases page
2. Extract the contents of the archive to `Steam Installation Folder)\steamapps\common\NARUTO SHIPPUDEN ULTIMATE NINJA STORM REVOLUTION\` for Revolution, `(Steam Installation Folder)\steamapps\common\NARUTO SHIPPUDEN Ultimate Ninja STORM 3 Full Burst\` for UNS3FB, or (Steam Installation Folder)\steamapps\common\NARUTO SHIPPUDEN Ultimate Ninja STORM 4\ for UNS4.
3. Start the manager and configure your mods (details below)

Adding a Mod
------------

1. Run the manager
2. Click the "New Mod" button
3. Fill in the name, author, and description for the mod
4. Navigate to <code>mods/(mod name)</code> and insert the mod's <code>data_win32</code> folder along with any other folders it uses

Running with Mods
-----------------

1. Run the manager
2. Click the "Enable Mods" button
3. Check the boxes for any mods you wish to enable
4. Click "Save" or "Save and Play"

Notes
-----

- The "Use Launcher" button does not work with a Steam copy of the game, as Steam will force the game to use the launcher regardless. UNS4 doesn't have a launcher, so the checkbox doesn't exist there.
- The manager may not function properly if not given write permissions in the game directory. Try running as administrator to fix any issues encountered from this.
- Mod listings will be remembered after closing and relaunching, but settings such as the "Use Launcher" and "Exit after Launch" checkboxes will not be remembered after closing the manager.
- The source code might have some screwed up indenting. Sorry about that, I'm not quite used to Visual Studio and all the code shows up properly indented there for some reason.
- Make sure to double-check that you're downloading the correct manager on the release page.
- Requires .NET Framework 3.5 or higher to run.
