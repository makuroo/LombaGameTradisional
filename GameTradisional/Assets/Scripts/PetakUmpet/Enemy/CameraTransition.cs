using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private CinemachineBrain cmBrain;
    public bool finishedBlend { get; private set; }

    public void IncreaseCameraPriority()
    {
        if(cam.Priority<10)
            cam.Priority += 1;
    }

    public void DecreaseCameraPriority()
    {
        if (cam.Priority >= 10)
            cam.Priority -= 1;
        if (!cmBrain.IsBlending)
            finishedBlend = true;
    }
}
