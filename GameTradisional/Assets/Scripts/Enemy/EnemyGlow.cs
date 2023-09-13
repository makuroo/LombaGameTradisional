using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class EnemyGlow : MonoBehaviour
{
    public float lerpDuration = 2f; // Duration of the lerp in seconds
    private float timer = 0f;
    [SerializeField] private Light2D light2D;
    [SerializeField] private bool isAnnounce;
    private bool isOff = false;
    private bool isFirst = true;
    [SerializeField] private float nextGlow;
    [SerializeField] private float nextGlowTimer;
    [SerializeField] private float countDown;
    [SerializeField] private CameraTransition transition;
    [SerializeField] private Movement playerMovement;
    void Start()
    {
        
    }

    void Update()
    {

        nextGlowTimer += Time.deltaTime;
        if(nextGlowTimer >= countDown && isFirst)
        {
            isFirst = false;
            isAnnounce = true;
            nextGlowTimer = 0;
        }
            
        if (nextGlowTimer >= nextGlow && !isFirst)
            isAnnounce = true;

        if (isAnnounce)
        {
            playerMovement.enabled = false;
            nextGlowTimer = 0;
            AnnouncePresence();
        }

        if(light2D.intensity == 0 && nextGlowTimer>=countDown && isFirst)
        {
            if (transition.finishedBlend)
                playerMovement.enabled = true;
        }
    }


    private void AnnouncePresence()
    {
        transition.IncreaseCameraPriority();
        if(light2D.intensity == 1)
        {
            isOff = true;
            timer = 0;
        }else if(light2D.intensity == 0 && !isFirst)
        {
            isOff = false;
            timer = 0;
            transition.DecreaseCameraPriority();
            if (transition.finishedBlend)
                playerMovement.enabled = true;
            isAnnounce = false;
        }

        if (light2D.intensity < 1 && !isOff)
        {
            timer += Time.deltaTime;
            light2D.intensity = Mathf.Lerp(0, 1, timer / lerpDuration);
        }
        else if(light2D.intensity > 0 && isOff)
        {
            timer += Time.deltaTime;
            light2D.intensity = Mathf.Lerp(1, 0, timer / lerpDuration);

        }
    }
    
}