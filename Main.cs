using AetherTemp.Menu;
using BepInEx;
using HarmonyLib;
using Photon.Pun;
using Singularity_OS.Classes;
using Singularity_OS.Menu;
using Singularity_OS.UmThisIsTheCameraShit;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;
using static AetherTemp.Menu.Buttons;
using static StupidTemplate.Settings;
using Object = UnityEngine.Object;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        public static AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
        public static void Arraylst(bool on)
        {
            if (on)
                Singularity_OS.Menu.ArrayList._array = true;
            if (!on)
                Singularity_OS.Menu.ArrayList._array = false;
        }

        public static async void LoadSoundFromURL(string url)
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
            {
                UnityWebRequestAsyncOperation unityWebRequest2 = unityWebRequest.SendWebRequest();
                while (!unityWebRequest2.isDone)
                {
                    await Task.Yield();
                }
                if (unityWebRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load because: " + unityWebRequest.error);
                }
                else
                {
                    AudioClip audioClip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                    if (audioClip == null)
                    {
                        Debug.LogError("Downloaded audio is null for whatever reason :)");
                        return;
                    }
                    AudioSource audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    Object.Destroy(audioSource.gameObject, audioClip.length);
                }
            }
        }

        public static void Save()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            Directory.CreateDirectory("SingularityOS");
            File.WriteAllLines("SingularityOS\\Mods.txt", list);
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Mods!");
        }
        public static void SaveSettings()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            Directory.CreateDirectory("SingularityOS");
            File.WriteAllLines("SingularityOS\\Settings.txt", list);
            string text4 = string.Concat(new string[]
            {
               mods.c.ToString(),
               "\n",
               mods.btn.ToString(),
               "\n",
                Visual.d.ToString(),
               "\n",
            });
            File.WriteAllText("SingularityOS\\Settings.txt", text4.ToString());
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Settings!");
        }

        public static void LoadSettings()
        {
            string[] array = File.ReadAllLines("SingularityOS\\Settings.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo[] button in Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText == b)
                        {
                            button2.enabled = button2.isTogglable;
                        }
                    }
                }
            }
            try
            {
                string text3 = File.ReadAllText("SingularityOS\\Settings.txt");
                string[] array4 = text3.Split(new string[] { "\n" }, StringSplitOptions.None);
                mods.c = int.Parse(array4[0]) - 1;
                mods.ChangeMenuTheme();
                mods.btn = int.Parse(array4[1]) - 1;
                mods.changeBtnSound();
                Visual.d = int.Parse(array4[2]) - 1;
                Visual.ChangeEspColor();
            }
            catch { /* skibidi sigma rizz :) */ }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Settings!");
        }

        public static void Load()
        {
            String[] thing = File.ReadAllLines("SingularityOS\\Mods.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo[] button in Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText + button2.overlapText == thing2)
                        {
                            button2.enabled = true;
                        }
                    }
                }
            }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Mods!");
        }


        public static bool sound1 = true;
        public static bool sound2 = false;
        public static bool sound3 = false;
        public static bool sound4 = false;
        public static bool sound5 = false;
        public static bool sound6 = false;
        public static bool sound7 = false;
        public static bool sound8 = false;
        public static bool sound9 = false;
        public static bool sound10 = false;
        public static bool sound11 = false;
        public static bool sound12 = false;
        public static bool sound13 = false;
        public static bool sound14 = false;




        // Constant
        public static float num = 1f;

        public static void MenuDeleteTime()
        {
            if (num == 1f)
                num = 5f; // Long
            else if (num == 5f)
                num = 0.01f; // Fast
            else
                num = 1f; // Default
        }

        public static void menuAnimations(bool on)
        {
            if (on)
                MenuAnimations = true;
            else if (!on)
                MenuAnimations = false;
        }

        public static bool menuToggled = false;
        public static bool MenuAnimations = false;
        public static bool animating = false;
        public static bool poppedIn = false;
        public static bool menuOpen = false;
        public static float animationDuration = 0.3f;
        public static float animationTimer = 0f;
        public static Vector3 start;
        public static Vector3 end;

        public static void Prefix()
        {
            try
            {
                bool toggle = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);
                bool inputHeld = toggle || keyboardOpen;

                menuToggled = inputHeld;

                if (menu == null)
                {
                    if (menuToggled)
                    {
                        CreateMenu();
                        if (!keyboardOpen)
                        {
                            Transform hand = rightHanded ? GorillaLocomotion.GTPlayer.Instance.rightControllerTransform : GorillaLocomotion.GTPlayer.Instance.leftControllerTransform;
                            menu.transform.position = hand.position + hand.forward * 0.05f;
                            menu.transform.rotation = hand.rotation;
                        }

                        if (reference == null)
                            CreateReference(rightHanded);

                        if (MenuAnimations)
                        {
                            menu.transform.localScale = Vector3.zero;
                            menu.SetActive(true);
                            start = Vector3.zero;
                            end = new Vector3(0.1f, 0.3f, 0.3825f);
                            animating = true;
                            poppedIn = true;
                            animationTimer = 0f;
                        }
                        else
                        {
                            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
                            menu.SetActive(true);
                            menuOpen = true;
                        }
                    }
                }
                else
                {
                    if (menuToggled)
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else if (!animating)
                    {
                        if (MenuAnimations)
                        {
                            start = menu.transform.localScale;
                            end = Vector3.zero;
                            animating = true;
                            poppedIn = false;
                            animationTimer = 0f;
                        }
                        else
                        {
                            GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);
                            Rigidbody comp = menu.AddComponent<Rigidbody>();
                            if (!keyboardOpen)
                            {
                                comp.velocity = rightHanded ? GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0) : GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            UnityEngine.Object.Destroy(menu, num);
                            menu = null;
                            menuOpen = false;
                            if (reference != null)
                            {
                                UnityEngine.Object.Destroy(reference);
                                reference = null;
                            }
                        }
                    }
                }

                if (animating && menu != null)
                {
                    animationTimer += Time.deltaTime;
                    float t = Mathf.Clamp01(animationTimer / animationDuration);
                    menu.transform.localScale = Vector3.Lerp(start, end, t);
                    if (t >= 1f)
                    {
                        animating = false;
                        if (!poppedIn)
                        {
                            GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);
                            Rigidbody comp = menu.AddComponent<Rigidbody>();
                            if (!keyboardOpen)
                            {
                                comp.velocity = rightHanded ? GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0) : GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            UnityEngine.Object.Destroy(menu, num);
                            menu = null;
                            if (reference != null)
                            {
                                UnityEngine.Object.Destroy(reference);
                                reference = null;
                            }
                            menuOpen = false;
                        }
                        else
                        {
                            menuOpen = true;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError($"{PluginInfo.Name} {exc.StackTrace} {exc.Message}");
            }

            try
            {
                if (fpsObject != null)
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();

                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled && v.method != null)
                        {
                            try
                            {
                                v.method.Invoke();
                            }
                            catch (Exception exc)
                            {
                                UnityEngine.Debug.LogError($"{PluginInfo.Name} {v.buttonText} {exc.StackTrace} {exc.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError($"{PluginInfo.Name} {exc.StackTrace} {exc.Message}");
            }
        }








        // Functions

        public static Color32 menuColor = new Color32(10, 10, 10, 255);

        public static Color32 btnColor1 = new Color32(30, 30, 30, 255); // on

        public static Color32 btnColor2 = new Color32(25, 25, 25, 25); // off

        public static Color32 panelColor = new Color32(20, 20, 20, 255);

        public static void news()
        {
            newss = true;
            info = false;
        }

        public static bool newss = false;

        public static void newsoff()
        {
            newss = false;
        }


        public static void Shit()
        {
            GameObject menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = new Vector3(0.00908f, 0.86f, 0.47f);
            menuBackground.transform.position = new Vector3(0.051f, -0.058f, 0f);

            menuBackground.GetComponent<Renderer>().material.color = panelColor;

            menuBackground.GetComponent<Renderer>().enabled = false;

            float bevel = 0.02f;

            Renderer ToRoundRenderer = menuBackground.GetComponent<Renderer>();


            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = menuBackground.transform.localPosition;
            BaseA.transform.localScale = menuBackground.transform.localScale + new Vector3(0f, bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = menuBackground.transform.localPosition;
            BaseB.transform.localScale = menuBackground.transform.localScale + new Vector3(0f, 0f, -bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, (menuBackground.transform.localScale.y / 2f) - (bevel * 1.275f), (menuBackground.transform.localScale.z / 2f) - bevel);
            RoundCornerA.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, -(menuBackground.transform.localScale.y / 2f) + (bevel * 1.275f), (menuBackground.transform.localScale.z / 2f) - bevel);
            RoundCornerB.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, (menuBackground.transform.localScale.y / 2f) - (bevel * 1.275f), -(menuBackground.transform.localScale.z / 2f) + bevel);
            RoundCornerC.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, -(menuBackground.transform.localScale.y / 2f) + (bevel * 1.275f), -(menuBackground.transform.localScale.z / 2f) + bevel);
            RoundCornerD.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            foreach (GameObject obj in ToChange)
            {
                obj.GetComponent<Renderer>().material.color = panelColor;
            }


            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;

            if (newss && !info)
            {
                TextMeshPro text = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<TextMeshPro>();
                text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                type(text, "THIS IS A VERY EARLY VERSION OF THE MENU. MENU WILL BE BETTER IN FUTURE VERSIONS! I HOPE YOU ENJOY\n- With Love From GLXY", 0.05f);
                text.fontSize = 0.15f;
                text.color = textColors[0];
                text.alignment = TextAlignmentOptions.Center;
                Outline outline = text.gameObject.AddComponent<Outline>();
                outline.effectColor = new Color32(0, 0, 0, 200);
                outline.effectDistance = new Vector2(1.5f, -1.5f);
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.23f, 0.14f);
                component.position = new Vector3(0.052f, -0.06f, 0.0095f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            if (info && !newss)
            {
                TextMeshPro text = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<TextMeshPro>();
                text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                type(text, "Thank You For Using Singularity OS! This Mod Menu Offers Movement Mods, Visual Mods, Tag / Advantage Mods, Overpowered Mods, AND MORE! WE ARE NOT RESPONSABLE FOR ANY BANS THAT HAPPEN WHILE USING THIS MENU! We Hope That You Have As Much Fun As Possible. To Open Modules Turn Off The News Button And Click Modules! ENJOY\nMenu Status: <color=green>UND</color>", 0.05f);
                text.fontSize = 0.11f;
                text.color = textColors[0];
                text.alignment = TextAlignmentOptions.Center;
                Outline outline = text.gameObject.AddComponent<Outline>();
                outline.effectColor = new Color32(0, 0, 0, 200);
                outline.effectDistance = new Vector2(1.5f, -1.5f);
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.23f, 0.14f);
                component.position = new Vector3(0.052f, -0.06f, 0.0095f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

        }


        public static bool info = false;

        public static void infoshit()
        {
            info = true;
            newss = false;
        }
        public static void offInfoShit()
        {
            info = false;
        }

        public static async Task type(TextMeshPro shit, string text, float delay = 0.2f)
        {
            shit.text = "";
            foreach (char letter in text)
            {
                shit.text += letter;
                await Task.Delay((int)(delay * 1000f));
            }
        }


        public static float rgbTimer = 0f;


        // Functions
        Color peach = new Color(255f / 255f, 229f / 255f, 180f / 255f);
        Color mainc = new Color(176f / 255f, 153f / 255f, 128f / 255f);
        public static void CreateMenu()
        {
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
            GameObject menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = new Vector3(0.01f, 1.3f, 0.7f);
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

            menuBackground.GetComponent<Renderer>().material.color = menuColor;

            menuBackground.GetComponent<Renderer>().enabled = false;

            float bevel = 0.07f;

            Renderer ToRoundRenderer = menuBackground.GetComponent<Renderer>();


            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = menuBackground.transform.localPosition;
            BaseA.transform.localScale = menuBackground.transform.localScale + new Vector3(0f, bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = menuBackground.transform.localPosition;
            BaseB.transform.localScale = menuBackground.transform.localScale + new Vector3(0f, 0f, -bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, (menuBackground.transform.localScale.y / 2f) - (bevel * 1.275f), (menuBackground.transform.localScale.z / 2f) - bevel);
            RoundCornerA.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, -(menuBackground.transform.localScale.y / 2f) + (bevel * 1.275f), (menuBackground.transform.localScale.z / 2f) - bevel);
            RoundCornerB.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, (menuBackground.transform.localScale.y / 2f) - (bevel * 1.275f), -(menuBackground.transform.localScale.z / 2f) + bevel);
            RoundCornerC.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = menuBackground.transform.localPosition + new Vector3(0f, -(menuBackground.transform.localScale.y / 2f) + (bevel * 1.275f), -(menuBackground.transform.localScale.z / 2f) + bevel);
            RoundCornerD.transform.localScale = new Vector3(bevel * 2.55f, menuBackground.transform.localScale.x / 2f, bevel * 2f);

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            foreach (GameObject obj in ToChange)
            {
                obj.GetComponent<Renderer>().material.color = menuColor;
            }



            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;

            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            type(text, PluginInfo.Name);
            text.fontSize = 0.12f;
            text.color = textColors[0];
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.10f, 0.03f);
            component.position = new Vector3(0.052f, 0.13f, 0.104f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                // Cat Buttons
                ButtonInfo[] catButtons = buttons[0].Skip(0 * 5).Take(5).ToArray();
                for (int i = 0; i < catButtons.Length; i++)
                {
                    CreateCatButton(i * 0.105f, catButtons[i]);
                }
            if (!newss && !info)
            {
                // Modules
                if (buttonsType != 0 && buttonsType != 3 && buttonsType != 4 && buttonsType != 5 && buttonsType != 6 && buttonsType != 7 && buttonsType != 8 && buttonsType != 9 && buttonsType != 10 && buttonsType != 12 && buttonsType != 13 && buttonsType != 14 && buttonsType != 15)
                {
                    ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                    for (int i = 0; i < activeButtons.Length; i++)
                    {
                        CreateButton(i * 0.205f, activeButtons[i]);
                    }
                }

                // Mod Buttons
                if (buttonsType != 0 && buttonsType != 1 && buttonsType != 2 && buttonsType != 11)
                {
                    ButtonInfo[] modButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                    for (int i = 0; i < modButtons.Length; i++)
                    {
                        CreateModuleButton(i % 4 * 0.205f, modButtons[i], i);
                    }
                }              
            }

            Shit();
            CreateHomeButton();
            CreateDisconnectButton();
            CreatePageButtons();
        }


        public static void CreateDisconnectButton()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;

            gameObject.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
            gameObject.transform.localPosition = new Vector3(0.514f, -0.30f, -0.29f);

            gameObject.GetComponent<Renderer>().enabled = false;

            float Bevel = 0.03f;
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = gameObject.transform.localPosition;
            BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = gameObject.transform.localPosition;
            BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            gameObject.AddComponent<Classes.Button>().relatedText = "leave";

            gameObject.GetComponent<Renderer>().material.color = btnColor2;

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            foreach (GameObject obj in ToChange)
            {
                obj.GetComponent<Renderer>().material.color = btnColor2;
            }


            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            text.text = "leave";
            text.fontSize = 0.1f;
            text.color = textColors[0];
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.05f, .02f);
            component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void CreateHomeButton()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;

            gameObject.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
            gameObject.transform.localPosition = new Vector3(0.514f, -0.51f, -0.29f);

            gameObject.GetComponent<Renderer>().enabled = false;

            float Bevel = 0.03f;
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = gameObject.transform.localPosition;
            BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = gameObject.transform.localPosition;
            BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            gameObject.AddComponent<Classes.Button>().relatedText = "home";

            gameObject.GetComponent<Renderer>().material.color = btnColor2;

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            foreach (GameObject obj in ToChange)
            {
                obj.GetComponent<Renderer>().material.color = btnColor2;
            }


            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            text.text = "Home";
            text.fontSize = 0.1f;
            text.color = textColors[0];
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.05f, .02f);
            component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static bool isInCat = false;
        public static void CreatePageButtons()
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject BaseBB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject BaseAA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerAA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerBB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerCC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject RoundCornerDD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            if (isInCat)
            {
                // Next Page            
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;

                gameObject.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
                gameObject.transform.localPosition = new Vector3(0.514f, -0.09f, -0.29f);

                gameObject.GetComponent<Renderer>().enabled = false;

                float Bevel = 0.03f;
                BaseA.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
                BaseA.transform.parent = menu.transform;
                BaseA.transform.rotation = Quaternion.identity;
                BaseA.transform.localPosition = gameObject.transform.localPosition;
                BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

                BaseB.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
                BaseB.transform.parent = menu.transform;
                BaseB.transform.rotation = Quaternion.identity;
                BaseB.transform.localPosition = gameObject.transform.localPosition;
                BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);
              
                RoundCornerA.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
                RoundCornerA.transform.parent = menu.transform;
                RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerA.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
                RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            
                RoundCornerB.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
                RoundCornerB.transform.parent = menu.transform;
                RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerB.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
                RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

                RoundCornerC.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
                RoundCornerC.transform.parent = menu.transform;
                RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerC.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
                RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

                RoundCornerD.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
                RoundCornerD.transform.parent = menu.transform;
                RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerD.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
                RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

                gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

                gameObject.GetComponent<Renderer>().material.color = btnColor2;

                GameObject[] ToChange = new GameObject[]
                {
                    BaseA,
                    BaseB,
                    RoundCornerA,
                    RoundCornerB,
                    RoundCornerC,
                    RoundCornerD
                };

                foreach (GameObject obj in ToChange)
                {
                    obj.GetComponent<Renderer>().material.color = btnColor2;
                }


                TextMeshPro text = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<TextMeshPro>();
                text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                text.text = ">>";
                text.fontSize = 0.1f;
                text.color = textColors[0];
                text.alignment = TextAlignmentOptions.Center;
                Outline outline = text.gameObject.AddComponent<Outline>();
                outline.effectColor = new Color32(0, 0, 0, 200);
                outline.effectDistance = new Vector2(1.5f, -1.5f);
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(.05f, .02f);
                component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, gameObject.transform.position.z);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                // Previous Page
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject2.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;

                gameObject2.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
                gameObject2.transform.localPosition = new Vector3(0.514f, 0.12f, -0.29f);

                gameObject2.GetComponent<Renderer>().enabled = false;
                
                BaseAA.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(BaseAA.GetComponent<Collider>());
                BaseAA.transform.parent = menu.transform;
                BaseAA.transform.rotation = Quaternion.identity;
                BaseAA.transform.localPosition = gameObject2.transform.localPosition;
                BaseAA.transform.localScale = gameObject2.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

                BaseBB.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(BaseBB.GetComponent<Collider>());
                BaseBB.transform.parent = menu.transform;
                BaseBB.transform.rotation = Quaternion.identity;
                BaseBB.transform.localPosition = gameObject2.transform.localPosition;
                BaseBB.transform.localScale = gameObject2.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);

                RoundCornerAA.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerAA.GetComponent<Collider>());
                RoundCornerAA.transform.parent = menu.transform;
                RoundCornerAA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerAA.transform.localPosition = gameObject2.transform.localPosition + new Vector3(0f, (gameObject2.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject2.transform.localScale.z / 2f) - Bevel);
                RoundCornerAA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject2.transform.localScale.x / 2f, Bevel * 2f);

                RoundCornerBB.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerBB.GetComponent<Collider>());
                RoundCornerBB.transform.parent = menu.transform;
                RoundCornerBB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerBB.transform.localPosition = gameObject2.transform.localPosition + new Vector3(0f, -(gameObject2.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject2.transform.localScale.z / 2f) - Bevel);
                RoundCornerBB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject2.transform.localScale.x / 2f, Bevel * 2f);

                RoundCornerCC.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerCC.GetComponent<Collider>());
                RoundCornerCC.transform.parent = menu.transform;
                RoundCornerCC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerCC.transform.localPosition = gameObject2.transform.localPosition + new Vector3(0f, (gameObject2.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject2.transform.localScale.z / 2f) + Bevel);
                RoundCornerCC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject2.transform.localScale.x / 2f, Bevel * 2f);

                RoundCornerDD.GetComponent<Renderer>().enabled = true;
                UnityEngine.Object.Destroy(RoundCornerDD.GetComponent<Collider>());
                RoundCornerDD.transform.parent = menu.transform;
                RoundCornerDD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
                RoundCornerDD.transform.localPosition = gameObject2.transform.localPosition + new Vector3(0f, -(gameObject2.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject2.transform.localScale.z / 2f) + Bevel);
                RoundCornerDD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject2.transform.localScale.x / 2f, Bevel * 2f);

                gameObject2.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                gameObject2.GetComponent<Renderer>().material.color = btnColor2;

                GameObject[] ToChange23 = new GameObject[]
                {
                    BaseAA,
                    BaseBB,
                    RoundCornerAA,
                    RoundCornerBB,
                    RoundCornerCC,
                    RoundCornerDD
                };

                foreach (GameObject obj in ToChange23)
                {
                    obj.GetComponent<Renderer>().material.color = btnColor2;
                }


                TextMeshPro text23 = new GameObject
                {
                    transform =
                {
                    parent = canvasObject.transform
                }
                }.AddComponent<TextMeshPro>();
                text23.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                text23.text = "<<";
                text23.fontSize = 0.1f;
                text23.color = textColors[0];
                text23.alignment = TextAlignmentOptions.Center;
                Outline outline23 = text23.gameObject.AddComponent<Outline>();
                outline23.effectColor = new Color32(0, 0, 0, 200);
                outline23.effectDistance = new Vector2(1.5f, -1.5f);
                RectTransform component23 = text23.GetComponent<RectTransform>();
                component23.localPosition = Vector3.zero;
                component23.sizeDelta = new Vector2(.05f, .02f);
                component23.localPosition = new Vector3(0.0523f, gameObject2.transform.position.y, gameObject2.transform.position.z);
                component23.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }   
            else
            {
                GameObject[] ToChange = new GameObject[]
                {
                    BaseA,
                    BaseB,
                    RoundCornerA,
                    RoundCornerB,
                    RoundCornerC,
                    RoundCornerD
                };
                GameObject[] ToChange2 = new GameObject[]
                {
                    BaseAA,
                    BaseBB,
                    RoundCornerAA,
                    RoundCornerBB,
                    RoundCornerCC,
                    RoundCornerDD
                };
                foreach (GameObject obj in ToChange)
                {
                    GameObject.Destroy(obj.GetComponent<Renderer>());
                }
                foreach (GameObject obj in ToChange2)
                {
                    GameObject.Destroy(obj.GetComponent<Renderer>());
                }
            }
        }


        public static GameObject trailObject;
        public static Color catButton = new Color32(15, 15, 15, 255);

        public static void CreateCatButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;

            gameObject.transform.localScale = new Vector3(0.01f, 0.3f, 0.075f);
            gameObject.transform.localPosition = new Vector3(0.51f, 0.45f, 0.19f - offset);
            gameObject.GetComponent<Renderer>().enabled = false;

            
            float Bevel = 0.02f;
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = gameObject.transform.localPosition;
            BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = gameObject.transform.localPosition;
            BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);

            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            gameObject.GetComponent<Renderer>().material.color = catButton;

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            BaseA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            BaseB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerC.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerD.AddComponent<Classes.Button>().relatedText = method.buttonText;

            foreach (GameObject obj in ToChange)
            {
                obj.GetComponent<Renderer>().material.color = catButton;
            }

            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            text.text = method.buttonText + method.overlapText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.fontSize = 0.08f;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.06f, .010f);
            component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, 0.074f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;

            gameObject.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
            gameObject.transform.localPosition = new Vector3(0.514f, 0.113f - offset, 0.19f);

            gameObject.GetComponent<Renderer>().enabled = false;

            float Bevel = 0.03f;
            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;  
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = gameObject.transform.localPosition;
            BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);
            BaseA.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;  
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = gameObject.transform.localPosition;
            BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);
            BaseB.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerA.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true; 
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerB.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1; 

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;  
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerC.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1; 

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true; 
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.identity * Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = gameObject.transform.localPosition + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerD.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            gameObject.GetComponent<Renderer>().material.color = btnColor2; 

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            BaseA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            BaseB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerC.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerD.AddComponent<Classes.Button>().relatedText = method.buttonText;




            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = btnColor1;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = btnColor2;
            }
            colorChanger.Start();

            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            text.text = method.buttonText + method.overlapText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.fontSize = 0.07f;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.07f, .03f);
            component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void CreateModuleButton(float offset, ButtonInfo method, int buttonIndex)
        {
            isInCat = true;
            int row = buttonIndex / 4;
            float zOffset = -0.09f * row;
            Vector3 basePos = new Vector3(0.514f, 0.113f - offset, 0.19f + zOffset);

            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }

            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.01f, 0.2f, 0.071f);
            gameObject.transform.localPosition = basePos;
            gameObject.GetComponent<Renderer>().enabled = false;

            float Bevel = 0.03f;

            GameObject BaseA = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseA.GetComponent<Collider>());
            BaseA.transform.parent = menu.transform;
            BaseA.transform.rotation = Quaternion.identity;
            BaseA.transform.localPosition = basePos;
            BaseA.transform.localScale = gameObject.transform.localScale + new Vector3(0f, Bevel * -2.55f, 0f);
            BaseA.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject BaseB = GameObject.CreatePrimitive(PrimitiveType.Cube);
            BaseB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(BaseB.GetComponent<Collider>());
            BaseB.transform.parent = menu.transform;
            BaseB.transform.rotation = Quaternion.identity;
            BaseB.transform.localPosition = basePos;
            BaseB.transform.localScale = gameObject.transform.localScale + new Vector3(0f, 0f, -Bevel * 2f);
            BaseB.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            Vector3 topFront = basePos + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            Vector3 bottomFront = basePos + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), (gameObject.transform.localScale.z / 2f) - Bevel);
            Vector3 topBack = basePos + new Vector3(0f, (gameObject.transform.localScale.y / 2f) - (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);
            Vector3 bottomBack = basePos + new Vector3(0f, -(gameObject.transform.localScale.y / 2f) + (Bevel * 1.275f), -(gameObject.transform.localScale.z / 2f) + Bevel);

            GameObject RoundCornerA = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerA.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerA.GetComponent<Collider>());
            RoundCornerA.transform.parent = menu.transform;
            RoundCornerA.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerA.transform.localPosition = topFront;
            RoundCornerA.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerA.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject RoundCornerB = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerB.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerB.GetComponent<Collider>());
            RoundCornerB.transform.parent = menu.transform;
            RoundCornerB.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerB.transform.localPosition = bottomFront;
            RoundCornerB.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerB.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject RoundCornerC = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerC.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerC.GetComponent<Collider>());
            RoundCornerC.transform.parent = menu.transform;
            RoundCornerC.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerC.transform.localPosition = topBack;
            RoundCornerC.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerC.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            GameObject RoundCornerD = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            RoundCornerD.GetComponent<Renderer>().enabled = true;
            UnityEngine.Object.Destroy(RoundCornerD.GetComponent<Collider>());
            RoundCornerD.transform.parent = menu.transform;
            RoundCornerD.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            RoundCornerD.transform.localPosition = bottomBack;
            RoundCornerD.transform.localScale = new Vector3(Bevel * 2.55f, gameObject.transform.localScale.x / 2f, Bevel * 2f);
            RoundCornerD.GetComponent<Renderer>().material.color = method.enabled ? btnColor2 : btnColor1;

            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            gameObject.GetComponent<Renderer>().material.color = btnColor2;

            GameObject[] ToChange = new GameObject[]
            {
                BaseA,
                BaseB,
                RoundCornerA,
                RoundCornerB,
                RoundCornerC,
                RoundCornerD
            };

            BaseA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            BaseB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerA.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerB.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerC.AddComponent<Classes.Button>().relatedText = method.buttonText;
            RoundCornerD.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = btnColor1;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = btnColor2;
            }
            colorChanger.Start();

            TextMeshPro text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<TextMeshPro>();
            text.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            text.text = method.buttonText + method.overlapText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.fontSize = 0.07f;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAlignmentOptions.Center;
            Outline outline = text.gameObject.AddComponent<Outline>();
            outline.effectColor = new Color32(0, 0, 0, 200);
            outline.effectDistance = new Vector2(1.5f, -1.5f);
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.05f, .02f);
            component.localPosition = new Vector3(0.0523f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static bool uimenu = false;


        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            { 
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }

                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-64f, 3.4f, -65f);
                    TPC.transform.rotation = Quaternion.identity;
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = TPC.transform.position + (TPC.transform.forward * 0.5f) + (TPC.transform.up * 0f);
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot += new Vector3(-90f, 90f, 0f);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        private static bool rightTriggerPressed = false;
        private static bool leftTriggerPressed = false;

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                } else
                if (buttonText == "leave")
                {
                    NetworkSystem.Instance.ReturnToSinglePlayer();
                } else
                if (buttonText == "home")
                {
                    Global.ReturnHome();
                } else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                GUINotifs.SendNotification("ToolTip","<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                GUINotifs.SendNotification("ToolTip", "<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            GUINotifs.SendNotification("ToolTip", "<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        // Variables
            // Important
                // Objects
                    public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        // Data
            public static int pageNumber = 0;
            public static int buttonsType = 0;
    }
}
