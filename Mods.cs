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

            if (c > 6)
            {
                c = 0;
            }

            if (c < 0)
            {
                c = 6;
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
                Main.GetIndex("Menu Theme").overlapText = "purple";
            }

            if (c == 4)
            {
                menuColor = new Color32(30, 10, 25, 255);
                btnColor1 = new Color32(255, 105, 180, 255); // on
                btnColor2 = new Color32(219, 70, 135, 255); // off
                catButton = new Color32(219, 70, 135, 255);
                panelColor = new Color32(40, 20, 35, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "pink";
            }
            if (c == 5)
            {
                menuColor = new Color32(95, 245, 145, 255);
                btnColor1 = new Color32(152, 255, 175, 255); // on
                btnColor2 = new Color32(120, 220, 160, 255); // off
                catButton = new Color32(120, 220, 160, 255);
                panelColor = new Color32(105, 255, 155, 255);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "mint";
            }
            if (c == 6)
            {
                menuColor = new Color32(140, 10, 10, 50);
                btnColor1 = new Color32(220, 40, 40, 50); // on
                btnColor2 = new Color32(150, 20, 20, 50); // off
                catButton = new Color32(150, 20, 20, 50);
                panelColor = new Color32(145, 15, 15, 50);
                Settings.textColors[1] = Color.black;
                Main.GetIndex("Menu Theme").overlapText = "red";
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


        public static void GunTemplate(System.Action action, System.Action disableAction, bool enableRig = false) // came with this template, W
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitinfo))
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out hitinfo, 100);
                    }

                    if (GunSphere == null)
                    {
                        GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GunSphere.transform.localScale = isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f);
                        GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                        GameObject.Destroy(GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(GunSphere.GetComponent<Collider>());

                        lineRenderer = GunSphere.AddComponent<LineRenderer>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);
                        lineRenderer.startColor = currentGunColor.color;
                        lineRenderer.endColor = currentGunColor.color;

                        linePositions = new Vector3[50];
                        for (int i = 0; i < linePositions.Length; i++)
                        {
                            linePositions[i] = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                        }
                    }

                    GunSphere.transform.position = hitinfo.point;

                    timeCounter += Time.deltaTime;

                    Vector3 pos1 = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    Vector3 direction = (hitinfo.point - pos1).normalized;
                    float distance = Vector3.Distance(pos1, hitinfo.point);

                    Vector3 controller = pos1 - previousControllerPosition;
                    previousControllerPosition = pos1;

                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        mods.lineRenderer.startColor = Color.blue;
                        mods.lineRenderer.endColor = Color.blue;
                        mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        mods.GunSphere.GetComponent<Renderer>().material.color = Color.blue;
                        action.Invoke();
                    }
                    else
                    {
                        GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                        lineRenderer.startColor = currentGunColor.color;
                        lineRenderer.endColor = currentGunColor.color;
                        if (enableRig)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                        else
                        {
                            disableAction.Invoke();
                        }
                    }

                    for (int i = 0; i < linePositions.Length; i++)
                    {
                        float t = i / (float)(linePositions.Length - 1);
                        Vector3 linePos = Vector3.Lerp(pos1, hitinfo.point, t);

                        linePositions[i] += controller * 0.5f;
                        linePositions[i] += UnityEngine.Random.insideUnitSphere * 0.01f;
                        linePositions[i] = Vector3.Lerp(linePositions[i], linePos, Time.deltaTime * num);
                    }

                    lineRenderer.positionCount = linePositions.Length;
                    lineRenderer.SetPositions(linePositions);                    
                }
            }

            if (GunSphere != null && (ControllerInputPoller.instance.rightControllerGripFloat <= 0.1f && !UnityInput.Current.GetMouseButton(1)))
            {
                GameObject.Destroy(GunSphere);
                GameObject.Destroy(lineRenderer);
                timeCounter = 0f;
                linePositions = null;
            }
        }
        public static void Gun() // came with this template, W
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitinfo))
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out hitinfo, 100);
                    }

                    if (GunSphere == null)
                    {
                        GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GunSphere.transform.localScale = isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f);
                        GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                        GameObject.Destroy(GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(GunSphere.GetComponent<Collider>());

                        lineRenderer = GunSphere.AddComponent<LineRenderer>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);
                        lineRenderer.startColor = currentGunColor.color;
                        lineRenderer.endColor = currentGunColor.color;

                        linePositions = new Vector3[50];
                        for (int i = 0; i < linePositions.Length; i++)
                        {
                            linePositions[i] = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                        }
                    }

                    GunSphere.transform.position = hitinfo.point;

                    timeCounter += Time.deltaTime;

                    Vector3 pos1 = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    Vector3 direction = (hitinfo.point - pos1).normalized;
                    float distance = Vector3.Distance(pos1, hitinfo.point);

                    Vector3 controller = pos1 - previousControllerPosition;
                    previousControllerPosition = pos1;

                    for (int i = 0; i < linePositions.Length; i++)
                    {
                        float t = i / (float)(linePositions.Length - 1);
                        Vector3 linePos = Vector3.Lerp(pos1, hitinfo.point, t);

                        linePositions[i] += controller * 0.5f;
                        linePositions[i] += UnityEngine.Random.insideUnitSphere * 0.01f;
                        linePositions[i] = Vector3.Lerp(linePositions[i], linePos, Time.deltaTime * num);
                    }

                    lineRenderer.positionCount = linePositions.Length;
                    lineRenderer.SetPositions(linePositions);

                    GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                    lineRenderer.startColor = currentGunColor.color;
                    lineRenderer.endColor = currentGunColor.color;
                }
            }

            if (GunSphere != null && (ControllerInputPoller.instance.rightControllerGripFloat <= 0.1f && !UnityInput.Current.GetMouseButton(1)))
            {
                GameObject.Destroy(GunSphere);
                GameObject.Destroy(lineRenderer);
                timeCounter = 0f;
                linePositions = null;
            }
        }

        public static VRRig lockon;
        public static VRRig rigg;


        public static void GunTemplateLockon(System.Action action, System.Action disableAction, bool enableRig = false)
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitinfo))
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out hitinfo, 100);
                    }

                    if (mods.GunSphere == null)
                    {
                        mods.GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        mods.GunSphere.transform.localScale = mods.isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f);
                        mods.GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        mods.GunSphere.GetComponent<Renderer>().material.color = mods.currentGunColor.color;
                        GameObject.Destroy(mods.GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(mods.GunSphere.GetComponent<Collider>());

                        mods.lineRenderer = mods.GunSphere.AddComponent<LineRenderer>();
                        mods.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        mods.lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);
                        mods.lineRenderer.startColor = mods.currentGunColor.color;
                        mods.lineRenderer.endColor = mods.currentGunColor.color;

                        mods.linePositions = new Vector3[50];
                        for (int i = 0; i < mods.linePositions.Length; i++)
                        {
                            mods.linePositions[i] = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                        }
                    }

                    mods.GunSphere.transform.position = hitinfo.point;

                    mods.timeCounter += Time.deltaTime;

                    Vector3 pos1 = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    Vector3 direction = (hitinfo.point - pos1).normalized;
                    float distance = Vector3.Distance(pos1, hitinfo.point);

                    Vector3 controller = pos1 - mods.previousControllerPosition;
                    mods.previousControllerPosition = pos1;

                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        Collider collider2 = hitinfo.collider;
                        rigg = ((collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null);
                        if (lockon == null)
                        {
                            lockon = rigg;
                        }
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
                        GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                        lineRenderer.startColor = currentGunColor.color;
                        lineRenderer.endColor = currentGunColor.color;
                        lockon = null;
                        if (disableAction != null)
                        {
                            disableAction.Invoke();
                        }
                        if (enableRig)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    }

                    for (int i = 0; i < mods.linePositions.Length; i++)
                    {
                        float t = i / (float)(mods.linePositions.Length - 1);
                        Vector3 linePos = Vector3.Lerp(pos1, hitinfo.point, t);

                        mods.linePositions[i] += controller * 0.5f;
                        mods.linePositions[i] += UnityEngine.Random.insideUnitSphere * 0.01f;
                        mods.linePositions[i] = Vector3.Lerp(mods.linePositions[i], linePos, Time.deltaTime * mods.num);
                    }

                    mods.lineRenderer.positionCount = mods.linePositions.Length;
                    mods.lineRenderer.SetPositions(mods.linePositions);
                }
            }

            if (mods.GunSphere != null && (ControllerInputPoller.instance.rightControllerGripFloat <= 0.1f && !UnityInput.Current.GetMouseButton(1)))
            {
                GameObject.Destroy(mods.GunSphere);
                GameObject.Destroy(mods.lineRenderer);
                mods.timeCounter = 0f;
                mods.linePositions = null;
            }
        }

    }
}
