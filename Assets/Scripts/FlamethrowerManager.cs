using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class FlamethrowerManager : MonoBehaviour
{
    public ParticleSystem FlameSystem;
    public AudioSource FlameSFX;
    public bool isTriggerButtonDown = false;

    void Update()
    {
        // Check if the trigger button is currently down
        bool isTriggerDown = EasyInputs.GetTriggerButtonDown(EasyHand.RightHand);

        // Check if the trigger button was just pressed
        if (isTriggerDown && !isTriggerButtonDown)
        {
            StartFlame();
        }
        // Check if the trigger button was just released
        else if (!isTriggerDown && isTriggerButtonDown)
        {
            StopFlame();
        }

        // Update the state of the trigger button
        isTriggerButtonDown = isTriggerDown;
    }

    void StartFlame()
    {
        FlameSystem.Play();
        FlameSFX.Play();
    }

    void StopFlame()
    {
        FlameSystem.Stop();
        FlameSFX.Stop();
    }
}