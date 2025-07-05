using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Singularity_OS.Menu
{
    public class Safety
    {
        public static void AntiReport()
        {
            var scoreboardLine = GorillaScoreboardTotalUpdater.allScoreboardLines.Find((GorillaPlayerScoreboardLine L) => L.playerVRRig.isLocal);
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                var Limit = 0.51f;
                var ReportPosition = scoreboardLine.reportButton.gameObject.transform.position;
                var RightDis = Vector3.Distance(vrrigs.rightHandTransform.position, ReportPosition);
                var LeftDis = Vector3.Distance(vrrigs.leftHandTransform.position, ReportPosition);
                if (RightDis <= Limit || LeftDis <= Limit)
                {
                    if (!vrrigs.isLocal && !vrrigs.isMyPlayer)
                    {
                        PhotonNetwork.Disconnect();
                        flush();
                    }
                }
            }
        }

        public static void CantMoveFingers()
        {
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }

        public static void flush() // creds to 2025 Joe
        {
            try
            {
                if (hasRemovedThisFrame)
                    return;
                
                PhotonNetwork.SendAllOutgoingCommands();
            }
            catch (Exception ex)
            { Debug.Log("{ERROR} : " + ex.Message); }
        }
        private static bool hasRemovedThisFrame = false;
    }
}
