using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;
using StupidTemplate.Menu;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Singularity_OS.Menu
{
    public class Rig
    {
        public static void ItemStandThing()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;
            Quaternion rot = Quaternion.Euler(ins.transform.rotation.eulerAngles + new Vector3(0f, 50f * Time.deltaTime, 0f));

            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                ins.enabled = false;
                ins.transform.rotation = rot;
                ins.head.rigTarget.transform.rotation = ins.transform.rotation;
                ins.rightHand.rigTarget.transform.rotation = ins.transform.rotation;
                ins.leftHand.rigTarget.transform.rotation = ins.transform.rotation;
                ins.rightHand.rigTarget.transform.position = ins.transform.position + ins.transform.up * -0.5f;
                ins.leftHand.rigTarget.transform.position = ins.transform.position + ins.transform.up * -0.5f;

                ins.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.leftHand.trackingRotationOffset);
                ins.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.rightHand.trackingRotationOffset);
            }
            else
            {
                ins.enabled = true;
            }
        }

        public static void Spin()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;
            Quaternion rot = Quaternion.Euler(ins.transform.rotation.eulerAngles + new Vector3(0f, 400f * Time.deltaTime, 0f));

            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                ins.enabled = false;
                ins.transform.rotation = rot;
                ins.head.rigTarget.transform.rotation = ins.transform.rotation;
                ins.rightHand.rigTarget.transform.rotation = ins.transform.rotation;
                ins.leftHand.rigTarget.transform.rotation = ins.transform.rotation;
                ins.rightHand.rigTarget.transform.position = ins.transform.position + ins.transform.right * 1.5f;
                ins.leftHand.rigTarget.transform.position = ins.transform.position + ins.transform.right * -1.5f;

                ins.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.leftHand.trackingRotationOffset);
                ins.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.rightHand.trackingRotationOffset);
            }
            else
            {
                ins.enabled = true;
            }
        }


        public static float delay;
        private static float spinSpeed = 25f;
        private static float ascendSpeed = 0.5f;
        private static float timer = 0f;

        public static void Ascend()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;

            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                ins.enabled = false;
                ins.transform.position += new Vector3(0f, 0.1f, 0f);
            }
            else
            {
                ins.enabled = true;
            }
        }

        public static void Helicopter()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;

            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                timer += Time.deltaTime;
                ascendSpeed = 0.5f + timer * 0.5f;
                spinSpeed = 25f + timer * 50f;

                Vector3 pos = new Vector3(0f, ascendSpeed * Time.deltaTime, 0f);
                Quaternion rot = Quaternion.Euler(ins.transform.rotation.eulerAngles + new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
                float num3 = 0.5f;
                ins.enabled = false;
                ins.transform.position += pos;
                ins.transform.rotation = rot;
                ins.head.rigTarget.transform.rotation = ins.transform.rotation;
                ins.rightHand.rigTarget.transform.position = ins.transform.position + ins.transform.right * num3;
                ins.rightHand.rigTarget.transform.rotation = ins.transform.rotation;
                ins.leftHand.rigTarget.transform.position = ins.transform.position + ins.transform.right * -num3;
                ins.leftHand.rigTarget.transform.rotation = ins.transform.rotation;

                ins.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.leftHand.trackingRotationOffset);
                ins.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(ins.rightHand.trackingRotationOffset);
            }
            else
            {
                timer = 0f;
                spinSpeed = 20f;
                ascendSpeed = 0.1f;
                ins.enabled = true;
            }
        }

        public static void grab()
        {
            var ins = GorillaTagger.Instance.offlineVRRig;
            var plr = GorillaLocomotion.GTPlayer.Instance;
            if (ControllerInputPoller.instance.rightGrab)
            {
                ins.enabled = false;
                ins.transform.position = plr.rightControllerTransform.position;
            }
            else
            {
                ins.enabled = true;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                ins.enabled = false;
                ins.transform.position = plr.leftControllerTransform.position;
            }
            else
            {
                ins.enabled = true;
            }
        }

        public static void riggun()
        {
            mods.GunTemplate(delegate
            { 
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = mods.GunSphere.transform.position + new Vector3(0f, 1f, 0f);
            }, null, true);
        }

        public static void freeze()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
                GorillaTagger.Instance.myVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static bool Rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
        public static bool Lp = ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool Rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
        public static bool Ls = ControllerInputPoller.instance.leftControllerSecondaryButton;
        public static bool Lg = ControllerInputPoller.instance.leftGrab;
        public static bool Rg = ControllerInputPoller.instance.rightGrab;
        public static bool ghost = false;
        public static bool ghost1 = false;
        public static bool inviz = false;
        public static bool inviz1 = false;
        public static VRRig rig;
        public static void Ghost()
        {
            bool Rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
            if (!ghost && Rp || Mouse.current.rightButton.isPressed)
            {
                ghost1 = !ghost1;
            }
            ghost = Rp || Mouse.current.rightButton.isPressed;
            if (ghost1)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void Inviz()
        {
            bool Rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (!inviz && Rs)
            {
                inviz1 = !inviz1;
            }
            inviz = Rs;
            if (inviz1)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 0f, 0f);
            }
            if (Keyboard.current.hKey.wasPressedThisFrame)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
            }
        }

        public static void FakeOculusMenu()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GTPlayer.Instance.rightControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;
                GTPlayer.Instance.leftControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;
            }
        }
    }
}
