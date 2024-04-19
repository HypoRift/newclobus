using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class FlamethrowerManager : MonoBehaviour
{
    public ParticleSystem FlameSystem;
    public AudioSource FlameSFX;
    public bool isGripButtonDown = false;

    void Update()
    {
        // Check if the grip button is currently down
        bool isGripDown = EasyInputs.GetGripButtonDown(EasyHand.RightHand);

        // Check if the grip button was just pressed
        if (isGripDown && !isGripButtonDown)
        {
            StartFlame();
        }
        // Check if the grip button was just released
        else if (!isGripDown && isGripButtonDown)
        {
            StopFlame();
        }

        // Update the state of the grip button
        isGripButtonDown = isGripDown;
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
