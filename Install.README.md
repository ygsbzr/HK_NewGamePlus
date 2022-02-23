
			       !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!YOUR VERSION OF HOLLOW KNIGHT MUST BE VERSION 1.4.3.2 AS OF RIGHT NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ALSO MAKE SURE YOU DISABLE EnemyHPBar MOD IF YOU HAVE IT, THIS PACK USES A CUSTOM VERSION OF IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

													    		 Instructions on how to downpatch soon to follow.

	If you already have your game downpatched and have this installed, know your way around modding, or got this from ModInstaller, skip past Installation and head over to the Settings section. 

***********
  Purpose
***********

																	    Salty Spitoon, how tough are ya?

	Boosts enemy health and damage output to your choice, but also boost how much Geo they drop to your choice. (As well as provides a working HP bar for the boosts in enemy health)
	For example:

		Setting "ExtraDamage" in MoreDamage: 1, (default), all regular enemies do 2 damage, all double damage enemies do 3.
		Setting "ExtraDamage" in MoreDamage: 5, regular enemies do 6 damage, double damage enemies do 7.
		Setting "HealthScale" in EnemyHealthScale: 1.25, (default), all enemies and bosses now have 25% additional HP.
		Setting "HealthScale" in EnemyHealthScale: 4.00, all enemies and bosses now have 300% additional HP.
        Setting "Multiplier" in MoreGeo: 2, (default), all geo is multiplied by 200%.
        Setting "Multiplier" in MoreGeo: 5, all geo is multiplied by 500%.

	And etc etc. Pretty simple. Set to your own preference.
	Also displays what you set in the corner as the mod version number when you pause just so you can make sure it's correct.
    Health scaling also boosts enemies and bosses that gain health when you upgrade your nail, such as Husk Sentry, Dung Defender, and Pale Lurker.
    Also scales boss phases to boosted health to avoid any longer phases than others. 
    Goes great with the MoreSaves and DeathCounter mods.

*************************************
   Pre-Installation (Downpatching)
*************************************

	To downpatch Hollow Knight to 1.4.3.2:

	Steam:
		1) Navigate to Hollow Knight in your Steam library, right click, and click Properties.
		2) Click Beta, and then click the drop menu, then select "1.4.3.2 - 32-bit compatibility".

	GoG:
		"Galaxy users can opt to download 1.4.3.2 by opening the game settings in the GoG launcher and selecting it from the list of patches."

********************
   Installation
********************

	1) First you will need to install the Hollow Knight mod installer: https://radiance.host/mods/ModInstaller.exe 
    		1a) If it's not opening for you try downloading again. Mine took a second download for some reason
	2) After you follow the instructions for how to install ModInstaller, install ModCommon from the list of mods in ModInstaller.
	3) After Satchel is installed, click Manually Install Mods, and select the 9soulz_NG_Plus_ModPack.dll file for the mod.
    4) This shouldn't happen, but if you recieve any errors with EnemyHPBar and have never installed the mod before, take these steps:
    		4a) MAKE SURE YOU HAVE THE REGULAR EnemyHPBar MOD DISABLED OR EVEN UNINSTALLED.
            4b) Download the CustomHPBar folder.            
            4c) Navigate to C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight\hollow_knight_Data\Managed\Mods (or wherever you have your mods installed)
            4d) Drag all of the assets from the CustomHPBar folder into the folder in your mod installed folder.

***************
   Settings 
***************

	The mod defaults to 1+ damage to everything, 2x Geo you recieve, and 1.25x the amount of health enemies and bosses have.

	To change these settings, first you need a software such as Notepad++.
    
	Then, with the mod installed, open the game and close it. This will generate the configuration files in: "%APPDATA%..\LocalLow\Team Cherry\Hollow Knight\"

	The mod generates four .GlobalSettings.json files along with their .bak files:

	AAA_MoreDamage.GlobalSettings.json : 
		Where you set how much damage enemies do to you.
			"BadHook": Certain attacks do 1 less damage than they're supposed to when set to "True". Very glitchy, set to False by default.
			"ExtraDamage": Number value of extra masks you recieve when being damaged.

	AAA_MoreGeo.GlobalSettings.json :
    	Where you set how much the geo you recieve is multiplied by.
            "Multiplier": Pretty self explanatory. 
	
    	AAA_MoreHealth.GlobalSettings.json : 
		Where you set your enemy's health scaling.
			"HealthScale": Number value of scaling. Decimals are usable. 

	EnemyHPBar.GlobalSettings.json : 
		How large the HP bars from enemies are on screen. This modpack uses your own settings if you had the original version of EnemyHPBar installed.
			"fgScale": Foreground
			"bgScale": Background
			"mgScale": Midground
			"olScale": Outline
			"bossfgScale": Boss Foreground
			"bossbgScale": Boss Background
			"bossolScale": Boss Outline
            
	You can turn each mod off individually in the menu, but you either need to quit out then back in, transport somewhere like a Hall of Gods boss, or (untested) die and respawn.

****************
   "Glitches"
****************

		- LIFEBLOOD IS SCREWED UP: USE AT YOUR OWN RISK
		- Moss Crawlers, Moss Chargers, Dirtcarvers, and all other enemies that burrow undergound's HP bar shows overground after they burrow.
		- Sly will only heal to 250 health on second phase. While this is a glitch, we decided to keep it, as we couldn't think of anything more annoying than an extended 2nd phase Sly.
		- (Not a glitch) Absolute Radiance dies at ~700 health: This is part of the vanilla game, you just never had a health bar to show you.

	One day I might have this updated but in my opinion it's too much effort for what it'd fix. You're welcome to fix it though if you want. 

**************
   Credits
**************

	Jamie - Main Coder for EnemyHealthScale:
		jamie <3#7264

	Mul - Main Coder for MoreDamage, and modified EnemyHPBar to play with EnemyHealthScale

	Ruttie - Main Coder for MoreGeo:        
        Ruttie#3005

	Exsersewo - Mod Repacker, Sanity Keeper: 
		exsersewo#1024

	Me - I didn't code anything but I did have this made for my streams, (and anyone else into this masochism):
    	twitch.tv/keeganostrowski
		 www.ilusensfallacy.com
			  thisdik#2265

	Here is a link for any updates to the mod. I will try to include the source code for the modpack in its entirety, as well as the mods separately, and their source code:
														https://mega.nz/folder/j8YSWR5B#13E4JY0txYZDCgxnkmAQJQ
