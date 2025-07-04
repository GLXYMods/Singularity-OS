using GorillaTag.Cosmetics.Summer;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;
using UnityEngine;
using GorillaTag.Cosmetics;
using StupidTemplate;
using Singularity_OS.Menu;
using Singularity_OS.Patches;
using Singularity_OS.Classes;

namespace AetherTemp.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "News", method =() => Main.news(), disableMethod =() => Main.newsoff(), enabled = true, toolTip = "Opens the news page."},
                new ButtonInfo { buttonText = "Modules", method =() => SettingsMods.Modules(), isTogglable = false, toolTip = "Opens the modules page."},
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.MainSettings(), isTogglable = false, toolTip = "Opens the settings page."},
                new ButtonInfo { buttonText = "Info", method =() => Main.infoshit(), disableMethod =() => Main.offInfoShit(), toolTip = "Opens the settings page."},
            },

            new ButtonInfo[] { // Main Settings
                new ButtonInfo { buttonText = "Safety", method =() => SettingsMods.safety(), isTogglable = false, toolTip = "Opens the safety page."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the Menu settings page."},
                new ButtonInfo { buttonText = "Gunlib", method =() => SettingsMods.GunLib(), isTogglable = false, toolTip = "Opens the GunLib settings page."},
                new ButtonInfo { buttonText = "Notifications", method =() => SettingsMods.Notification(), isTogglable = false, toolTip = "Opens the notifications settings page."}
            },

            new ButtonInfo[] { // Modules
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.basic(), isTogglable = false, toolTip = "Opens the basic mod page."},
                new ButtonInfo { buttonText = "Visual", method =() => SettingsMods.visual(), isTogglable = false, toolTip = "Opens the Visual mod page."},
                new ButtonInfo { buttonText = "Fun", method =() => SettingsMods.fun(), isTogglable = false, toolTip = "Opens the Fun mod page."},
                new ButtonInfo { buttonText = "OP", method =() => SettingsMods.op(), isTogglable = false, toolTip = "Opens the Overpowered mod page."},
            },

            new ButtonInfo[] { // Movement
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.platforms(), toolTip = "Walk with cubes."},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Fly."},
                new ButtonInfo { buttonText = "Trigger Fly", method =() => Movement.Fly(), toolTip = "Fly with trigger."},
                new ButtonInfo { buttonText = "Joystick Fly", method =() => Movement.JoystickFly(), toolTip = "Fly with joystick."},
                new ButtonInfo { buttonText = "Fast Fly", method =() => Movement.FastFly(), toolTip = "Fly fast."},
                new ButtonInfo { buttonText = "Slow Fly", method =() => Movement.FastFly(), toolTip = "Fly slow."},
                new ButtonInfo { buttonText = "Fly Noclip", method =() => Movement.flywithnoclip(), toolTip = "Fly While Also Noclip through anything."},
                new ButtonInfo { buttonText = "Slingshot", method =() => Movement.Slingshit(), toolTip = "Fly with velocity."},
                new ButtonInfo { buttonText = "Slingshot Up", method =() => Movement.SlingshitUp(), toolTip = "Fly with velocity Up."},
                new ButtonInfo { buttonText = "Slingshot Down", method =() => Movement.SlingshitDown(), toolTip = "Fly with velocity Down."},
                new ButtonInfo { buttonText = "Car Monkey", method =() => Movement.carmonke(), toolTip = "Become a car kinda."},
                new ButtonInfo { buttonText = "Iron Monkey", method =() => Movement.iron(), toolTip = "Become iron man."},
                new ButtonInfo { buttonText = "TP Gun", method =() => Movement.TpGun(), toolTip = "Teleport with a gun."},
                new ButtonInfo { buttonText = "Noclip", method =() => Movement.Noclip(), toolTip = "Noclip through anything."},
                new ButtonInfo { buttonText = "<color=purple>[Low]</color> Gravity", method =() => Movement.LowGravity(), toolTip = "Low Gravity."},
                new ButtonInfo { buttonText = "<color=purple>[High]</color> Gravity", method =() => Movement.HighGravity(), toolTip = "High Gravity."},
                new ButtonInfo { buttonText = "<color=purple>[Zero]</color> Gravity", method =() => Movement.ZeroGravity(), toolTip = "Zero Gravity."},
                new ButtonInfo { buttonText = "Broken Controller Left", method =() => Movement.BrokenControllerLEFT(), toolTip = "Broken Controller Left."},
                new ButtonInfo { buttonText = "Broken Controller Right", method =() => Movement.BrokenControllerRIGHT(), toolTip = "Broken Controller Right."},
                new ButtonInfo { buttonText = "Throw Controller", method =() => Movement.ThrowControllers(), toolTip = "Throw Controllers."},
                new ButtonInfo { overlapText = "Wall Walk Type:", buttonText = "Wall Walk Type:", method =() => Advantages.ChangeWallWalkType(), isTogglable = false, toolTip = "Change the assist type with wall walk."},
                new ButtonInfo { buttonText = "Wall Walk", method =() => Advantages.WallWalk(), toolTip = "Have assist with walls."},
            },

            new ButtonInfo[] { // Visual
                new ButtonInfo { buttonText = "Overview", method =() => OverView.Initialize(), disableMethod =() => OverView.DisableOverView(), enabled = true, toolTip = "See yourself when your vrrig is disabled."},
                new ButtonInfo { buttonText = "Box Esp", method =() => Visual.BoxEsp(), toolTip = "See People Through Walls With A Box."},
                new ButtonInfo { buttonText = "Hollow Box Esp", method =() => Visual.HollowBoxEsp(), toolTip = "See People Through Walls With A Hollow Box."},
                new ButtonInfo { buttonText = "Sphere Esp", method =() => Visual.sphereEsp(), toolTip = "See People Through Walls With A Sphere."},
                new ButtonInfo { buttonText = "Head Esp", method =() => Visual.headEsp(), toolTip = "See People Through Walls With A Sphere And Line To Their Head."},
                new ButtonInfo { buttonText = "NameTag", method =() => Visual.NameTags(), toolTip = "See Peoples Names Above Their Head."},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.tracers(), toolTip = "See Peoples Through Walls With A Line."},
                new ButtonInfo { buttonText = "Chams", method =() => Visual.Chams(), disableMethod =() => Visual.ChamsOff(), toolTip = "See people with a outline through walls."},
            },

            new ButtonInfo[] { // Networked
            },

            new ButtonInfo[] { // Overpowered
                new ButtonInfo { buttonText = "Rig Mods", method =() => SettingsMods.rig(), isTogglable = false, toolTip = "Opens the Rig mod page."},
                new ButtonInfo { buttonText = "Follow Gun", method =() => Overpowered.followgun(), toolTip = "Follow the person you shoot."},
                new ButtonInfo { buttonText = "Follow Closest", method =() => Overpowered.followclosest(), toolTip = "Follow the nearest person to you."},
                new ButtonInfo { buttonText = "Copy Gun", method =() => Overpowered.copygun(), toolTip = "Copy the person you shoot."},
                new ButtonInfo { buttonText = "Copy Closest", method =() => Overpowered.copyclosest(), toolTip = "Copy the nearest person to you."},
                new ButtonInfo { buttonText = "Auto Juke", method =() => Movement.AutoJuke(), toolTip = "Auto Juke."},
                new ButtonInfo { buttonText = "Ghost On Touch", method =() => Overpowered.GhostOnTouch(), toolTip = "Whenever someone touches your head you go into ghost monke."},
                new ButtonInfo { buttonText = "Inviz On Touch", method =() => Overpowered.InvizOnTouch(), toolTip = "Whenever someone touches your head you go into inviz monke."},
            },


            new ButtonInfo[] { // GunLib
                new ButtonInfo { buttonText = "Equip Gun", method =() => mods.Gun(), isTogglable = true, toolTip = "Equips a gun."},
                new ButtonInfo { buttonText = $"Smoothness: {(mods.num == 5f ? "Very Fast" : mods.num == 10f ? "Normal" : "Super Smooth")}", method = () => { mods.GunSmoothNess(); foreach (var category in Buttons.buttons) foreach (var button in category) if (button.buttonText.StartsWith("Smoothness")) button.buttonText = $"Smoothness: {(mods.num == 5f ? "Super Smooth" : mods.num == 10f ? "Normal" : "No Smooth")}"; }, isTogglable = false, toolTip = "Changes gun smoothness." },
                new ButtonInfo { buttonText = $"Gun Color: {mods.currentGunColor.name}", method = () => { mods.CycleGunColor(); Buttons.buttons.ForEach(category => category.ForEach(button => { if (button.buttonText.StartsWith("Gun Color")) button.buttonText = $"Gun Color: {mods.currentGunColor.name}"; })); }, isTogglable = false, toolTip = "Cycles through gun colors." },
                new ButtonInfo { buttonText = $"Toggle Sphere Size: {(mods.isSphereEnabled ? "Enabled" : "Disabled")}", method = () => { mods.isSphereEnabled = !mods.isSphereEnabled; if (mods.GunSphere != null) mods.GunSphere.transform.localScale = mods.isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f); foreach (var category in Buttons.buttons) foreach (var button in category) if (button.buttonText.StartsWith("Toggle Sphere Size")) button.buttonText = $"Toggle Sphere Size: {(mods.isSphereEnabled ? "Enabled" : "Disabled")}"; }, isTogglable = false, toolTip = "Toggles the size of the gun sphere." }
            },

            new ButtonInfo[] { // MenuSettings
                new ButtonInfo { buttonText = "Save Mods", method =() => Main.Save(), isTogglable = false, toolTip = "Save your enabled mods."},
                new ButtonInfo { buttonText = "Load Mods", method =() => Main.Load(), isTogglable = false, toolTip = "Load your saved mods."},
                new ButtonInfo { buttonText = "Save Settings", method =() => Main.SaveSettings(), isTogglable = false, toolTip = "Saves your settings, AUTO LOADS WHEN YOU START UP YOUR GAME!"},
                new ButtonInfo { overlapText = "Menu Theme", buttonText = "Menu Theme", method =() => mods.ChangeMenuTheme(), isTogglable = false, toolTip = "Cycle through different menu themes."},
                new ButtonInfo { overlapText = "Esp Color", buttonText = "Esp Color", method =() => Visual.ChangeEspColor(), isTogglable = false, toolTip = "Cycle through different esp colors."},
                new ButtonInfo { overlapText = "Btn Sound", buttonText = "Btn Sound", method =() => mods.changeBtnSound(), isTogglable = false, toolTip = "Cycle through different btn sounds."},
                new ButtonInfo { buttonText = "Right/Left Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = true, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = $"Delete Time: {(Main.num == 2f ? "Default" : Main.num == 5f ? "Long" : "Fast")}", method = () => { Main.MenuDeleteTime(); foreach (var category in Buttons.buttons) foreach (var button in category) if (button.buttonText.StartsWith("Delete Time")) button.buttonText = $"Delete Time: {(Main.num == 2f ? "Default" : Main.num == 5f ? "Long" : "Fast")}"; }, isTogglable = false, toolTip = "Changes menu delete time." },                
                new ButtonInfo { buttonText = "Boards", method =() => Visual.boards(), isTogglable = false, enabled = true, toolTip = "Enable boards, YOU CANT TURN IT OFF :)" },                
            },

            new ButtonInfo[] { // Notifications
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = true, toolTip = "Toggles the notifications."},
            },

            new ButtonInfo[] { // saftey
                new ButtonInfo { buttonText = "Flush Rpc's", method =() => Safety.flush(), isTogglable = false, toolTip = "Flushes all report calls."},
                new ButtonInfo { buttonText = "Antireport", method =() => Safety.AntiReport(), toolTip = "No One Can Report You."},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.CantMoveFingers(), toolTip = "You Cant Move Your Fingers."},
            },


            new ButtonInfo[] { // movement settings
            },

            new ButtonInfo[] { // Fun
                new ButtonInfo { buttonText = "RC Bug", method =() => Fun.RCcar()},
                new ButtonInfo { buttonText = "Voice Recognition", method =() => Voice.StartVoice(), isTogglable = false },
                new ButtonInfo { buttonText = "Voice Recognition <color=red>[OFF]</color>", method =() => Voice.StopVoice(), isTogglable = false },
                new ButtonInfo { buttonText = "Grab All Id's", method =() => Fun.GrabAllIds(), isTogglable = false, toolTip = "Grab's everyone player id's."},
                new ButtonInfo { buttonText = "Grab Id Gun", method =() => Fun.copyIDgun(), toolTip = "Grab the players id that you shot at."},
                new ButtonInfo { buttonText = "Draw", method =() => Fun.DrawRGB(), disableMethod =() => Fun.RGBDrawOFF(), toolTip = "Draw with rgb spheres."},
                new ButtonInfo { buttonText = "Hands In Head", method =() => Fun.HandsINhead(), toolTip = "Hands In Head."},
                new ButtonInfo { buttonText = "Kick All [<color=red>FAKE</color>]", method =() => Fun.kickAll(), disableMethod =() => Fun.disable(), toolTip = "Fake Kick Everyone."},
                new ButtonInfo { buttonText = "Kick Gun [<color=red>FAKE</color>]", method =() => Fun.FakeKickGun(), toolTip = "Fake Kick The Player You Shoot."},
            },

            new ButtonInfo[] { // Rig
                new ButtonInfo { buttonText = "Ghost Monkey", method =() => Rig.Ghost(), toolTip = "Become a ghost."},
                new ButtonInfo { buttonText = "Inviz Monkey", method =() => Rig.Inviz(), toolTip = "Become invisable."},
                new ButtonInfo { buttonText = "Freeze Rig", method =() => Rig.freeze(), toolTip = "Freeze your rig."},
                new ButtonInfo { buttonText = "Rig Gun", method =() => Rig.riggun(), toolTip = "Shoot your rig."},
                new ButtonInfo { buttonText = "Grab Rig", method =() => Rig.grab(), toolTip = "grab your rig."},
                new ButtonInfo { buttonText = "Helicopter <color=red>[RP]</color>", method =() => Rig.Helicopter(), toolTip = "Become a helicopter."},
                new ButtonInfo { buttonText = "Ascend <color=red>[RP]</color>", method =() => Rig.Ascend(), toolTip = "Just ascend up."},
                new ButtonInfo { buttonText = "Spin <color=red>[RP]</color>", method =() => Rig.Spin(), toolTip = "Just spin."},
                new ButtonInfo { buttonText = "Spin Slow <color=red>[RP]</color>", method =() => Rig.ItemStandThing(), toolTip = "Just spin slow."},
            },



            //always keep this at the bottom if you add another tab (by going to categories) make sure you put that section above this one:

             new ButtonInfo[] {
                 new ButtonInfo { buttonText = "Disconnect", method =() => mods.Disconnect(), isTogglable = false, toolTip = "Disconnected from lobby"},
             },
           
            new ButtonInfo[] {
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home page."},
                new ButtonInfo { buttonText = "nextpage", method =() => Main.NextPage(), isTogglable = true, enabled = true, toolTip = "Opens the home for the menu."},
                new ButtonInfo { buttonText = "lastpage", method =() => Main.PreviousPage(), isTogglable = true, enabled = true, toolTip = "Opens the home for the menu."},
            },

        };

    }
}
