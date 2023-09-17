using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KetapelTimer : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private float timerHantu;
    public Text textTimer;
    private int gameFinished;
    public KetapelCursorMovement ketapelCursorMovementScript;

    [SerializeField]
    private Transform[] positionList;
    [SerializeField]
    private Sprite[] spriteList;
    private int index = 0;

    public GameObject hantu;



    private void Update()
    {
        if (gameFinished == 0)
        {
            timer = timer + Time.deltaTime;
        }

        string timerText = Mathf.Floor(timer).ToString();
        textTimer.text = timerText;

        if (gameFinished == 0)
        {
            //MAX SECOND GAME LENGTH = 180 S

        }




        
        timerHantu += Time.deltaTime;
        if (timerHantu >= 5)
        {
            index++;
            timerHantu = 0;
            hantu.transform.position = positionList[index].position;
            //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
        }

        if(ketapelCursorMovementScript.tembakHitHantu == 3)
        {
            if(index != 0)
            {
                index--;
                timerHantu = 0;
                hantu.transform.position = positionList[index].position;
                ketapelCursorMovementScript.tembakHitHantu = 0;
                //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
            }
            else
            {
                index++;
                timerHantu = 0;
                hantu.transform.position = positionList[index].position;
                ketapelCursorMovementScript.tembakHitHantu = 0;
                //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
            }

        }

    }

}
