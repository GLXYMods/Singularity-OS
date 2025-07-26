using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using GorillaLocomotion;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Singularity_OS.Menu
{
    public class Overpowered
    {

        public static void AutoBranch()
        {
            Vector3[] branches = new Vector3[]
            {
                new Vector3(-2.383f, 3.784f, 0.738f),
                new Vector3(1.55f, 5.559f, -1.56f),
                new Vector3(-2.225f, 7.214f, 0.063f),
                new Vector3(1.365f, 6.62f, 0.82f),
                new Vector3(0.405f, 8.865f, -2.759f),
                new Vector3(-2.227f, 9.763f, 2.071f),
                new Vector3(2.421f, 10.91f, 1.313f),
                new Vector3(1.618f, 13.169f, -1.216f),
                new Vector3(2.175f, 12.959f, -0.229f),
                new Vector3(1.855f, 13.837f, 1.215f),
                new Vector3(-0.265f, 14.953f, 2.935f),
                new Vector3(-2.049f, 14.962f, -1.708f),
                new Vector3(-1.249f, 18.93f, -1.62f),
                new Vector3(-82.30447f, 5.968529f, -46.82239f),
                new Vector3(-83.77034f, 7.743529f, -51.13522f),
                new Vector3(-82.93429f, 9.398529f, -47.11207f),
                new Vector3(-81.47529f, 8.804529f, -50.47844f),
                new Vector3(-85.17393f, 11.04953f, -50.25286f),
                new Vector3(-80.96718f, 11.94753f, -46.70892f),
                new Vector3(-80.78124f, 13.09453f, -51.41465f),
                new Vector3(-83.41969f, 15.35353f, -51.13312f),
                new Vector3(-82.34131f, 15.14353f, -51.48169f),
                new Vector3(-80.99036f, 16.02153f, -50.87964f),
                new Vector3(-79.72859f, 17.13753f, -48.45874f),
                new Vector3(-84.63441f, 17.14653f, -47.63836f),
                new Vector3(-84.38835f, 21.11453f, -48.40464f),
                new Vector3(-63.15419f, 6.025943f, -49.52284f),
                new Vector3(-58.95905f, 7.874783f, -51.73923f),
                new Vector3(-62.95973f, 9.598631f, -50.21825f),
                new Vector3(-59.25748f, 8.979921f, -49.27071f),
                new Vector3(-60.09724f, 11.31831f, -53.03792f),
                new Vector3(-63.05117f, 12.25367f, -48.12871f),
                new Vector3(-58.1805f, 13.44838f, -48.71068f),
                new Vector3(-58.90359f, 15.80136f, -51.37822f),
                new Vector3(-58.36787f, 15.58262f, -50.32631f),
                new Vector3(-58.76514f, 16.49715f, -48.83785f),
                new Vector3(-61.04786f, 17.65957f, -47.14228f),
                new Vector3(-62.69776f, 17.66895f, -52.0534f),
                new Vector3(-61.86916f, 21.80202f, -51.92622f),
                new Vector3(-44.30555f, 2.920716f, -66.11544f),
                new Vector3(-41.68658f, 5.250255f, -71.48949f),
                new Vector3(-44.62488f, 7.422303f, -66.96739f),
                new Vector3(-40.15449f, 6.642728f, -68.75668f),
                new Vector3(-43.81005f, 9.589102f, -71.96408f),
                new Vector3(-43.16405f, 10.76765f, -64.77399f),
                new Vector3(-38.64256f, 12.27299f, -68.98792f),
                new Vector3(-41.36172f, 15.23774f, -71.16351f),
                new Vector3(-40.03458f, 14.96213f, -70.49193f),
                new Vector3(-39.33181f, 16.11443f, -68.68251f),
                new Vector3(-40.39283f, 17.57909f, -65.26035f),
                new Vector3(-45.72309f, 17.5909f, -69.02885f),
                new Vector3(-44.78569f, 22.79857f, -69.51566f),
                new Vector3(-43.14882f, 5.494888f, -42.62029f),
                new Vector3(-39.41689f, 7.089929f, -40.93867f),
                new Vector3(-42.57234f, 8.577137f, -42.85639f),
                new Vector3(-41.25561f, 8.04336f, -39.83378f),
                new Vector3(-39.13585f, 10.06075f, -42.40173f),
                new Vector3(-44.04337f, 10.8677f, -41.8114f),
                new Vector3(-41.06619f, 11.89842f, -38.80379f),
                new Vector3(-39.63328f, 13.92839f, -40.70961f),
                new Vector3(-40.06555f, 13.73968f, -39.78749f),
                new Vector3(-41.28941f, 14.52866f, -39.26921f),
                new Vector3(-43.65339f, 15.53151f, -39.92482f),
                new Vector3(-41.18414f, 15.5396f, -43.6505f),
                new Vector3(-40.83164f, 19.1053f, -43.01898f),
                new Vector3(-56.51942f, 4.036837f, -76.52419f),
                new Vector3(-51.77613f, 6.237837f, -73.45737f),
                new Vector3(-55.68406f, 8.290037f, -76.72695f),
                new Vector3(-54.51342f, 7.553477f, -72.33065f),
                new Vector3(-51.08984f, 10.33728f, -75.39523f),
                new Vector3(-57.9073f, 11.4508f, -75.60583f),
                new Vector3(-54.46822f, 12.87308f, -70.88625f),
                new Vector3(-52.11877f, 15.67424f, -73.18968f),
                new Vector3(-52.89942f, 15.41384f, -72.02113f),
                new Vector3(-54.67641f, 16.50256f, -71.56743f),
                new Vector3(-57.76582f, 17.8864f, -72.95126f),
                new Vector3(-53.62576f, 17.89756f, -77.52294f),
                new Vector3(-53.27559f, 22.81788f, -76.58841f),
                new Vector3(-68.02914f, 5.386815f, -61.58509f),
                new Vector3(-73.67141f, 7.587814f, -61.3224f),
                new Vector3(-68.59091f, 9.640015f, -60.93442f),
                new Vector3(-72.09946f, 8.903455f, -63.83062f),
                new Vector3(-73.10307f, 11.68725f, -59.34673f),
                new Vector3(-67.43393f, 12.80077f, -63.13921f),
                new Vector3(-72.97603f, 14.22305f, -64.97952f),
                new Vector3(-73.54828f, 17.02421f, -61.73941f),
                new Vector3(-73.59258f, 16.76381f, -63.14404f),
                new Vector3(-72.4106f, 17.85254f, -64.54635f),
                new Vector3(-69.09246f, 19.23637f, -65.21671f),
                new Vector3(-69.80274f, 19.24753f, -59.09006f),
                new Vector3(-70.631f, 24.16785f, -59.6468f),
                new Vector3(-37.03019f, 6.372369f, -59.31695f),
                new Vector3(-31.32135f, 8.60887f, -59.90919f),
                new Vector3(-36.49785f, 10.69417f, -60.00948f),
                new Vector3(-32.77127f, 9.945728f, -57.27388f),
                new Vector3(-32.01198f, 12.77443f, -61.88067f),
                new Vector3(-37.54431f, 13.90591f, -57.70596f),
                new Vector3(-31.81567f, 15.35113f, -56.15894f),
                new Vector3(-31.42219f, 18.19747f, -59.47902f),
                new Vector3(-31.29616f, 17.93287f, -58.05661f),
                new Vector3(-32.41431f, 19.03915f, -56.56574f),
                new Vector3(-35.74181f, 20.44531f, -55.69411f),
                new Vector3(-35.37494f, 20.45665f, -61.95053f),
                new Vector3(-34.50254f, 25.45633f, -61.43353f),
                new Vector3(-42.19753f, 5.38853f, -47.01577f),
                new Vector3(-44.138f, 7.163529f, -51.13692f),
                new Vector3(-42.85588f, 8.818529f, -47.23296f),
                new Vector3(-41.78375f, 8.224529f, -50.74176f),
                new Vector3(-45.43374f, 10.46953f, -50.10266f),
                new Vector3(-40.85595f, 11.36753f, -47.05304f),
                new Vector3(-41.19912f, 12.51453f, -51.74992f),
                new Vector3(-43.78933f, 14.77353f, -51.17417f),
                new Vector3(-42.75686f, 14.56353f, -51.64153f),
                new Vector3(-41.34689f, 15.44153f, -51.19484f),
                new Vector3(-39.8215f, 16.55753f, -48.93077f),
                new Vector3(-44.60432f, 16.56653f, -47.56519f),
                new Vector3(-44.44577f, 20.53453f, -48.35425f),
                new Vector3(-70.00735f, 8.00665f, -47.91351f),
                new Vector3(-76.42206f, 10.77991f, -44.83089f),
                new Vector3(-70.33854f, 13.36568f, -46.88226f),
                new Vector3(-75.83377f, 12.43762f, -48.51394f),
                new Vector3(-74.79018f, 15.9452f, -42.81927f),
                new Vector3(-70.08215f, 17.34824f, -50.00907f),
                new Vector3(-77.41609f, 19.14031f, -49.41488f),
                new Vector3(-76.48456f, 22.66977f, -45.37518f),
                new Vector3(-77.22749f, 22.34167f, -46.98249f),
                new Vector3(-76.54703f, 23.71346f, -49.19087f),
                new Vector3(-73.02861f, 25.4571f, -51.60204f),
                new Vector3(-70.836f, 25.47116f, -44.14648f),
                new Vector3(-72.07074f, 31.67076f, -44.38442f),
                new Vector3(-52.65341f, 4.515944f, -51.47882f),
                new Vector3(-47.9175f, 6.364784f, -51.76634f),
                new Vector3(-52.18929f, 8.088633f, -52.03199f),
                new Vector3(-49.20808f, 7.469922f, -49.64101f),
                new Vector3(-48.41827f, 9.808313f, -53.41901f),
                new Vector3(-53.13492f, 10.74367f, -50.62844f),
                new Vector3(-48.45821f, 11.93839f, -48.68643f),
                new Vector3(-48.01597f, 14.29136f, -51.41462f),
                new Vector3(-47.96212f, 14.07262f, -50.23538f),
                new Vector3(-48.93826f, 14.98715f, -49.04355f),
                new Vector3(-51.71727f, 16.14957f, -48.44117f),
                new Vector3(-51.19331f, 16.15895f, -53.595f),
                new Vector3(-60.63f, 11.24f, -77.46f),
                new Vector3(-59.45f, 11.55f, -76.35f),
                new Vector3(-56.61f, 10.61f, -77.53f),
                new Vector3(-60.17f, 13.22f, -84.34f),
                new Vector3(-58.46f, 13.37f, -84.49f),
                new Vector3(-56.71f, 14.63f, -84.37f),
                new Vector3(-55f, 15.7f, -84.34f),
                new Vector3(-52.94f, 16.5f, -84.34f),
                new Vector3(-51.36f, 11.92f, -78.37f),
                new Vector3(-49.86f, 12.17f, -78.11f),
                new Vector3(-48.32f, 12.25f, -78.34f),
                new Vector3(-46.8f, 12.32f, -78.71f),
                new Vector3(-46.46f, 6.93f, -46.23f),
                new Vector3(-47.22f, 7.17f, -47.16f),
                new Vector3(-47.78f, 7.37f, -47.88f),
                new Vector3(-48.52f, 7.53f, -48.7f),
                new Vector3(-54.28f, 10.55f, -42.63f),
                new Vector3(-55.48f, 10.99f, -42.06f),
                new Vector3(-56.62f, 10.52f, -41.6f),
                new Vector3(-60.89f, 9.52f, -40.47f),
                new Vector3(-51.59f, 9.31f, -38.81f),
                new Vector3(-52.67f, 9.49f, -38.62f),
                new Vector3(-53.88f, 9.59f, -38.61f),
                new Vector3(-55.05f, 9.52f, -38.98f),
                new Vector3(-60.26f, 10.36f, -39.33f),
                new Vector3(-59.9f, 10.36f, -38.19f),
                new Vector3(-59.33f, 10.08f, -37.16f),
                new Vector3(-60.35f, 11.76f, -36.74f),
                new Vector3(-58.65f, 9.75f, -35.86f),
                new Vector3(-57.9f, 9.92f, -34.59f),
                new Vector3(-61.35f, 11.84f, -41.04f),
                new Vector3(-60.1f, 11.76f, -41.06f),
                new Vector3(-61.4f, 12.95f, -40f),
                new Vector3(-62.72f, 13.12f, -40.14f),
                new Vector3(-64.04f, 12.96f, -40.05f),
                new Vector3(-65.55f, 12.64f, -40.45f),
                new Vector3(-61.59f, 10.37f, -41.11f),
                new Vector3(-62.42f, 11.39f, -41.64f),
                new Vector3(-63.25f, 12.59f, -41.82f),
                new Vector3(-50.09f, 7.41f, -37.96f),
                new Vector3(-48.76f, 7.52f, -37.45f),
                new Vector3(-47.84f, 7.68f, -36.63f),
                new Vector3(-47.07f, 7.75f, -35.4f),
                new Vector3(-51.09f, 10.66f, -39.56f),
                new Vector3(-51.23f, 10.65f, -40.65f),
                new Vector3(-51.69f, 10.42f, -41.83f),
                new Vector3(-52.11f, 10.16f, -43.2f),
                new Vector3(-52.59f, 9.93f, -44.35f)
            };
            Transform closestHand = null;
            Vector3 closestBranch = Vector3.zero;
            float closestDistance = float.MaxValue;
            foreach (Vector3 branchPos in branches)
            {
                if (Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position, branchPos) < closestDistance)
                {
                    closestDistance = Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position, branchPos);
                    closestHand = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform;
                    closestBranch = branchPos;
                }
                if (Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, branchPos) < closestDistance)
                {
                    closestDistance = Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, branchPos);
                    closestHand = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform;
                    closestBranch = branchPos;
                }
            }
            if (closestHand != null)
            {
                closestHand.position = closestBranch;
            }
        }

        public static async void SpoofPlayer()
        {
            var rig = GorillaTagger.Instance.offlineVRRig;
            await Task.Delay(1000);        
            rig.enabled = false;
            rig.transform.position = new Vector3(-68.2701f, 11.9954f, -82.7281f);
            rig.transform.rotation = Quaternion.Euler(new Vector3(0f, -100f, 0f));
            rig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0f, -0.5f);
            rig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0f, 0f);
            ChangeColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            await Task.Delay(1500);
            string[] names = new string[]
            {
                "GLXY",
                "DORITOZ",
                "DR9G0N",
                "WATER",
                "Singularity",
                "MODDER",
                "DASANI09",
                "KAICENAT",
                "DUKEDENESE",
                "U3VJ",
            };
            ChangeName(names[Random.Range(0, names.Length)]);
            rig.enabled = false;
            rig.transform.position = new Vector3(-65.6804f, 12.0864f, -80.9601f);
            rig.transform.rotation = Quaternion.Euler(new Vector3(0f, 50f, 0f));
            rig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0f, -0.5f);
            rig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0f, -0.5f);
            Safety.flush();
            await Task.Delay(1000);
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void ChangeColor(Color color)
        {
            PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
            PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
            PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));
            GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
            PlayerPrefs.Save();
            try
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", 0, new object[]
                {
                    color.r,
                    color.g,
                    color.b
                });
                Safety.flush();
            }
            catch (Exception ex) { Debug.Log($"<color=red>[Error]</color>: {ex.Message}"); }
        }

        public static void ChangeName(string name)
        {
            try
            {
                PhotonNetwork.LocalPlayer.NickName = name;
                PhotonNetwork.NickName = name;
                PhotonNetwork.NetworkingClient.NickName = name;
                GorillaComputer.instance.currentName = name;
                GorillaComputer.instance.savedName = name;
                GTPlayer.Instance.name = name;
                NetworkSystem.Instance.name = name;
                NetworkSystem.Instance.SetMyNickName(name);
                PlayerPrefs.SetString("playerName", name);
                PlayerPrefs.Save();
            }
            catch (Exception ex)
            {
                Debug.Log($"<color=red>[Error]</color>: {ex.Message}");
            }
        }

        public static async void DelayTP(NetPlayer player)
        {
            await Task.Delay(3000);
        }

        public static async void DelayTP2(NetPlayer player)
        {
            await Task.Delay(6000);
        }

        public static void followgun()
        {
            mods.GunTemplateLockon(delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, mods.lockon.transform.position, Time.deltaTime * 5f);
                GorillaTagger.Instance.offlineVRRig.transform.LookAt(mods.lockon.transform);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }, null, true);
        }

        public static void copygun()
        {
            mods.GunTemplateLockon(delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position;
                GorillaTagger.Instance.offlineVRRig.transform.rotation = mods.lockon.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = mods.lockon.head.rigTarget.position;
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = mods.lockon.head.rigTarget.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = mods.lockon.leftHand.rigTarget.position;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = mods.lockon.leftHand.rigTarget.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = mods.lockon.rightHand.rigTarget.position;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = mods.lockon.rightHand.rigTarget.rotation;
            }, null, true);
        }



        public static void enablerig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void followclosest()
        {
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 7;
                    var vrrigBody = vrrig.transform.position;
                    var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                    var bdy = Vector3.Distance(vrrigBody, bdyc);
                    if (bdy <= distance)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position, Time.deltaTime * 15f);
                        GorillaTagger.Instance.offlineVRRig.transform.LookAt(vrrig.transform.position);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                    else
                    {
                        enablerig();
                    }
                }
            }
        }



        public static void copyclosest()
        {
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 4;
                    var vrrigBody = vrrig.transform.position;
                    var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                    var bdy = Vector3.Distance(vrrigBody, bdyc);
                    if (bdy <= distance)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = vrrig.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = vrrig.head.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = vrrig.head.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = vrrig.leftHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = vrrig.leftHand.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = vrrig.rightHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = vrrig.rightHand.rigTarget.rotation;
                    }
                    else
                    {
                        enablerig();
                    }
                }
            }
        }



        public static PhotonView GetPhotonViewFromVRRig(VRRig p)
        {
            return GetNetworkViewFromVRRig(p).GetView;
        }
        public static NetworkView GetNetworkViewFromVRRig(VRRig p)
        {
            return (NetworkView)Traverse.Create(p).Field("netView").GetValue();
        }

        // please don't skid :) and if you do i will touch you. at lease give credits ???!?
        public static void InvizOnTouch()
        {
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 0.52;
                    var vrrighandR = vrrig.rightHandTransform.position;
                    var vrrighandL = vrrig.leftHandTransform.position;
                    var hmpos = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    var rh = Vector3.Distance(vrrighandR, hmpos);
                    var lh = Vector3.Distance(vrrighandL, hmpos);
                    if (rh <= 0.5 || lh <= 0.5)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 0f, 0f);
                    }
                }
            }
        }


        public static void GhostOnTouch()
        {
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 0.52;
                    var vrrighandR = vrrig.rightHandTransform.position;
                    var vrrighandL = vrrig.leftHandTransform.position;
                    var hmpos = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    var rh = Vector3.Distance(vrrighandR, hmpos);
                    var lh = Vector3.Distance(vrrighandL, hmpos);
                    if (rh <= 0.5 || lh <= 0.5)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
        }
    }
}
