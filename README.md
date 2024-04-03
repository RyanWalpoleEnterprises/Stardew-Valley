<p align="center">
<img height=300px src="https://github.com/RyanWalpoleEnterprises/Stardew-Valley/raw/release-stable/web/SDVMM_Logo.png?raw=true">
</p>

# Stardew Valley Mod Manager

The Stardew Valley Mod Manager and Modded Framework is an extension to SMAPI, the open-source modding framework API for Stardew Valley that lets players play the game with mods. Much alike SMAPI, The Stardew Valley Mod Manager does not edit or change any of the core game files and is installed as a completely separate executable to both the main game and the SMAPI launcher. This powerful new application allows you to do a variety of different operations pertaining to mod management and game save management. See "Features" for more information about the different things you can do with the Stardew Valley Mod Manager.

## Table of Contents

- [Features](#features)
- [How-To/Documentation](#documentation)
  - [Download and Install](#setup-and-configuration)
  - [Using the Mod Manager](#using-the-mod-manager)
- [License](#license)
- [Download](#download)
    - [System Requirements](#system-requirements)
    - [Windows Download](#windows-download)
- [Branches](#branches)

## Features
The Stardew Valley Mod Manager comes with a plethora of features pertaining to mod management and game save management.

1. <b>Installing Mods</b>
Once you have downloaded your mod from NexusMods, all you need to do is open the Stardew Valley Mod Manager, click "Install Mods" then "Add New Mods (.zip)" and select your ZIP file downloaded from NexusMods. Once the Mod Manager has installed your mod, it will be automatically added to your Disabled Mods List, from which you can enable the mod.

2. <b>Uninstalling Mods</b>
Mods can be removed just as easily as they can be installed. Simply disable the mod (if it was enabled) and click the Delete button. Or simply disable the mod and enable it at a later date.

3. <b>Disable and Enable Installed Mods</b>
Have mods be disabled without having to delete them entirely. With a click of a button you can move a mod from disabled to enabled and back to disabled. Disabled mods will remain on your system but will not be active when you launch your modded save.

4. <b>Check Mod Updates (Beta)</b>
With just a few clicks you can check if a compatible mod is currently up to date. Simply open the "Check for Mod Updates [Beta]" window from the Mod Management screen, select your mod and click "Check for Updates". If the mod is compatible, you'll be able to see if the mod is up to date, and if it isn't, get a link to download the new version.*

5. <b>Save and Load Mod Presets</b>
Create mod presets so you can quickly mass enable and disable groups of mods depending on what save you're playing, making mod management that much better. By default, the Stardew Valley Mod Manager comes with a Default preset that includes only SMAPI default mods. Easily revert back to a clean slate with just a few clicks.

6. <b>Modpack Installer</b>
Install entire modpacks with just a single file. Simply install a .sdvmp file and let the Mod Manager find the mods, make sure you're running the minimum SMAPI version or above and even let the program create you a preset with the mods defined for the modpack. It's never been easier to install a collection of mods.

7. <b>Backup and Manage Game Saves</b>
Create backups and delete any of your farms with built in Game Save Management tools.

*Please note that for a mod to be compatible, it must be configured with NexusMod update keys among some other specific criteria. For more information, [click here](https://rwe-labs.gitbook.io/sdvmm/developer/developing-for-stardew-valley-mod-manager)

## Documentation
<b>Important:</b> Please note that due to changes in the application's user interface with version 220501, some of the screenshots used in the documentation may be out of date and may not accurately reflect the visual experience you may be having. We believe that despite this, the instructions are still relevant - the appearance and names of labels, windows and user interface may differ but should still adhere closely enough to the written instructions.

### Setup and Configuration
Simply [download](#download) the latest release of Stardew Valley Mod Manager from this repository and follow the installation prompts. From there, you can keep your Mod Manager updated with the built in update check tools. Please note that you may have trouble with Chrome, Edge and Windows trying to block you from installing the application as it is not a commonly downloaded application.

- [Getting Started: Setup and Configuration](https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration)
- [How-To: Downloading the Mod Manager](https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/downloading-the-application)
- [How-To: Installing the Mod Manager](https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/installing-the-application)
- [How-To: Setting up the Mod Manager](https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/setting-up-the-application)
- [How-To: Updating Stardew Valley Mod Manager](https://rwe-labs.gitbook.io/sdvmm/getting-started/updating-the-mod-manager)
- [How-To: Navigating the Mod Manager](https://rwe-labs.gitbook.io/sdvmm/getting-started/navigating-the-mod-manager)

### Using the Mod Manager
To make it easy for you to access, we've established a Wiki that contains a variety of "How-to" articles that outline and explain features and processes. We've got a couple of articles you can access here, or you can click "Visit our Wiki" to see more.

- [How-To: Installing Mods](https://rwe-labs.gitbook.io/sdvmm/mod-management/installing-mods)
- [How-To: Enabling and Disabling Mods](https://rwe-labs.gitbook.io/sdvmm/mod-management/enabling-and-disabling-mods)
- [How-To: Updating Mods](https://rwe-labs.gitbook.io/sdvmm/mod-management/updating-mods)
- [How-To: Create a Mod Preset](https://rwe-labs.gitbook.io/sdvmm/mod-management/mod-presets/create-a-mod-preset)
- [How-To: Load a Mod Preset](https://rwe-labs.gitbook.io/sdvmm/mod-management/mod-presets/load-a-mod-preset)

Or for more articles and information, [Visit our Wiki](https://rwe-labs.gitbook.io/sdvmm/)

## License
It's your responsibility to read the license agreement when installing the software if you intend on using it as much as it's our responsibility to do our best to show it to you.
If you're modifying and/or downloading the source code, however, your responsibility to understand what you are and are not permitted to do become even more of a big deal - and it's your responsibility. Please familiarise yourself with our [license agreement](https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/release-stable/LICENSE.md) before even downloading a copy of the source code.

## Download
### System Requirements
<hr>

#### Why does this application need administrative privileges?
Stardew Valley Mod Manager (as of version 230301) requires administraive privileges in order to run. This may be alarming to some users, however, this is in response to some longstanding issues with the Mod Manager on machines where Stardew Valley is installed in the default directory.

When Stardew Valley is installed in a folder that is child to the ``C:\Program Files\`` directory, the Stardew Valley Mod Manager is unable to move folders and files in and out of this directory, as it is protected by the system. For this reason, the application requires administrative privileges so that mods can be installed, enabled, disabled, uninstalled and deleted. It is easier for us to implement a program-wide enforcement of higher privileges than it is to redesign the program to only require priviliges when file transfers are taking place. This is something we are considering for the future however.

As always, the code for the Stardew Valley Mod Manager is completely open source. There is no cause to be alarmed.

#### Recommended Specifications
<b>Operating System</b>
- Designed for Windows 11
- Windows 10 Compatible

<b>Hardware Requirements</b>
- 300mb Disk Space
    - 150mb Disk Space for Installation
    - 50mb Disk Space for Download
    - 100mb Disk Space for In-App Downloads

<hr>

#### Minimum Specifications
<b>Operating System</b>
- Windows 7 or above (Untested)

<b>Hardware Requirements</b>
- 200mb Disk Space
    - 150mb Disk Space for Installation
    - 50mb Disk Space for Download

<hr>

### Windows Download
Download the most recent version of Stardew Valley Mod Manager by visiting our releases page. Once you have downloaded Stardew Valley Mod Manager and installed the application, you can keep it up to date from within the application, never needing to return to this repository (as of v220401). We recommend downloading our latest release, as it is the most stable release with the most features.

- [View Latest Release](https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/releases/latest)
- [View All Releases](https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/releases)

#### Need Help?
If you're running into any issues with downloading or installing the application, see [download and installation help](https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/downloading-the-application)

## Branches

Please see a list of branches for this repository: 

<p align="left" style="margin-bottom: 1px !important;">
  <a href="https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/tree/release-stable">
    <img  src="https://raw.githubusercontent.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/release-stable/web/Srelease-stable.png" alt="Stable Release" align="left">
  </a>
 <a href="https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/tree/release-alpha">
    <img  src="https://raw.githubusercontent.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/release-stable/web/Srelease-alpha.png" alt="Alpha Release" align="left">
  </a>
  <a href="https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/tree/development">
    <img  src="https://raw.githubusercontent.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/release-stable/web/Srelease-development.png" alt="adf" align="left">
  </a>
</p>
