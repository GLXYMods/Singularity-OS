using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using StupidTemplate.Notifications;
using ExitGames.Client.Photon;
using Photon.Realtime;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Animations.Rigging;
using AetherTemp.Menu;
using System.Text.RegularExpressions;
using StupidTemplate.Patches;
using System.Reflection;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Buffers.Text;
using Valve.VR;
using GorillaTagScripts;
using System.Net;
using static StupidTemplate.Menu.Main;
using Singularity_OS.Patches;

namespace StupidTemplate.Menu
{
    public class mods
    {

        



        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static int c = 0;

        public static void ChangeMenuTheme()
        {
            c++;

            if (c > 31)
            {
                c = 0;
            }

            if (c < 0)
            {
                c = 31;
            }


            if (c == 0)
            {
                menuColor = new Color32(10, 10, 10, 255);
                btnColor1 = new Color32(30, 30, 30, 255); // on
                btnColor2 = new Color32(25, 25, 25, 25); // off
                catButton = new Color32(15, 15, 15, 255);
                panelColor = new Color32(20, 20, 20, 255);
                Settings.textColors[1] = Color.green;
                Main.GetIndex("Menu Theme").overlapText = "Main Theme";
            }

            if (c == 1)
            {
                menuColor = new Color32(20, 30, 45, 255);
                btnColor1 = new Color32(135, 206, 250, 255); // on
                btnColor2 = new Color32(100, 149, 237, 255); // off
                catButton = new Color32(100, 149, 237, 255);
                panelColor = new Color32(35, 45, 60, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Sky Blue";
            }

            if (c == 2)
            {
                menuColor = new Color32(30, 20, 10, 255);
                btnColor1 = new Color32(255, 165, 0, 255); // on
                btnColor2 = new Color32(255, 140, 0, 255); // off
                catButton = new Color32(255, 140, 0, 255);
                panelColor = new Color32(45, 35, 25, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Orange";
            }

            if (c == 3)
            {
                menuColor = new Color32(25, 15, 40, 255);
                btnColor1 = new Color32(170, 0, 255, 255); // on
                btnColor2 = new Color32(110, 0, 180, 255); // off
                catButton = new Color32(110, 0, 180, 255);
                panelColor = new Color32(30, 20, 45, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Purple";
            }

            if (c == 4)
            {
                menuColor = new Color32(30, 10, 25, 255);
                btnColor1 = new Color32(255, 105, 180, 255); // on
                btnColor2 = new Color32(219, 70, 135, 255); // off
                catButton = new Color32(219, 70, 135, 255);
                panelColor = new Color32(40, 20, 35, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Pink";
            }
            if (c == 5)
            {
                menuColor = new Color32(95, 245, 145, 255);
                btnColor1 = new Color32(152, 255, 175, 255); // on
                btnColor2 = new Color32(120, 220, 160, 255); // off
                catButton = new Color32(120, 220, 160, 255);
                panelColor = new Color32(105, 255, 155, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Mint";
            }
            if (c == 6)
            {
                menuColor = new Color32(140, 10, 10, 50);
                btnColor1 = new Color32(220, 40, 40, 50); // on
                btnColor2 = new Color32(150, 20, 20, 50); // off
                catButton = new Color32(150, 20, 20, 50);
                panelColor = new Color32(145, 15, 15, 50);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Red";
            }
            if (c == 7)
            {
                menuColor = new Color32(15, 20, 10, 255);
                btnColor1 = new Color32(0, 255, 0, 255);
                btnColor2 = new Color32(50, 100, 50, 255);
                catButton = new Color32(100, 255, 100, 255);
                panelColor = new Color32(25, 35, 20, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Toxic";
            }
            if (c == 8)
            {
                menuColor = new Color32(255, 220, 245, 255);
                btnColor1 = new Color32(255, 170, 255, 255);
                btnColor2 = new Color32(170, 200, 255, 255);
                catButton = new Color32(200, 180, 255, 255);
                panelColor = new Color32(245, 200, 230, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Cotton Candy";
            }
            if (c == 9)
            {
                menuColor = new Color32(30, 0, 0, 255);
                btnColor1 = new Color32(255, 87, 34, 255);
                btnColor2 = new Color32(180, 40, 30, 255);
                catButton = new Color32(255, 111, 0, 255);
                panelColor = new Color32(50, 15, 10, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Inferno";
            }
            if (c == 10)
            {
                menuColor = new Color32(18, 18, 18, 255);
                btnColor1 = new Color32(70, 70, 70, 255);
                btnColor2 = new Color32(45, 45, 45, 255);
                catButton = new Color32(90, 90, 90, 255);
                panelColor = new Color32(28, 28, 28, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Slate";
            }
            if (c == 11)
            {
                menuColor = new Color32(0, 30, 40, 255);
                btnColor1 = new Color32(0, 255, 255, 255);
                btnColor2 = new Color32(0, 200, 200, 255);
                catButton = new Color32(0, 220, 220, 255);
                panelColor = new Color32(10, 50, 60, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Aqua";
            }
            if (c == 12)
            {
                menuColor = new Color32(200, 235, 255, 255);
                btnColor1 = new Color32(0, 150, 255, 255);
                btnColor2 = new Color32(0, 120, 200, 255);
                catButton = new Color32(0, 170, 255, 255);
                panelColor = new Color32(180, 225, 255, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Arctic";
            }
            if (c == 13)
            {
                menuColor = new Color32(40, 10, 30, 255);
                btnColor1 = new Color32(255, 140, 105, 255);
                btnColor2 = new Color32(255, 105, 180, 255);
                catButton = new Color32(255, 160, 122, 255);
                panelColor = new Color32(60, 20, 40, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Sunset";
            }
            if (c == 14)
            {
                menuColor = new Color32(25, 0, 0, 255);
                btnColor1 = new Color32(200, 0, 0, 255);
                btnColor2 = new Color32(120, 0, 0, 255);
                catButton = new Color32(180, 20, 20, 255);
                panelColor = new Color32(40, 5, 5, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Blood";
            }
            if (c == 15)
            {
                menuColor = new Color32(30, 5, 0, 255);
                btnColor1 = new Color32(255, 80, 0, 255);
                btnColor2 = new Color32(180, 30, 0, 255);
                catButton = new Color32(255, 100, 50, 255);
                panelColor = new Color32(45, 10, 5, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Lava";
            }
            if (c == 16)
            {
                menuColor = new Color32(25, 20, 5, 255);
                btnColor1 = new Color32(255, 215, 0, 255);
                btnColor2 = new Color32(180, 140, 0, 255);
                catButton = new Color32(220, 180, 50, 255);
                panelColor = new Color32(45, 35, 10, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Gold";
            }
            if (c == 17)
            {
                menuColor = new Color32(25, 0, 40, 255);
                btnColor1 = new Color32(180, 0, 255, 255);
                btnColor2 = new Color32(100, 0, 180, 255);
                catButton = new Color32(150, 0, 220, 255);
                panelColor = new Color32(35, 5, 60, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Violet";
            }
            if (c == 18)
            {
                menuColor = new Color32(5, 20, 0, 255);
                btnColor1 = new Color32(150, 255, 0, 255);
                btnColor2 = new Color32(100, 180, 0, 255);
                catButton = new Color32(120, 220, 30, 255);
                panelColor = new Color32(20, 40, 10, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Radioactive";
            }
            if (c == 19)
            {
                menuColor = new Color32(10, 0, 20, 255);
                btnColor1 = new Color32(120, 255, 220, 255);
                btnColor2 = new Color32(90, 200, 180, 255);
                catButton = new Color32(140, 255, 240, 255);
                panelColor = new Color32(20, 5, 40, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Aurora";
            }
            if (c == 20)
            {
                menuColor = new Color32(10, 10, 25, 255);
                btnColor1 = new Color32(0, 255, 170, 255);
                btnColor2 = new Color32(0, 170, 120, 255);
                catButton = new Color32(0, 200, 180, 255);
                panelColor = new Color32(20, 20, 40, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Cyber";
            }
            if (c == 21)
            {
                menuColor = new Color32(45, 10, 0, 255);
                btnColor1 = new Color32(255, 120, 0, 255);
                btnColor2 = new Color32(200, 90, 0, 255);
                catButton = new Color32(255, 160, 40, 255);
                panelColor = new Color32(60, 20, 5, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Solar";
            }
            if (c == 22)
            {
                menuColor = new Color32(245, 225, 255, 255);
                btnColor1 = new Color32(255, 150, 200, 255);
                btnColor2 = new Color32(200, 120, 180, 255);
                catButton = new Color32(255, 180, 230, 255);
                panelColor = new Color32(255, 240, 255, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "Pastel";
            }
            if (c == 23)
            {
                menuColor = new Color32(5, 0, 10, 255);
                btnColor1 = new Color32(120, 0, 255, 255);
                btnColor2 = new Color32(80, 0, 180, 255);
                catButton = new Color32(150, 50, 255, 255);
                panelColor = new Color32(10, 0, 20, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Void";
            }
            if (c == 24)
            {
                menuColor = new Color32(10, 25, 35, 255);
                btnColor1 = new Color32(0, 180, 255, 255);
                btnColor2 = new Color32(0, 120, 200, 255);
                catButton = new Color32(0, 210, 255, 255);
                panelColor = new Color32(20, 40, 60, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Ocean";
            }
            if (c == 25)
            {
                menuColor = new Color32(10, 0, 0, 255);
                btnColor1 = new Color32(255, 60, 60, 255);
                btnColor2 = new Color32(180, 40, 40, 255);
                catButton = new Color32(255, 90, 90, 255);
                panelColor = new Color32(20, 10, 10, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Midnight";
            }
            if (c == 26)
            {
                menuColor = new Color32(15, 0, 0, 255);
                btnColor1 = new Color32(255, 45, 85, 255);
                btnColor2 = new Color32(200, 30, 60, 255);
                catButton = new Color32(255, 70, 110, 255);
                panelColor = new Color32(30, 5, 5, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Blood V2";
            }
            if (c == 27)
            {
                menuColor = new Color32(25, 0, 0, 255);
                btnColor1 = new Color32(180, 20, 20, 255);
                btnColor2 = new Color32(120, 0, 0, 255);
                catButton = new Color32(210, 40, 40, 255);
                panelColor = new Color32(40, 10, 10, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Crimson";
            }
            if (c == 28)
            {
                menuColor = new Color32(10, 0, 30, 255);
                btnColor1 = new Color32(0, 255, 180, 255);
                btnColor2 = new Color32(0, 200, 130, 255);
                catButton = new Color32(40, 255, 200, 255);
                panelColor = new Color32(15, 0, 40, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Plasma";
            }
            if (c == 29)
            {
                menuColor = new Color32(2, 2, 2, 255);
                btnColor1 = new Color32(8, 8, 8, 255);
                btnColor2 = new Color32(4, 4, 4, 255);
                catButton = new Color32(12, 12, 12, 255);
                panelColor = new Color32(3, 3, 3, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Shadow";
            }
            if (c == 30)
            {
                menuColor = new Color32(10, 10, 15, 255);
                btnColor1 = new Color32(0, 150, 210, 255);
                btnColor2 = new Color32(0, 100, 140, 255);
                catButton = new Color32(20, 180, 230, 255);
                panelColor = new Color32(15, 15, 20, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Black Ice";
            }
            if (c == 31)
            {
                menuColor = new Color32(15, 5, 5, 255);
                btnColor1 = new Color32(255, 85, 140, 255);
                btnColor2 = new Color32(200, 60, 100, 255);
                catButton = new Color32(255, 110, 160, 255);
                panelColor = new Color32(40, 15, 20, 255);
                Settings.textColors[1] = Color.white;
                Main.GetIndex("Menu Theme").overlapText = "Phantom Blaze";
            }
        }

        public static int btn = 0;

        public static void changeBtnSound()
        {
            btn++;
            if (btn > 13)
            {
                btn = 0;
            }
            if (btn < 0)
            {
                btn = 13;
            }

            if (btn == 0)
            {
                sound1 = true;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 1)
            {
                sound1 = false;
                sound2 = true;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 2)
            {
                sound1 = false;
                sound2 = false;
                sound3 = true;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 3)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = true;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 4)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = true;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 5)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = true;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 6)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = true;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 7)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = true;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 8)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = true;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 9)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = true;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 10)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = true;
                sound12 = false;
                sound13 = false;
                sound14 = false;

            }
            if (btn == 11)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = true;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 12)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = true;
                sound14 = false;
            }
            if (btn == 13)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = true;
            }
        }





        public static Color32 Darknavy = new Color32(26, 26, 46, 255);   // Dark navy
        public static Color32 Coolblue = new Color32(15, 52, 96, 255); // Coolblue
        public static Color32 Darkpurple = new Color32(83, 53, 74, 255);  // Deeppurple
        public static Color32 Hotpink = new Color32(233, 69, 96, 255);// Hotpink
        public static Color32 Lightgray = new Color32(238, 238, 238, 255); // Lightgray
        public static Color32 Brightpink = new Color32(255, 110, 199, 255);    // Brightpink

        public static Color32 Deeppurple = new Color32(11, 12, 42, 255);      // Deeppurple
        public static Color32 Blue = new Color32(30, 42, 120, 255);   // Blue
        public static Color32 Lightblue = new Color32(90, 134, 255, 255);  // Lightblue

        public static Color32 Black = new Color32(0, 0, 0, 255);
        public static Color32 DarkGreen = new Color32(0, 51, 0, 255);
        public static Color32 MidGreen = new Color32(0, 77, 0, 255);
        public static Color32 BrightGreen = new Color32(0, 204, 0, 255);
        public static Color32 NeonGreen = new Color32(0, 255, 0, 255);
        public static Color32 teal = new Color32(0, 255, 136, 255);








        public static void EnableTrail(bool enable)
        {
            if (Main.trailObject != null)
            {
                Main.trailObject.SetActive(enable);
            }
        }



        public static GameObject GunSphere;
        public static LineRenderer lineRenderer;
        public static float timeCounter = 0f;
        public static Vector3[] linePositions;
        public static Vector3 previousControllerPosition;

        public static float num = 10f;

        public static void GunSmoothNess()
        {
            if (num == 10f)
                num = 15f;
            else if (num == 15f)
                num = 5f;
            else
                num = 10f;
        }

        public static List<(Color color, string name)> colorCycle = new List<(Color, string)>
{
    (new Color(189f / 255f, 251f / 255f, 204f / 255f), "mint"),
    (new Color(255f / 255f, 229f / 255f, 180f / 255f), "peach"),
    (new Color(134f / 255f, 169f / 255f, 188f / 255f), "dustyBlue"),
    (new Color(200f / 255f, 162f / 255f, 200f / 255f), "lilac"),
    (new Color(255f / 255f, 255f / 255f, 204f / 255f), "paleYellow"),
    (new Color(255f / 255f, 182f / 255f, 193f / 255f), "softPink"),
    (new Color(230f / 255f, 230f / 255f, 250f / 255f), "lavender"),
    (new Color(211f / 255f, 211f / 255f, 211f / 255f), "lightGray"),
    (new Color(169f / 255f, 169f / 255f, 169f / 255f), "warmGray"),
    (new Color(255f / 255f, 255f / 255f, 240f / 255f), "ivory"),
    (new Color(245f / 255f, 240f / 255f, 195f / 255f), "beige"),
    (new Color(128f / 255f, 128f / 255f, 0f / 255f), "olive"),
    (new Color(210f / 255f, 180f / 255f, 140f / 255f), "tan"),
    (new Color(133f / 255f, 153f / 255f, 56f / 255f), "mossGreen"),
    (new Color(194f / 255f, 178f / 255f, 128f / 255f), "sand"),
    (new Color(176f / 255f, 153f / 255f, 128f / 255f), "maincolor")
};

        public static (Color color, string name) currentGunColor = colorCycle[0];

        public static void CycleGunColor()
        {
            int currentIndex = colorCycle.IndexOf(currentGunColor);
            currentGunColor = colorCycle[(currentIndex + 1) % colorCycle.Count];
        }

        public static bool isSphereEnabled = true;


        public static void Gun() // friend helped :)
        {
            bool gripActive = ControllerInputPoller.instance.rightControllerGripFloat > 0.1f;
            bool mouseRight = UnityInput.Current.GetMouseButton(1);

            if (gripActive || mouseRight)
            {
                Vector3 origin;
                Vector3 dir;
                Vector3 startPos;

                if (mouseRight)
                {
                    Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                    Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                    origin = ray.origin;
                    dir = ray.direction.normalized;
                    startPos = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 0.25f;
                }
                else
                {
                    origin = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    dir = -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up;
                    startPos = origin;
                }

                if (Physics.Raycast(origin, dir, out var hitinfo, 100f))
                {
                    if (mods.GunSphere == null)
                    {
                        mods.GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        mods.GunSphere.transform.localScale = mods.isSphereEnabled ? Vector3.one * 0.1f : Vector3.zero;
                        var renderer = mods.GunSphere.GetComponent<Renderer>();
                        renderer.material.shader = Shader.Find("GorillaTag/UberShader");
                        renderer.material.color = mods.currentGunColor.color;
                        GameObject.Destroy(mods.GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Collider>());
                        mods.lineRenderer = mods.GunSphere.AddComponent<LineRenderer>();
                        mods.lineRenderer.material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.lineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.01f);
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;
                        mods.linePositions = new Vector3[60];
                    }
                    mods.GunSphere.transform.position = hitinfo.point;
                    Vector3 endPos = hitinfo.point;
                    Vector3 forward = (endPos - startPos).normalized;
                    float length = Vector3.Distance(startPos, endPos);
                    Vector3 axis1 = Vector3.Cross(forward, Vector3.up);
                    if (axis1.sqrMagnitude < 0.01f) axis1 = Vector3.Cross(forward, Vector3.forward);
                    axis1.Normalize();
                    Vector3 axis2 = Vector3.Cross(forward, axis1).normalized;
                    float coils = 2000f;
                    float radius = 0.2f;
                    float speed = Time.time * 15f;
                    for (int i = 0; i < mods.linePositions.Length; i++)
                    {
                        float t = i / (float)(mods.linePositions.Length - 1);
                        Vector3 pointAlong = startPos + forward * (t * length);
                        float angle = coils * 2 * Mathf.PI * t + speed;
                        Vector3 coilOffset = Mathf.Cos(angle) * axis1 * radius + Mathf.Sin(angle) * axis2 * radius;
                        mods.linePositions[i] = pointAlong + coilOffset;
                    }
                    mods.lineRenderer.positionCount = mods.linePositions.Length;
                    mods.lineRenderer.SetPositions(mods.linePositions);
                    mods.GunSphere.GetComponent<Renderer>().material.color = mods.currentGunColor.color;
                    mods.lineRenderer.startColor = mods.currentGunColor.color;
                    mods.lineRenderer.endColor = mods.currentGunColor.color;
                }
            }
            else if (mods.GunSphere != null)
            {
                GameObject.Destroy(mods.GunSphere);
                GameObject.Destroy(mods.lineRenderer);
                mods.linePositions = null;
            }
        }

        public static VRRig rigg;
        public static VRRig lockon;
        public static void GunTemplateLockon(System.Action action, System.Action disableAction, bool enableRig = false) // friend helped :)
        {
            bool gripActive = ControllerInputPoller.instance.rightControllerGripFloat > 0.1f;
            bool mouseRight = UnityInput.Current.GetMouseButton(1);

            if (gripActive || mouseRight)
            {
                Vector3 origin;
                Vector3 dir;
                Vector3 startPos;

                if (mouseRight)
                {
                    Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                    Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                    origin = ray.origin;
                    dir = ray.direction.normalized;
                    startPos = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 0.25f;
                }
                else
                {
                    origin = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    dir = -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up;
                    startPos = origin;
                }

                if (Physics.Raycast(origin, dir, out var hitinfo, 100f))
                {
                    if (mods.GunSphere == null)
                    {
                        mods.GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        mods.GunSphere.transform.localScale = mods.isSphereEnabled ? Vector3.one * 0.1f : Vector3.zero;
                        var renderer = mods.GunSphere.GetComponent<Renderer>();
                        renderer.material.shader = Shader.Find("GorillaTag/UberShader");
                        renderer.material.color = mods.currentGunColor.color;
                        GameObject.Destroy(mods.GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Collider>());
                        mods.lineRenderer = mods.GunSphere.AddComponent<LineRenderer>();
                        mods.lineRenderer.material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.lineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.01f);
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;
                        mods.linePositions = new Vector3[60];
                    }
                    mods.GunSphere.transform.position = hitinfo.point;
                    Vector3 endPos = hitinfo.point;
                    Vector3 direction = (endPos - startPos).normalized;
                    float length = Vector3.Distance(startPos, endPos);
                    Vector3 axis1 = Vector3.Cross(direction, Vector3.up);
                    if (axis1.sqrMagnitude < 0.01f)
                        axis1 = Vector3.Cross(direction, Vector3.forward);
                    axis1.Normalize();
                    Vector3 axis2 = Vector3.Cross(direction, axis1).normalized;
                    int segments = mods.linePositions.Length;
                    float coils = 2000f;
                    float radius = 0.2f;
                    float speed = Time.time * 15f;
                    for (int i = 0; i < segments; i++)
                    {
                        float t = i / (float)(segments - 1);
                        Vector3 pointAlong = startPos + direction * (t * length);
                        float angle = coils * 2 * Mathf.PI * t + speed;
                        Vector3 offset = Mathf.Cos(angle) * axis1 * radius + Mathf.Sin(angle) * axis2 * radius;
                        mods.linePositions[i] = pointAlong + offset;
                    }
                    mods.lineRenderer.positionCount = segments;
                    mods.lineRenderer.SetPositions(mods.linePositions);

                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        Collider collider2 = hitinfo.collider;
                        rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                        if (lockon == null)
                            lockon = rigg;
                        else
                        {
                            mods.lineRenderer.startColor = Color.blue;
                            mods.lineRenderer.endColor = Color.blue;
                            mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            mods.GunSphere.GetComponent<Renderer>().material.color = Color.blue;
                            mods.GunSphere.transform.position = lockon.transform.position;
                            mods.lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                            mods.lineRenderer.SetPosition(1, lockon.transform.position);
                            action.Invoke();
                        }
                    }
                    else
                    {
                        mods.GunSphere.GetComponent<Renderer>().material.color = mods.currentGunColor.color;
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;
                        lockon = null;
                        if (disableAction != null)
                            disableAction.Invoke();
                        if (enableRig)
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
            else if (mods.GunSphere != null)
            {
                GameObject.Destroy(mods.GunSphere);
                GameObject.Destroy(mods.lineRenderer);
                mods.linePositions = null;
                lockon = null;
            }
        }

        public static void GunTemplate(System.Action action, System.Action disableAction, bool enableRig = false) // friend helped :)
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                Vector3 origin;
                Vector3 dir;
                Vector3 startPos;
                Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                if (UnityInput.Current.GetMouseButton(1))
                {
                    Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                    origin = ray.origin;
                    dir = ray.direction.normalized;
                    startPos = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 0.25f;
                }
                else
                {
                    origin = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    dir = -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up;
                    startPos = origin;
                }
                if (Physics.Raycast(origin, dir, out var hitinfo, 100f))
                {
                    if (mods.GunSphere == null)
                    {
                        mods.GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        mods.GunSphere.transform.localScale = mods.isSphereEnabled ? Vector3.one * 0.1f : Vector3.zero;
                        mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.GunSphere.GetComponent<Renderer>().material.color = mods.currentGunColor.color;
                        GameObject.Destroy(mods.GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Collider>());
                        mods.lineRenderer = mods.GunSphere.AddComponent<LineRenderer>();
                        mods.lineRenderer.material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.lineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.01f);
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;
                        mods.linePositions = new Vector3[60];
                    }
                    Vector3 endPos = hitinfo.point;
                    mods.GunSphere.transform.position = endPos;
                    Vector3 forward = (endPos - startPos).normalized;
                    float length = Vector3.Distance(startPos, endPos);
                    Vector3 axis1 = Vector3.Cross(forward, Vector3.up);
                    if (axis1.sqrMagnitude < 0.01f) axis1 = Vector3.Cross(forward, Vector3.forward);
                    axis1.Normalize();
                    Vector3 axis2 = Vector3.Cross(forward, axis1).normalized;
                    float coils = 2000f;
                    float radius = 0.2f;
                    float speed = Time.time * 15f;
                    for (int i = 0; i < mods.linePositions.Length; i++)
                    {
                        float t = i / (float)(mods.linePositions.Length - 1);
                        Vector3 pointAlong = startPos + forward * (t * length);
                        float angle = coils * 2 * Mathf.PI * t + speed;
                        Vector3 coilOffset = Mathf.Cos(angle) * axis1 * radius + Mathf.Sin(angle) * axis2 * radius;
                        mods.linePositions[i] = pointAlong + coilOffset;
                    }
                    mods.lineRenderer.positionCount = mods.linePositions.Length;
                    mods.lineRenderer.SetPositions(mods.linePositions);
                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        mods.GunSphere.GetComponent<Renderer>().material.color = Color.blue;
                        mods.lineRenderer.startColor = Color.blue;
                        mods.lineRenderer.endColor = Color.blue;
                        action.Invoke();
                    }
                    else
                    {
                        mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.GunSphere.GetComponent<Renderer>().material.color = mods.currentGunColor.color;
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;
                        disableAction.Invoke();
                        if (enableRig)
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
            else if (mods.GunSphere != null)
            {
                GameObject.Destroy(mods.GunSphere);
                GameObject.Destroy(mods.lineRenderer);
                mods.linePositions = null;
            }
        }

    }
}
