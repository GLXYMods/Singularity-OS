using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Menu;
using UnityEngine;

namespace Singularity_OS.Menu
{
    public class Overpowered
    {


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
