using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public Text textTimer;

    private int gameFinished;

    private void Update()
    {
        if(gameFinished == 0)
        {
            timer = timer + Time.deltaTime;
        }

        string timerText = Mathf.Floor(timer).ToString();
        textTimer.text = timerText;

        if(gameFinished == 0)
        {

        }

    }

    





}
