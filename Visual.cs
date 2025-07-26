using System;
using System.Collections.Generic;
using System.Text;
using GorillaNetworking;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using static StupidTemplate.Menu.Main;
using GorillaTag;
using Singularity_OS.Patches;
using StupidTemplate.Menu;
using UnityEngine.InputSystem;

namespace Singularity_OS.Menu
{
    public class Visual
    { 
        public static void HandESP()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.position = vrrigs.rightHandTransform.position;
                    sphere.GetComponent<Renderer>().material.color = espColor;
                    GameObject.Destroy(sphere, Time.deltaTime);

                    sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.position = vrrigs.leftHandTransform.position;
                    sphere.GetComponent<Renderer>().material.color = espColor;
                    GameObject.Destroy(sphere, Time.deltaTime);
                }
            }
        }


        public static string X = "X";
        public static string O = "O";
        public static string O2 = "O";
        public static string N = "N";
        public static string N2 = "N";
        public static string C = "C";
        public static string Z = "Z";

        private static int index = 0;
        private static float lastTime = 0f;

        public static void TheLetterShit(TextMeshPro tmp, float delay = 0.5f)
        {
            if (tmp == null) return;

            string[] cycle = { "S", "I", "N", "G", "U", "L", "A", "R", "I", "T", "Y" };

            if (Time.time - lastTime >= delay)
            {
                string letter = cycle[index];
                tmp.text = $"[{letter}] Singularity [{letter}]";

                index = (index + 1) % cycle.Length;
                lastTime = Time.time;
            }
        }

        public static void ForCocBecauseGtagIsAbitch(TextMeshPro textMesh, float cycleDelay = 0.5f, float rainbowSpeed = 10f, float rainbowSpread = 0.6f)
        {
            if (textMesh == null) return;
            if (Time.time - lastCycleTime >= cycleDelay)
            {
                redHue += 0.05f;
                if (redHue > 1f) redHue = 0f;

                float redGradientHue = (redHue < 0.5f) ? Mathf.Lerp(0f, 0.05f, redHue * 20f) : Mathf.Lerp(0.95f, 1f, (redHue - 0.5f) * 20f);
                Color redColor = Color.HSVToRGB(redGradientHue, 1f, 1f);
                string hexColor = ColorUtility.ToHtmlStringRGB(redColor);

                string letter = cycleLetters[cycleIndex];
                string leftBracket = $"<color=#{hexColor}>[{letter}]</color>";
                string rightBracket = $"<color=#{hexColor}>[{letter}]</color>";

                textMesh.text = $"{leftBracket} {tittle} {rightBracket}";

                cycleIndex = (cycleIndex + 1) % cycleLetters.Length;
                lastCycleTime = Time.time;
            }
            if (!textMesh.havePropertiesChanged && !textMesh.isActiveAndEnabled) return;
            textMesh.ForceMeshUpdate();
            TMP_TextInfo textInfo = textMesh.textInfo;
            float time = Time.time * rainbowSpeed;
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                var charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible) continue;

                int vertexIndex = charInfo.vertexIndex;
                int materialIndex = charInfo.materialReferenceIndex;
                Color32[] colors = textInfo.meshInfo[materialIndex].colors32;
                if (i > 0 && i < textInfo.characterCount - 1)
                {
                    float hue = Mathf.Repeat((time + i * rainbowSpread) / (textInfo.characterCount - 2), 1f);
                    Color color = Color.HSVToRGB(hue, 1f, 1f);
                    Color32 color32 = color;

                    colors[vertexIndex + 0] = color32;
                    colors[vertexIndex + 1] = color32;
                    colors[vertexIndex + 2] = color32;
                    colors[vertexIndex + 3] = color32;
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
                textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }
        }

        private const string tittle = "Singularity";
        private static readonly string[] cycleLetters = { "S", "I", "N", "G", "U", "L", "A", "R", "I", "T", "Y" };
        private static int cycleIndex = 0;
        private static float lastCycleTime = 0f;
        private static float redHue = 0f;

        public static void boards()
        {
            Material mat = null;
            float h = (Time.frameCount / 180f) % 1f;
            motdText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText");
            TheLetterShit(motdText.GetComponent<TextMeshPro>());
            RGBShit.FlowingRGB(motdText.GetComponent<TextMeshPro>());

            motdTextB = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText");
            motdTextB.GetComponent<TextMeshPro>().text = string.Format("Thank you for using Singularity OS!\nThe Menu Status is : UND\nWe really hope that you have fun while using this menu, and don't forget DO NOT GET BANNED, AND IF YOU DO IT IS NOT OUR FAULT!\n" + DateTime.Now.ToString("hh:mm tt"));
            RGBShit.FlowingRGB(motdTextB.GetComponent<TextMeshPro>(), 100f, 3f);

            coc = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText");
            ForCocBecauseGtagIsAbitch(coc.GetComponent<TextMeshPro>());
            RGBShit.FlowingRGB(coc.GetComponent<TextMeshPro>());

            coc2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COCBodyText_TitleData");
            coc2.GetComponent<TextMeshPro>().text = string.Format(("This Menu Has Been devopled for some time we do hope that you enjoy it and make sure that you do not get yourself banned! and if you do please report it in the discord so we can fix it. But it is not our fault if you get banned!\nThe Menu is : UNDETECTED"));
            RGBShit.FlowingRGB(coc2.GetComponent<TextMeshPro>(), 100f, 3f);

            GameObject df = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
            df.SetActive(true);


            GameObject crystalGameOBJ = GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToCave/C_Crystal_Chunk");
            if (crystalGameOBJ != null)
            {
                Material crystalMat = crystalGameOBJ.GetComponent<Renderer>().material;
                crystalMat.color = new Color32(95, 245, 145, 255);
                Computer = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
                Computer.GetComponent<Renderer>().material = crystalMat;

                WallMonitor = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
                WallMonitor.GetComponent<Renderer>().material = crystalMat;

                KeyBoard = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)");
                KeyBoard.GetComponent<Renderer>().material = crystalMat;               

                ChangeBoardMaterial("Environment Objects/LocalObjects_Prefab/TreeRoom", 5, crystalMat, ref originalMat1);
                ChangeBoardMaterial("Environment Objects/LocalObjects_Prefab/Forest", 13, crystalMat, ref originalMat2);
                PhotonNetworkController.Instance.UpdateTriggerScreens();
            }
        }
        public static Material originalMat1;
        public static Material originalMat2;

        public static void ChangeBoardMaterial(string parentPath, int targetIndex, Material newMaterial, ref Material originalMat)
        {
            GameObject parent = GameObject.Find(parentPath);
            if (parent == null)
                return;
            int currentIndex = 0;
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject childObj = parent.transform.GetChild(i).gameObject;
                if (childObj.name.Contains("UnityTempFile"))
                {
                    currentIndex++;
                    if (currentIndex == targetIndex)
                    {
                        Renderer renderer = childObj.GetComponent<Renderer>();
                        if (originalMat == null)
                            originalMat = renderer.material;

                        renderer.material = newMaterial;
                        break;
                    }
                }
            }
        }



        public static float sig;
        public static int but = 1;
        public static GameObject coc;
        public static GameObject coc2;
        public static GameObject MotdBoard;
        public static GameObject Computer;
        public static GameObject WallMonitor;
        public static GameObject KeyBoard;
        public static GameObject motdText = null;
        public static GameObject motdTextB = null;

        public static void StumpText()
        {
            GameObject StumpObj = new GameObject("STUMPOBJ");
            TextMeshPro textobj = StumpObj.AddComponent<TextMeshPro>();
            textobj.text = "<color=yellow>Menu Status:</color> <color=green>Undetected</color>\n<color=purple>discord.gg/xaj9QMRCkV</color>";
            textobj.fontSize = 2f;
            textobj.alignment = TextAlignmentOptions.Center;
            textobj.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
            Object.Destroy(StumpObj, Time.deltaTime);
            Transform shit = StumpObj.transform;
            shit.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
            shit.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            shit.position = new Vector3(-63.5511f, 12.2094f, -82.6264f);
            shit.LookAt(Camera.main.transform.position);
            shit.Rotate(0f, 180f, 0f);
        }

        public static void BoxEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject Box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    Box.transform.position = vrrigs.transform.position;
                    Object.Destroy(Box.GetComponent<BoxCollider>());
                    Box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    Box.GetComponent<Renderer>().material.color = espColor;
                    Object.Destroy(Box, Time.deltaTime);
                }
            }
        }

        public static void HollowBoxEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject Box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    Box.transform.position = vrrigs.transform.position;
                    Object.Destroy(Box.GetComponent<BoxCollider>());
                    Box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    Box.transform.LookAt(Camera.main.transform.position);
                    Box.GetComponent<Renderer>().enabled = false;

                    GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    line.transform.localScale = new Vector3(0.33f, 0.03f, 0f);
                    line.transform.position = vrrigs.transform.position + (Box.transform.up * 0.17f);
                    line.transform.rotation = Box.transform.rotation;
                    Object.Destroy(line.GetComponent<BoxCollider>());
                    line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    line.GetComponent<Renderer>().material.color = espColor;
                    Object.Destroy(line, Time.deltaTime);

                    line = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    line.transform.localScale = new Vector3(0.33f, 0.03f, 0f);
                    line.transform.position = vrrigs.transform.position + (Box.transform.up * -0.17f);
                    line.transform.rotation = Box.transform.rotation;
                    Object.Destroy(line.GetComponent<BoxCollider>());
                    line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    line.GetComponent<Renderer>().material.color = espColor;
                    Object.Destroy(line, Time.deltaTime);

                    line = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    line.transform.localScale = new Vector3(0.03f, 0.35f, 0f);
                    line.transform.position = vrrigs.transform.position + (Box.transform.right * -0.15f);
                    line.transform.rotation = Box.transform.rotation;
                    Object.Destroy(line.GetComponent<BoxCollider>());
                    line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    line.GetComponent<Renderer>().material.color = espColor;
                    Object.Destroy(line, Time.deltaTime);

                    line = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    line.transform.localScale = new Vector3(0.03f, 0.35f, 0f);
                    line.transform.position = vrrigs.transform.position + (Box.transform.right * 0.15f);
                    line.transform.rotation = Box.transform.rotation;
                    Object.Destroy(line.GetComponent<BoxCollider>());
                    line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    line.GetComponent<Renderer>().material.color = espColor;
                    Object.Destroy(line, Time.deltaTime);

                    Object.Destroy(Box);
                }
            }
        }

        public static void XRAY()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 100);
                }
            }
            else
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.GetComponent<Renderer>().enabled = true;
                }
            }
        }


        public static float clr;
        public static void wireframeEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject wireframe = new GameObject("wireframeESP");
                    LineRenderer lr = wireframe.AddComponent<LineRenderer>();
                    lr.material = new Material(Shader.Find("GUI/Text Shader"));
                    lr.widthMultiplier = 0.01f;
                    lr.useWorldSpace = true;
                    lr.loop = false;
                    clr += Time.deltaTime * 0.5f;
                    if (clr > 1f) clr = 0f;

                    Color rgb = Color.HSVToRGB(clr, 1f, 1f);
                    lr.startColor = rgb;
                    lr.endColor = rgb;
                    Vector3 size = new Vector3(1.5f, 1.5f, 1f) * 0.5f;
                    Vector3 p0 = vrrigs.transform.position + new Vector3(-size.x, -size.y, -size.z);
                    Vector3 p1 = vrrigs.transform.position + new Vector3(size.x, -size.y, -size.z);
                    Vector3 p2 = vrrigs.transform.position + new Vector3(size.x, -size.y, size.z);
                    Vector3 p3 = vrrigs.transform.position + new Vector3(-size.x, -size.y, size.z);
                    Vector3 p4 = vrrigs.transform.position + new Vector3(-size.x, size.y, -size.z);
                    Vector3 p5 = vrrigs.transform.position + new Vector3(size.x, size.y, -size.z);
                    Vector3 p6 = vrrigs.transform.position + new Vector3(size.x, size.y, size.z);
                    Vector3 p7 = vrrigs.transform.position + new Vector3(-size.x, size.y, size.z);
                    Vector3[] lines = new Vector3[]
                    {
                    p0, p1, p1, p2, p2, p3, p3, p0,
                    p4, p5, p5, p6, p6, p7, p7, p4,
                    p0, p4, p1, p5, p2, p6, p3, p7,
                    p0, p2,
                    p1, p3,
                    p4, p6,
                    p5, p7,
                    p0, p5,
                    p1, p4,
                    p3, p6,
                    p2, p7,
                    p0, p7,
                    p3, p4,
                    p1, p6,
                    p2, p5
                    };
                    lr.positionCount = lines.Length;
                    lr.SetPositions(lines);

                    GameObject.Destroy(wireframe, Time.deltaTime);
                }               
            }           
        }


        public static void NameTags()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject NameTags = vrrigs.transform.Find("NameTags")?.gameObject;
                    NameTags = new GameObject("NameTags");
                    TextMeshPro textMeshPro = NameTags.AddComponent<TextMeshPro>();
                    textMeshPro.text = vrrigs.OwningNetPlayer.NickName;
                    textMeshPro.fontSize = 2f;
                    textMeshPro.alignment = TextAlignmentOptions.Center;
                    textMeshPro.color = espColor;
                    textMeshPro.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                    NameTags.transform.SetParent(vrrigs.transform);
                    Object.Destroy(NameTags, Time.deltaTime);
                    Transform Nametag = NameTags.transform;
                    Nametag.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
                    Nametag.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    Nametag.position = vrrigs.headConstraint.position + new Vector3(0f, 0.4f, 0f);
                    Nametag.LookAt(Camera.main.transform.position);
                    Nametag.Rotate(0f, 180f, 0f);
                }
            }
        }

        public static Color espColor = new Color32(0, 0, 0, 100);

        public static int d = 0;
        public static void ChangeEspColor()
        {
            d++;
            if (d > 6)
            {
                d = 0;
            }

            if (d == 0)
            {
                espColor = new Color32(0, 0, 0, 100);
                GetIndex("Esp Color").overlapText = "Black";
            }

            if (d == 1)
            {
                espColor = new Color32(255, 0, 0, 100);
                GetIndex("Esp Color").overlapText = "Red";
            }

            if (d == 2)
            {
                espColor = new Color32(0, 255, 0, 100);
                GetIndex("Esp Color").overlapText = "Green";
            }

            if (d == 3)
            {
                espColor = new Color32(0, 0, 255, 100);
                GetIndex("Esp Color").overlapText = "Blue";
            }

            if (d == 4)
            {
                espColor = menuColor;
                GetIndex("Esp Color").overlapText = "Menu Color";
            }

            if (d == 5)
            {
                espColor = mods.Deeppurple;
                GetIndex("Esp Color").overlapText = "Purple";
            }
            
            if (d == 6)
            {
                espColor = new Color32(95, 245, 145, 255);
                GetIndex("Esp Color").overlapText = "Mint";
            }         
        }

        public static void tracers()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject line = new GameObject("Line");
                    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                    lineRenderer.startColor = espColor;
                    lineRenderer.endColor = espColor;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                    lineRenderer.SetPosition(1, vrrigs.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    Object.Destroy(lineRenderer, Time.deltaTime);
                    Object.Destroy(line, Time.deltaTime);
                }
            }
        }
        public static void sphereEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = vrrigs.transform.position + Vector3.up;
                    sphere.GetComponent<SphereCollider>().enabled = false;
                    sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    sphere.GetComponent<Renderer>().material.color = espColor;
                    GameObject.Destroy(sphere, Time.deltaTime);
                    GameObject line = new GameObject("Line");
                    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                    lineRenderer.startColor = espColor;
                    lineRenderer.endColor = espColor;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                    lineRenderer.SetPosition(1, sphere.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    Object.Destroy(lineRenderer, Time.deltaTime);
                    Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void headEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = vrrigs.transform.position;
                    sphere.GetComponent<SphereCollider>().enabled = false;
                    sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    sphere.GetComponent<Renderer>().material.color = espColor;
                    GameObject.Destroy(sphere, Time.deltaTime);
                }
            }
        }

        public static void MakeRain()
        {
            for (int i2 = 1; i2 < BetterDayNightManager.instance.weatherCycle.Length; i2++)
            {
                BetterDayNightManager.instance.weatherCycle[i2] = BetterDayNightManager.WeatherType.Raining;
            }
        }
        public static void DontMakeRain()
        {
            for (int i2 = 1; i2 < BetterDayNightManager.instance.weatherCycle.Length; i2++)
            {
                BetterDayNightManager.instance.weatherCycle[i2] = BetterDayNightManager.WeatherType.None;
            }
        }

        public static void Chams()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    if (vrrigs.mainSkin.material.name.Contains("fected"))
                    {
                        vrrigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        vrrigs.mainSkin.material.color = new Color32(255, 0, 0, 255);
                    }
                    else
                    {
                        vrrigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        vrrigs.mainSkin.material.color = new Color32(0, 255, 0, 255);
                    }
                }
            }
        }


        public static void ChamsOff()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (vrrigs != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrigs.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    vrrigs.mainSkin.material.color = vrrigs.playerColor;
                }
            }
        }
    }
}
