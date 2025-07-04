using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using BepInEx;
using GorillaLocomotion;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using StupidTemplate.Patches;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AetherTemp.Menu
{
    internal class Advantages
    {

        public static Texture2D LoadImageFromUrl(string url, string name)
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullPath = Path.Combine(directory, name);
            Texture2D text = new Texture2D(1, 1);
            try
            {
                if (!File.Exists(fullPath))
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(url, fullPath);
                    }
                }

                byte[] imageData = File.ReadAllBytes(fullPath);
                text.LoadImage(imageData);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Failed to load image: {ex.Message}");
            }
            return text;
        }



        public static Vector3 pos;
        public static Vector3 normal;
        public static WallWalkType wallWalkType;

        public enum WallWalkType
        {
            weak,
            normal,
            strong,
        }

        public static int r = 0;
        public static void ChangeWallWalkType()
        {
            r++;
            if (r > 2)
            {
                r = 0;
            }

            if (r == 0)
            {
                wallWalkType = WallWalkType.weak;
                Main.GetIndex("Wall Walk Type:").overlapText = "<color=red>Weak</color>";
            }
            if (r == 1)
            {
                wallWalkType = WallWalkType.normal;
                Main.GetIndex("Wall Walk Type:").overlapText = "<color=red>Normal</color>";
            }
            if (r == 2)
            {
                wallWalkType = WallWalkType.strong;
                Main.GetIndex("Wall Walk Type:").overlapText = "<color=red>Strong</color>";
            }
        }



        public static void WallWalk()
        {
            if (wallWalkType == WallWalkType.weak)
            {
                if (GTPlayer.Instance.IsHandTouching(true))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.leftHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                else if (GTPlayer.Instance.IsHandTouching(false))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.rightHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                if (pos != Vector3.zero && ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(normal * -6f, ForceMode.Acceleration);
                    GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
                }
            }
            else if (wallWalkType == WallWalkType.normal)
            {
                if (GTPlayer.Instance.IsHandTouching(true))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.leftHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                else if (GTPlayer.Instance.IsHandTouching(false))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.rightHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                if (pos != Vector3.zero && ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(normal * -10f, ForceMode.Acceleration);
                    GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
                }
            }
            else if (wallWalkType == WallWalkType.strong)
            {
                if (GTPlayer.Instance.IsHandTouching(true))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.leftHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                else if (GTPlayer.Instance.IsHandTouching(false))
                {
                    RaycastHit raycastHit = GTPlayer.Instance.rightHandHitInfo;
                    pos = raycastHit.point;
                    normal = raycastHit.normal;
                }
                if (pos != Vector3.zero && ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(normal * -80f, ForceMode.Acceleration);
                    GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
                }
            }
        }



        public static void TagAura()
        {
            VRRig vrrig = null;
            float num;
            var bdyPos = GorillaTagger.Instance.bodyCollider.transform.position;
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrrigs.isOfflineVRRig && !vrrigs.isMyPlayer)
                {
                    if (!vrrigs.lavaParticleSystem.isPlaying || !vrrigs.rockParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.lavaParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.rockParticleSystem.isPlaying)
                    {
                        if (Vector3.Distance(bdyPos, vrrigs.transform.position) < 7)
                        {
                            num = Vector3.Distance(bdyPos, vrrigs.transform.position);
                            vrrig = vrrigs;
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                        }
                    }
                }
            }
        }


        public static void AntiTag()
        {
            float num;
            VRRig vrrig = null;
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrrigs.isOfflineVRRig && !vrrigs.isMyPlayer)
                {
                    if (vrrigs.lavaParticleSystem.isPlaying || vrrigs.rockParticleSystem.isPlaying || !GorillaTagger.Instance.offlineVRRig.lavaParticleSystem.isPlaying || !GorillaTagger.Instance.offlineVRRig.rockParticleSystem.isPlaying)
                    {
                        if (Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrigs.transform.position) < 4)
                        {
                            num = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrigs.transform.position);
                            vrrig = vrrigs;
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = -100;
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0;
                        }
                    }
                }
            }
        }

        public static void TagSelf()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (InputLib.RT() || Mouse.current.rightButton.isPressed)
                {
                    if (vrrigs.lavaParticleSystem.isPlaying || vrrigs.rockParticleSystem.isPlaying || !GorillaTagger.Instance.offlineVRRig.lavaParticleSystem.isPlaying || !GorillaTagger.Instance.offlineVRRig.rockParticleSystem.isPlaying)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrigs.rightHandTransform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = vrrigs.rightHandTransform.position;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void TagAll()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrrigs.lavaParticleSystem.isPlaying || !vrrigs.rockParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.lavaParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.rockParticleSystem.isPlaying)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = vrrigs.transform.position + Vector3.up;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = vrrigs.transform.position;
                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = vrrigs.transform.position;
                    GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = vrrigs.transform.position;
                }
            }
        }
          

        public static VRRig lockon;
        public static VRRig rigg;


        public static void TagGun()
        {
            mods.GunTemplateLockon(delegate
            {
                if (!mods.lockon.lavaParticleSystem.isPlaying || !mods.lockon.rockParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.lavaParticleSystem.isPlaying || GorillaTagger.Instance.offlineVRRig.rockParticleSystem.isPlaying)
                {
                    mods.lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                    mods.lineRenderer.SetPosition(1, mods.lockon.transform.position);
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = mods.lockon.transform.position + Vector3.up;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = mods.lockon.transform.position;
                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = mods.lockon.transform.position;
                    GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = mods.lockon.transform.position;
                }
            }, null, true);
        }
    }
}
