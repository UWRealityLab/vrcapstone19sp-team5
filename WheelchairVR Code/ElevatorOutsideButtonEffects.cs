
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Valve.VR.InteractionSystem
{
    public class ElevatorOutsideButtonEffects : MonoBehaviour
    {
        public ElevatorDoorController elevatorDoorController;

        public void OnButtonDown(Hand fromHand)
        {
            //ColorSelf(Color.cyan);
            //fromHand.TriggerHapticPulse(1000);
            elevatorDoorController.ButtonOpen();
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}