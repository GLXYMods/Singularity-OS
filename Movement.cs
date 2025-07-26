using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Unity;
using UnityEngine.InputSystem;
using StupidTemplate.Classes;
using BepInEx;
using StupidTemplate.Menu;
using Random = UnityEngine.Random;
using GorillaLocomotion;
using static StupidTemplate.Menu.Main;
using Photon.Pun;
using System.Linq;
using static StupidTemplate.Mods.InputLib;
using Player = GorillaLocomotion.GTPlayer;
using Singularity_OS.Patches;

namespace AetherTemp.Menu
{
    public class Movement
    {

        public static bool shit = true;

        public static void BrokenControllerRIGHT()
        {
            GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.transform.position;
        }

        public static void BrokenControllerLEFT()
        {
            GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.position;
        }
        public static void ThrowControllers()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.transform.position + new Vector3(0f, -1.4f, 0f);
                GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.leftHandTransform.transform.position + new Vector3(0f, -1.4f, 0f);
            }
        }
        public static void LowGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void ZeroGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void HighGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.down * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void RGrip()
        {
            ControllerInputPoller.instance.rightGrab = true;
        }


        public static void LGrip()
        {
            ControllerInputPoller.instance.leftGrab = true;
        }

        public static void RPrim()
        {
            ControllerInputPoller.instance.rightControllerPrimaryButton = true;
        }

        public static void LPrim()
        {
            ControllerInputPoller.instance.leftControllerPrimaryButton = true;
        }

        public static void LSec()
        {
            ControllerInputPoller.instance.leftControllerSecondaryButton = true;
        }

        public static void RSec()
        {
            ControllerInputPoller.instance.rightControllerSecondaryButton = true;
        }

        public static void RTrig()
        {
            ControllerInputPoller.instance.rightControllerIndexFloat = 1f;
        }


        public static void LTrig()
        {
            ControllerInputPoller.instance.leftControllerIndexFloat = 1f;
        }




        public static void Slingshit()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.forward * (Time.deltaTime * (20f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }


        public static void SlingshitUp()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (20f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }

        public static void SlingshitDown()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (-20f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }












        public static void JoystickFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.right * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.right * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }

        public static void carmonke()
        {
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.forward * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.forward * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }
        private static bool dashed = false;
        private static bool dashing = false;
        private static float delay;
        public static void dash()
        {
            bool rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
            bool rmb = Mouse.current.rightButton.wasPressedThisFrame;

            if (rmb)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity = Player.Instance.headCollider.transform.forward * 9f;
            }

            if (rp && Time.time > delay)
            {
                delay = Time.time + 1.5f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Player.Instance.headCollider.transform.forward * 9f;
            }
        }
        public static void Speed()
        {
            Player.Instance.maxJumpSpeed = 8f;
            Player.Instance.jumpMultiplier = 2f;
        }
        public static void mosa()
        {
            Player.Instance.maxJumpSpeed = 6f;
            Player.Instance.jumpMultiplier = 3.5f;
        }

        public static void mega()
        {
            Player.Instance.maxJumpSpeed = 11f;
            Player.Instance.jumpMultiplier = 7f;
        }

        public static void SlideControl()
        {
            Player.Instance.slideControl = 9999f;
        }

        static GameObject checkpoint = null;
        public static void check()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (checkpoint == null)
                {
                    checkpoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    checkpoint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    checkpoint.GetComponent<Renderer>().material.color = menuColor;
                    checkpoint.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(checkpoint.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(checkpoint.GetComponent<Rigidbody>());
                }
                checkpoint.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
            }
            if (checkpoint != null)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    bool mesh = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
                    MeshCollider[] mesh2 = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshcollider in mesh2)
                    {
                        if (mesh)
                        {
                            meshcollider.enabled = !false;
                            Player.Instance.transform.position = checkpoint.transform.position;
                            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }
                    }

                }
                else
                {
                    bool mesh = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
                    MeshCollider[] mesh2 = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshcollider in mesh2)
                    {
                        if (!mesh)
                        {
                            meshcollider.enabled = true;
                        }
                    }
                }
            }
        }

        public static void disablecheck()
        {
            if (checkpoint != null)
            {
                UnityEngine.Object.Destroy(checkpoint);
                checkpoint = null;
            }
        }



        static GameObject point = null;

        public static void TpToStump()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-63.8717f, 12.1881f, -83.0144f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void TpToTut()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-86.6707f, 36.4451f, -65.8458f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }


        public static void TpToCity()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-66.9824f, 14.0115f, -97.0772f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }

        static VRRig ghostRig = null;
        public static void TpGun()
        {
            mods.GunTemplate(delegate
            {
                if (Mouse.current.leftButton.isPressed && Time.time > delay || ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f && Time.time > delay)
                {
                    delay = Time.time + 1f;
                    GTPlayer.Instance.transform.position = mods.GunSphere.transform.position;
                }              
            }, null, true);
        }


        static GameObject ironL, ironR;
        public static void iron()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * -GorillaTagger.Instance.leftHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ParticleSystem particleSystem2 = new GameObject("LeftIronParticle").AddComponent<ParticleSystem>();
                particleSystem2.transform.position = Player.Instance.leftControllerTransform.position;
                particleSystem2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                particleSystem2.transform.rotation = Player.Instance.leftControllerTransform.rotation;
                particleSystem2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                GradientColorKey[] array = new GradientColorKey[3];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = new Color32(230, 108, 44, 255);
                array[1].time = 0.5f;
                array[2].color = Color.red;
                array[2].time = 1f;
                ColorChanger colorChanger = particleSystem2.AddComponent<ColorChanger>();
                colorChanger.colorInfo = new ExtGradient
                {
                    colors = array
                };
                colorChanger.Start();
                particleSystem2.GetComponent<Renderer>().material.color = Color.red;
                particleSystem2.Play();
                GameObject.Destroy(particleSystem2, 0.5f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * GorillaTagger.Instance.rightHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ParticleSystem particleSystem = new GameObject("RightIronParticle").AddComponent<ParticleSystem>();
                particleSystem.transform.position = Player.Instance.rightControllerTransform.position;
                particleSystem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                particleSystem.transform.rotation = Player.Instance.rightControllerTransform.rotation;
                particleSystem.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                GradientColorKey[] array = new GradientColorKey[3];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = new Color32(230, 108, 44, 255);
                array[1].time = 0.5f;
                array[2].color = Color.red;
                array[2].time = 1f;
                ColorChanger colorChanger = particleSystem.AddComponent<ColorChanger>();
                colorChanger.colorInfo = new ExtGradient
                {
                    colors = array
                };
                colorChanger.Start();
                particleSystem.GetComponent<Renderer>().material.color = Color.red;
                particleSystem.Play();
                GameObject.Destroy(particleSystem, 0.5f);
            }
        }

        static GameObject platL, platR, platL2, platL3, platL4, platR2;
        public static void Invizplatforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                if (platL != null)
                {
                    GameObject.Destroy(platL);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                if (platR != null)
                {
                    GameObject.Destroy(platR);
                    platR = null;
                }
            }
        }



        public static void platforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = menuColor;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platL != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platL, 2f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = menuColor;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platR, 2f);
                    platR = null;
                }
            }            
        }       

        public static void StickyPlats()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = menuColor;
                    platL2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL2.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL2.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0.06f, 0f);
                    platL2.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL2.GetComponent<Renderer>().material.color = Color.red;
                    platL2.GetComponent<Renderer>().enabled = false;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platL != null && platL2 != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platL, 2f);
                    GameObject.Destroy(platL2);
                    GameObject.Destroy(platL3);
                    GameObject.Destroy(platL4);
                    platL = null;
                    platL2 = null;
                    platL3 = null;
                    platL4 = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = menuColor;
                    platR2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR2.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR2.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0.06f, 0f);
                    platR2.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR2.GetComponent<Renderer>().material.color = Color.red;
                    platR2.GetComponent<Renderer>().enabled = false;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platR, 2f);
                    GameObject.Destroy(platR2);
                    platR = null;
                    platR2 = null;
                }
            }
        }

        public static void NoclipPlats()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = menuColor;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = false;
                    }
                }
            }
            else
            {
                if (platL != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = true;
                    }
                    GameObject.Destroy(platL, 2f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = menuColor;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = false;
                    }
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = true;
                    }
                    GameObject.Destroy(platR, 2f);
                    platR = null;
                }
            }
        }
    



        #region only wasd here :)
        public static void sadda() // Got this from one of my old devs so W :)
        {
            float speed = 15f;
            var rigidbody = GorillaTagger.Instance.rigidbody;
            Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0.067f, 0f);
            if (Mouse.current.rightButton.isPressed)
            {
                Vector3 euler = Player.Instance.rightControllerTransform.parent.rotation.eulerAngles;
                euler.y += (Mouse.current.delta.x.ReadValue() / UnityEngine.Screen.width) * 480f;
                euler.x -= (Mouse.current.delta.y.ReadValue() / UnityEngine.Screen.height) * 480f;
                Player.Instance.rightControllerTransform.parent.rotation = Quaternion.Euler(euler);
            }
            if (UnityInput.Current.GetKey(KeyCode.N))
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = true;
                }
            }
            Vector3 vector3 = Vector3.zero;
            if (UnityInput.Current.GetKey(KeyCode.W)) vector3 += Player.Instance.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.S)) vector3 -= Player.Instance.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.A)) vector3 -= Player.Instance.rightControllerTransform.parent.right;
            if (UnityInput.Current.GetKey(KeyCode.D)) vector3 += Player.Instance.rightControllerTransform.parent.right;
            if (UnityInput.Current.GetKey(KeyCode.Space)) vector3 += Vector3.up;
            if (UnityInput.Current.GetKey(KeyCode.LeftControl)) vector3 -= Vector3.up;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift)) speed = 25f; else { speed = 15f; }
            rigidbody.transform.position += vector3 * Time.deltaTime * speed;
        }
        #endregion


        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void FastFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void SlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerFastFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerSlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void Noclip()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void upandDown()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Player.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * 8f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Player.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * -8f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }


        public static void flywithnoclip()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 17f;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.forward * 20f;
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }


        public static void AutoJuke()
        {
            Vector3 myPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
            VRRig closestPlayer = null;
            float closestDistance = 3f;
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig == null || rig.isMyPlayer || rig.isOfflineVRRig) continue;

                float distance = Vector3.Distance(myPosition, rig.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPlayer = rig;
                }
            }
            if (closestPlayer != null)
            {
                if (JukeTime < Time.time)
                {
                    JukeTime = Time.time + 1.0f;

                    Vector3 jukeDirection = (myPosition - closestPlayer.transform.position).normalized;
                    jukeDirection += new Vector3(Random.Range(-0.1f, 0.1f), 0f, Random.Range(-0.1f, 0.1f));

                    GTPlayer.Instance.GetComponent<Rigidbody>().velocity += (jukeDirection + Vector3.up * 0.6f) * 15f;
                }
            }
        }

        public static float JukeTime = 0f;
    }
}
