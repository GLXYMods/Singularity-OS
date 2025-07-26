using GorillaLocomotion;
using GorillaTag;
using BepInEx;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using StupidTemplate.Notifications;
using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Classes;
using UnityEngine.UI;
using GorillaNetworking;

namespace AetherTemp.Menu
{
    public class Fun
    {
        public static void KissGun()
        {
            mods.GunTemplateLockon(() =>
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + mods.lockon.transform.forward * (0.4f + Mathf.Sin(Time.frameCount / 10f) * 0.1f);
                GorillaTagger.Instance.offlineVRRig.transform.LookAt(mods.lockon.transform.position);
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * 0.15f) + mods.lockon.transform.up * 0.15f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * -0.15f) + mods.lockon.transform.up * 0.15f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }, null, true);
        }
        public static void GetSexGun()
        {
            mods.GunTemplateLockon(() =>
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + (mods.lockon.transform.forward * (0.4f + (Mathf.Sin(Time.frameCount / 10f) * 0.1f)));
                GorillaTagger.Instance.offlineVRRig.transform.rotation = mods.lockon.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * -0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * 0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }, null, true);
        }

        public static void SexGun()
        {
            mods.GunTemplateLockon(() =>
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + (mods.lockon.transform.forward * -(0.4f + (Mathf.Sin(Time.frameCount / 10f) * 0.1f)));
                GorillaTagger.Instance.offlineVRRig.transform.rotation = mods.lockon.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * -0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * 0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }, null, true);
        }

        public static void SexRandom()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                var vrrig = RigManager.GetRandomVRRig(false);
                var rig = GorillaTagger.Instance.offlineVRRig;
                rig.transform.position = vrrig.transform.position + (vrrig.transform.forward * -(0.4f + (Mathf.Sin(Time.frameCount / 10f) * 0.1f)));
                rig.transform.rotation = vrrig.transform.rotation;
                rig.leftHand.rigTarget.transform.position = (vrrig.transform.position + vrrig.transform.right * -0.15f) + vrrig.transform.up * -0.3f;
                rig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rig.rightHand.rigTarget.transform.position = (vrrig.transform.position + vrrig.transform.right * 0.15f) + vrrig.transform.up * -0.3f;
                rig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
                GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void HeadGun()
        {
            mods.GunTemplateLockon(() =>
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + (mods.lockon.transform.forward * (0.4f + (Mathf.Sin(Time.frameCount / 6f) * 0.1f))) + (mods.lockon.transform.up * -0.4f);
                GorillaTagger.Instance.offlineVRRig.transform.rotation = mods.lockon.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * 0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * -0.15f) + mods.lockon.transform.up * -0.3f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            }, null, true);
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void HeadRandom()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                var rig = GorillaTagger.Instance.offlineVRRig;
                var vrrigs = RigManager.GetRandomVRRig(false);
                rig.transform.position = vrrigs.transform.position + (vrrigs.transform.forward * (0.4f + (Mathf.Sin(Time.frameCount / 6f) * 0.1f))) + (vrrigs.transform.up * -0.4f);
                rig.transform.rotation = vrrigs.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                rig.leftHand.rigTarget.transform.position = (vrrigs.transform.position + vrrigs.transform.right * 0.15f) + vrrigs.transform.up * -0.3f;
                rig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rig.rightHand.rigTarget.transform.position = (vrrigs.transform.position + vrrigs.transform.right * -0.15f) + vrrigs.transform.up * -0.3f;
                rig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
                GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void GetHeadGun()
        {
            mods.GunTemplateLockon(() =>
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + (mods.lockon.transform.forward * (0.4f + (Mathf.Sin(Time.frameCount / 6f) * 0.1f))) + (mods.lockon.transform.up * 0.4f);
                GorillaTagger.Instance.offlineVRRig.transform.rotation = mods.lockon.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * 0.15f) + mods.lockon.transform.up * 0.15f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (mods.lockon.transform.position + mods.lockon.transform.right * -0.15f) + mods.lockon.transform.up * 0.15f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            }, null, true);
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void GetHeadRandom()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                var rig = GorillaTagger.Instance.offlineVRRig;
                var vrrigs = RigManager.GetRandomVRRig(false);
                rig.transform.position = vrrigs.transform.position + (vrrigs.transform.forward * (0.4f + (Mathf.Sin(Time.frameCount / 6f) * 0.1f))) + (vrrigs.transform.up * 0.4f);
                rig.transform.rotation = vrrigs.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                rig.leftHand.rigTarget.transform.position = (vrrigs.transform.position + vrrigs.transform.right * 0.15f) + vrrigs.transform.up * 0.15f;
                rig.leftHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rig.rightHand.rigTarget.transform.position = (vrrigs.transform.position + vrrigs.transform.right * -0.15f) + vrrigs.transform.up * 0.15f;
                rig.rightHand.rigTarget.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
                GorillaTagger.Instance.offlineVRRig.enabled = true;
        }


        static GameObject point;
        public static void ClickButtonsWithPC()
        {
            RaycastHit raycastHit;
            Ray ray = GameObject.Find("Shoulder Camera").activeSelf ? GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition) : GorillaTagger.Instance.mainCamera.GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);
            if (Physics.Raycast(ray, out raycastHit) && point == null)
            {
                point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(point.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(point.GetComponent<SphereCollider>());
                point.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                point.GetComponent<Renderer>().material.color = Color.red;
                point.GetComponent<Renderer>().enabled = false;
                point.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            }
            point.transform.position = raycastHit.point;
            bool mouseButton = UnityInput.Current.GetMouseButton(0);
            if (mouseButton)
            {
                var pressable = raycastHit.collider.GetComponent<GorillaPressableButton>();
                if (pressable != null && Time.time > delay)
                {
                    delay = Time.time + 0.2f;
                    pressable.ButtonActivation();
                }
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
        }

        public static float delay;

        public static void SendWaterRPC(Vector3 pos, Quaternion rot)
        {
            if (PhotonNetwork.InRoom && GorillaTagger.Instance.myVRRig != null)
            {
                if (delay < Time.time)
                {
                    delay = Time.time + 0.2f;
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[]
                    {
                        pos,
                        rot,
                        3f,
                        50f,
                        true,
                        false,
                    });
                }
            }
            else
            {
                if (delay < Time.time)
                {
                    delay = Time.time + 0.2f;
                    ObjectPools.instance.Instantiate(GorillaLocomotion.GTPlayer.Instance.waterParams.rippleEffect, pos, rot, GorillaLocomotion.GTPlayer.Instance.waterParams.rippleEffectScale * 5f);
                    ObjectPools.instance.Instantiate(GorillaLocomotion.GTPlayer.Instance.waterParams.splashEffect, pos, rot, 5f).GetComponent<WaterSplashEffect>().PlayEffect(true, false, 5f, null);
                }
            }
        }

        public static void WaterL()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                SendWaterRPC(GTPlayer.Instance.leftControllerTransform.position, GTPlayer.Instance.leftControllerTransform.rotation);
            }
        }

        public static void WaterR()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                SendWaterRPC(GTPlayer.Instance.rightControllerTransform.position, GTPlayer.Instance.rightControllerTransform.rotation);
            }
        }

        public static void WaterGun()
        {
            mods.GunTemplate(delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.GunSphere.transform.position + new Vector3(0f, -0.7f, 0f);
                SendWaterRPC(mods.GunSphere.transform.position, mods.GunSphere.transform.rotation);
            }, delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }, false);
        }
        
        public static void GiveWaterGun()
        {
            mods.GunTemplateLockon(delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + new Vector3(0f, -0.7f, 0f);
                SendWaterRPC(mods.lockon.rightHandTransform.position, mods.lockon.rightHandTransform.rotation);
            }, delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }, false);
        }

        public static void GetBraclet(bool enable, bool leftHand)
        {
            GorillaTagger.Instance.myVRRig.SendRPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
            {
                enable,
                leftHand,
            });
        }

        public static void BraceletL()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GetBraclet(true, true);
            }
            else
            {
                GetBraclet(false, false);
            }
        }

        public static void BraceletR()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GetBraclet(true, false);
            }
            else
            {
                GetBraclet(false, false);
            }
        }


        public static void RCcar()
        {
            var bug = GameObject.Find("Floating Bug Holdable");
            if (ControllerInputPoller.instance.leftControllerPrimary2DAxis.y > 0.5f)
            {
                bug.transform.position = (bug.transform.forward * Time.deltaTime) * 10f;
            }
            if (ControllerInputPoller.instance.leftControllerPrimary2DAxis.y < -0.5f)
            {
                bug.transform.position = (bug.transform.forward * Time.deltaTime) * -10f;
            }
            if (ControllerInputPoller.instance.leftControllerPrimary2DAxis.x > 0.5f)
            {
                bug.transform.position = (bug.transform.right * Time.deltaTime) * -10f;
            }
            if (ControllerInputPoller.instance.leftControllerPrimary2DAxis.x < -0.5f)
            {
                bug.transform.position = (bug.transform.right * Time.deltaTime) * 10f;
            }
        }


        public static void GrabAllIds()
        {
            if (PhotonNetwork.InRoom)
            {
                string list = "==============Player Id's==============!";
                foreach (VRRig rigs in GorillaParent.instance.vrrigs)
                {
                    if (!rigs.isOfflineVRRig && !rigs.isMyPlayer)
                    {
                        list += rigs.OwningNetPlayer.NickName + " - User Id : " + rigs.OwningNetPlayer.UserId + "\n";
                    }
                }
                Directory.CreateDirectory("SingularityOS");
                File.AppendAllText("SingularityOS\\Ids.txt", list);
                NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Grabbed Id's!");
            }
        }

        public static void copyIDgun()
        {
            mods.GunTemplateLockon(delegate
            {
                string list = $"{mods.lockon.OwningNetPlayer.NickName}";
                list += "User Id: " + mods.lockon.OwningNetPlayer.UserId;
                System.IO.Directory.CreateDirectory("SingularityOS");
                System.IO.File.AppendAllText($"SingularityOS\\{mods.lockon.OwningNetPlayer.NickName}.txt", list);
            }, null, true);
        }




        static GameObject
                drawL, drawR;
        public static void DrawRGB()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                float h = (Time.frameCount / 180f) % 1f;
                drawL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(drawL.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(drawL.GetComponent<SphereCollider>());
                drawL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                drawL.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                drawL.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                drawL.transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                drawL.transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                float h = (Time.frameCount / 180f) % 1f;
                drawR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(drawR.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(drawR.GetComponent<SphereCollider>());
                drawR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                drawR.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                drawR.transform.position = GorillaTagger.Instance.leftHandTransform.transform.position;
                drawR.transform.rotation = GorillaTagger.Instance.leftHandTransform.transform.rotation;
                drawR.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
            }
        }

        public static void RGBDrawOFF()
        {
            GameObject.Destroy(drawL);
            GameObject.Destroy(drawR);
            drawL = null;
            drawR = null;
        }



        public static void HandsINhead()
        {
            GTPlayer.Instance.rightControllerTransform.transform.position = GTPlayer.Instance.headCollider.transform.position;
            GTPlayer.Instance.leftControllerTransform.transform.position = GTPlayer.Instance.headCollider.transform.position;
        }

        public static void Snow()
        {
            float h = (Time.frameCount / 180f) % 1f;
            GameObject snow = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/snow partic");
            snow.SetActive(true);
            snow.GetComponent<Renderer>().enabled = true;
            snow.GetComponent<Renderer>().material.color = Color.HSVToRGB(h, 1f, 1f);
        }
        public static void SnowOff()
        {
            float h = (Time.frameCount / 180f) % 1f;
            GameObject snow = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/snow/snow partic");
            snow.SetActive(true);
            snow.GetComponent<Renderer>().enabled = true;
            snow.GetComponent<Renderer>().material.color = Color.white;
        }

        public static void kickAll()
        {
           foreach (VRRig rigs in GorillaParent.instance.vrrigs)
           {
                Renderer[] renderers = rigs.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    r.enabled = false;
                }

                AudioSource[] audioSources = rigs.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.enabled = false;
                }

                MeshCollider[] colliders = rigs.GetComponentsInChildren<MeshCollider>();
                foreach (MeshCollider m in colliders)
                {
                    m.enabled = false;
                }
           }
        }

        public static void disable()
        {
           foreach (VRRig rigs in GorillaParent.instance.vrrigs)
           {
                Renderer[] renderers = rigs.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    r.enabled = true;
                }

                AudioSource[] audioSources = rigs.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.enabled = true;
                }

                MeshCollider[] colliders = rigs.GetComponentsInChildren<MeshCollider>();
                foreach (MeshCollider m in colliders)
                {
                    m.enabled = true;
                }
           }
        }

        public static bool sentAlr = true;
        public static void FakeKickGun()
        {
            mods.GunTemplateLockon(delegate
            {
                Renderer[] renderers = mods.lockon.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    r.enabled = false;
                }

                AudioSource[] audioSources = mods.lockon.GetComponentsInChildren<AudioSource>();
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.enabled = false;
                }

                MeshCollider[] colliders = mods.lockon.GetComponentsInChildren<MeshCollider>();
                foreach (MeshCollider m in colliders)
                {
                    m.enabled = false;
                }

                sentAlr = false;
            }, delegate {
                    Renderer[] renderers = mods.lockon.GetComponentsInChildren<Renderer>();
                    foreach (Renderer r in renderers)
                    {
                        r.enabled = true;
                    }

                    AudioSource[] audioSources = mods.lockon.GetComponentsInChildren<AudioSource>();
                    foreach (AudioSource audioSource in audioSources)
                    {
                        audioSource.enabled = true;
                    }

                    MeshCollider[] colliders = mods.lockon.GetComponentsInChildren<MeshCollider>();
                    foreach (MeshCollider m in colliders)
                    {
                        m.enabled = true;
                    }
                    sentAlr = true;
            }, false);

            if (!sentAlr)
            {
                NotifiLib.SendNotification($"<color=blue>[Menu]</color>: <color=red>{mods.lockon.OwningNetPlayer.NickName} HAS BEEN KICKED!</color>");
            }
        }



    }
}
