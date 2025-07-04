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

namespace Singularity_OS.Menu
{
    public class Visual
    {
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
            motdTextB.GetComponent<TextMeshPro>().text = string.Format("Thank you for using X O N N C Z Reborn!\nThe Menu Status is : UND\nWe really hope that you have fun while using this menu, and don't forget DO NOT GET BANNED, AND IF YOU DO IT IS NOT OUR FAULT!\n" + DateTime.Now.ToString("hh:mm tt"));
            RGBShit.FlowingRGB(motdTextB.GetComponent<TextMeshPro>(), 100f, 3f);

            coc = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText");
            ForCocBecauseGtagIsAbitch(coc.GetComponent<TextMeshPro>());
            RGBShit.FlowingRGB(coc.GetComponent<TextMeshPro>());

            coc2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COCBodyText_TitleData");
            coc2.GetComponent<TextMeshPro>().text = string.Format(("This Menu Has Been devopled for some time we do hope that you enjoy it and make sure that you do not get yourself banned! and if you do please report it in the discord so we can fix it. But it is not our fault if you get banned!\nThe Menu is : UNDETECTED"));
            RGBShit.FlowingRGB(coc2.GetComponent<TextMeshPro>(), 100f, 3f);

            GameObject df = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
            df.SetActive(true);




            mat = new Material(Shader.Find("GorillaTag/UberShader"));
            mat.color = Color.blue;
            Computer = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
            Computer.GetComponent<Renderer>().material = mat;

            mat = new Material(Shader.Find("GorillaTag/UberShader"));
            mat.color = Color.blue;
            GameObject WallMonitor = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
            WallMonitor.GetComponent<Renderer>().material = mat;

            KeyBoard = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)");
            KeyBoard.GetComponent<Renderer>().material = mat;

            GameObject K1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/a");
            K1.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/b");
            K2.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/c");
            K3.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K4 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/d");
            K4.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K5 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/e");
            K5.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k6 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/f");
            k6.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k7 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/g");
            k7.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k8 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/h");
            k8.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k9 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/i");
            k9.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k10 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/j");
            k10.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k11 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/k");
            k11.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k12 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/l");
            k12.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k13 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/m");
            k13.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k14 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/n");
            k14.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k15 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/o");
            k15.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k16 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/p");
            k16.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k17 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/q");
            k17.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k125 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/r");
            k125.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k18 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/s");
            k18.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k19 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/t");
            k19.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k20 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/u");
            k20.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k21 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/v");
            k21.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k22 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/w");
            k22.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k23 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/x");
            k23.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k24 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/y");
            k24.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k25 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/z");
            k25.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n0 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/0");
            n0.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/1");
            n1.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/2");
            n2.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/3");
            n3.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n4 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/4");
            n4.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n5 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/5");
            n5.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n6 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/6");
            n6.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n7 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/7");
            n7.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n8 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/8");
            n8.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n9 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/9");
            n9.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject del = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/delete");
            del.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject ent = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/enterkeyforest");
            ent.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 1");
            opt1.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 2");
            opt2.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 3");
            opt3.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject up = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/up");
            up.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject down = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/down");
            down.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            GorillaKeyboardButton g = new GorillaKeyboardButton();
            g.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            g.PressButtonColourUpdate();
            g.ButtonRenderer.GetComponent<Renderer>().material.color = Color.Lerp(menuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            PhotonNetworkController.Instance.UpdateTriggerScreens();
        }


        public static float sig;
        public static int but = 1;
        public static GameObject coc;
        public static GameObject coc2;
        public static GameObject MotdBoard;
        public static GameObject Computer;
        public static GameObject KeyBoard;
        public static GameObject motdText = null;
        public static GameObject motdTextB = null;

        public static void StumpText()
        {
            GameObject StumpObj = new GameObject("STUMPOBJ");
            TextMeshPro textobj = StumpObj.AddComponent<TextMeshPro>();
            textobj.text = "<color=yellow>Menu Status:</color> <color=green>Undetected</color>\n<color=purple>discord.gg/singul</color>";
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
                if (!vrrigs.isOfflineVRRig && !vrrigs.isMyPlayer)
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
                if (!vrrigs.isOfflineVRRig && !vrrigs.isMyPlayer)
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

        public static void Test()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;
            GameObject Box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
            Box.transform.position = ins.transform.position;
            Object.Destroy(Box.GetComponent<BoxCollider>());
            Box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            Box.GetComponent<Renderer>().enabled = false;

            GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cube);
            line.transform.localScale = new Vector3(0.33f, 0.03f, 0f);
            line.transform.position = ins.transform.position + (Box.transform.up * 0.17f);
            line.transform.rotation = Box.transform.rotation;
            Object.Destroy(line.GetComponent<BoxCollider>());
            line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            line.GetComponent<Renderer>().material.color = espColor;
            Object.Destroy(line, Time.deltaTime);

            line = GameObject.CreatePrimitive(PrimitiveType.Cube);
            line.transform.localScale = new Vector3(0.33f, 0.03f, 0f);
            line.transform.position = ins.transform.position + (Box.transform.up * -0.17f);
            line.transform.rotation = Box.transform.rotation;
            Object.Destroy(line.GetComponent<BoxCollider>());
            line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            line.GetComponent<Renderer>().material.color = espColor;
            Object.Destroy(line, Time.deltaTime);

            line = GameObject.CreatePrimitive(PrimitiveType.Cube);
            line.transform.localScale = new Vector3(0.03f, 0.35f, 0f);
            line.transform.position = ins.transform.position + (Box.transform.right * -0.15f);
            line.transform.rotation = Box.transform.rotation;
            Object.Destroy(line.GetComponent<BoxCollider>());
            line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            line.GetComponent<Renderer>().material.color = espColor;
            Object.Destroy(line, Time.deltaTime);

            line = GameObject.CreatePrimitive(PrimitiveType.Cube);
            line.transform.localScale = new Vector3(0.03f, 0.35f, 0f);
            line.transform.position = ins.transform.position + (Box.transform.right * 0.15f);
            line.transform.rotation = Box.transform.rotation;
            Object.Destroy(line.GetComponent<BoxCollider>());
            line.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            line.GetComponent<Renderer>().material.color = espColor;
            Object.Destroy(line, Time.deltaTime);

            Object.Destroy(Box);
        }


        public static void NameTags()
        {
            foreach (VRRig vrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrigs.isOfflineVRRig && !vrigs.isMyPlayer)
                {
                    GameObject NameTags = vrigs.transform.Find("NameTags")?.gameObject;
                    NameTags = new GameObject("NameTags");
                    TextMeshPro textMeshPro = NameTags.AddComponent<TextMeshPro>();
                    textMeshPro.text = vrigs.OwningNetPlayer.NickName;
                    textMeshPro.fontSize = 2f;
                    textMeshPro.alignment = TextAlignmentOptions.Center;
                    textMeshPro.color = espColor;
                    textMeshPro.font = GameObject.Find("motdBodyText").GetComponent<TextMeshPro>().font;
                    NameTags.transform.SetParent(vrigs.transform);
                    Object.Destroy(NameTags, Time.deltaTime);
                    Transform Nametag = NameTags.transform;
                    Nametag.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
                    Nametag.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    Nametag.position = vrigs.headConstraint.position + new Vector3(0f, 0.4f, 0f);
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
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
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
                    lineRenderer.SetPosition(1, rig.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    Object.Destroy(lineRenderer, Time.deltaTime);
                    Object.Destroy(line, Time.deltaTime);
                }
            }
        }
        public static void sphereEsp()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = rig.transform.position + Vector3.up;
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
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = rig.transform.position;
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
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                if (!rigs.isLocal || !rigs.isMyPlayer)
                {
                    if (rigs.mainSkin.material.name.Contains("fected"))
                    {
                        rigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        rigs.mainSkin.material.color = new Color32(255, 0, 0, 255);
                    }
                    else
                    {
                        rigs.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                        rigs.mainSkin.material.color = new Color32(0, 255, 0, 255);
                    }
                }
            }
        }


        public static void ChamsOff()
        {
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                if (!rigs.isOfflineVRRig || !rigs.isMyPlayer)
                {
                    rigs.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    rigs.mainSkin.material.color = rigs.playerColor;
                }
            }
        }


    }
}
