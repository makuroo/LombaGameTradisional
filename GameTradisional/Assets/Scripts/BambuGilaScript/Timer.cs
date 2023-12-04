using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public Text textTimer;

    public int gameFinished;
    public PlayableDirector timelineVictory;
    private void Update()
    {
        if(gameFinished == 0)
        {
            timer = timer + Time.deltaTime;

        }

        string timerText = Mathf.Floor(timer).ToString();
        textTimer.text = timerText;

        if(timer >= 120)
        {
            Debug.Log("BambuVictory");
            gameFinished = 1;
            timelineVictory.Play();
        }

    }

    





}
