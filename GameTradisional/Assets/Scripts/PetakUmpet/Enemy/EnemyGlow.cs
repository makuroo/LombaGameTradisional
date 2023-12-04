using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnemyGlow : MonoBehaviour
{
    public float lerpDuration = 2f; // Duration of the lerp in seconds
    private float timer = 0f;
    [SerializeField] private Light2D light2D;
    [SerializeField] private bool isAnnounce;
    private bool isOff = false;
    [SerializeField]private bool isFirst = true;
    public bool isFirstFinish = false;
    [SerializeField] private float nextGlow;
    [SerializeField] private float nextGlowTimer;
    [SerializeField] private float countDown;
    [SerializeField] private EnemyCompass compass;
    [SerializeField] private GameObject timerObject;
    [SerializeField] private Image ghostCountDown;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private List<Sprite> countDownSprite;
    public bool startCountDown = false;

    public Dictionary<int, Sprite> countdownDict = new();

    private void Start()
    {

    }

    void Update()
    {
        if (startCountDown)
        {
            nextGlowTimer += Time.deltaTime;
            ghostCountDown.enabled = true;
        }
        
        if(nextGlowTimer >= countDown && isFirst)
        {
            startCountDown = false;
            isFirst = false;
            isAnnounce = true;
            nextGlowTimer = 0;
            ghostCountDown.enabled = false;
            timerObject.SetActive(true);
        }
            
        if (nextGlowTimer >= nextGlow && !isFirst)
        {
            Debug.Log("here");
            isAnnounce = true;
            audioManager.PlayOneShot("WeweGombel");
            nextGlowTimer = 0;
        }
        else if(!isFirst && nextGlowTimer < nextGlow)
        {
            nextGlowTimer += Time.deltaTime;
        }
            

        if (isAnnounce)
        {
            nextGlowTimer = 0;
            AnnouncePresence();
        }

        ghostCountDown.sprite = countDownSprite[Mathf.FloorToInt(nextGlowTimer)];
    }

    private void AnnouncePresence()
    {
        if(light2D.intensity >= 1)
        {
            isOff = true;
            timer = 0;
        }else if(light2D.intensity == 0 && !isFirst && isFirstFinish)
        {
            isOff = false;
            timer = 0;
                
            isAnnounce = false;
        } else if (light2D.intensity == 0 && !isFirst && !isFirstFinish)
        {
            isFirstFinish = true;
            isOff = false;
            timer = 0;
            isAnnounce = false;

        }


        if (light2D.intensity < 1 && !isOff)
        {
            timer += Time.deltaTime;
            light2D.intensity = Mathf.Lerp(0, 1, timer / lerpDuration);
            compass.RotateArrow();
        }
        else if(light2D.intensity > 0 && isOff)
        {
            timer += Time.deltaTime;
            light2D.intensity = Mathf.Lerp(1, 0, timer / lerpDuration);

        }
    }
    
}