using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [SerializeField]
    private int index = 0;
    [SerializeField]
    private UI jumpScare;

    public GameObject hantu;
    private int randomValue;
    private int randomValueLayer4;
    private int randomValueLayer3;
    private int randomValueLayer2;
    private bool gameOver = false;

    bool debugLogGameOver = false;

    public BoxCollider2D boxCollider2D;

    private void Start()
    {
    }

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

        randomValueLayer4 = Random.Range(0, 5);
        randomValueLayer3 = Random.Range(0, 3);
        randomValueLayer2 = Random.Range(0, 1);
        randomValue = Random.Range(2, 5);


        if(gameOver == false)
        {
            if(index == 0)
            {
                Debug.Log("ColliderResize1");
                boxCollider2D.offset = new Vector2(-1.168127f, -0.1968098f);
                boxCollider2D.size = new Vector2(2.121198f, 9.384619f);
            }else if(index == 1)
            {
                Debug.Log("ColliderResize2");
                boxCollider2D.offset = new Vector2(-1.5117f, 2.070802f);
                boxCollider2D.size = new Vector2(1.708909f, 8.422663f);
            }
            else if (index == 2)
            {
                Debug.Log("ColliderResize3");
                boxCollider2D.offset = new Vector2(-0.6871716f, 2.345661f);
                boxCollider2D.size = new Vector2(1.708914f, 7.872945f);
            }
            else if (index == 3)
            {
                Debug.Log("ColliderResize4");
                boxCollider2D.offset = new Vector2(-0.2061207f, 2.414375f);
                boxCollider2D.size = new Vector2(3.4955f, 7.735516f);
            }
            else if (index == 4)
            {
                Debug.Log("ColliderResize5");
                boxCollider2D.offset = new Vector2(0.481024f, 2.414375f);
                boxCollider2D.size = new Vector2(2.396066f, 7.735516f);
            }
            else if (index == 5)
            {
                boxCollider2D.offset = new Vector2(1.030741f, 2.414375f);
                boxCollider2D.size = new Vector2(1.296632f, 7.735516f);
            }
            else if (index == 6)
            {
                boxCollider2D.offset = new Vector2(1.030736f, 0.00935936f);
                boxCollider2D.size = new Vector2(2.396073f, 12.54555f);
            }
            else if (index == 7)
            {
                boxCollider2D.offset = new Vector2(-0.6871318f, 2.185326f);
                boxCollider2D.size = new Vector2(1.708926f, 8.193613f);
            }



            if (index == 7)
            {
                hantu.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            }else if(index!=7 || index != 8)
            {
                hantu.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            }
                
            if (index == 7 || index == 4)
            {
                hantu.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }else if(index == 6)
            {
                hantu.GetComponent<SpriteRenderer>().sortingOrder = 6;
            }
            else if (index == 5)
            {
                hantu.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }else if(index == 8)
            {
                hantu.GetComponent<SpriteRenderer>().sortingOrder = 6;
                hantu.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else 
            { 
                hantu.GetComponent<SpriteRenderer>().sortingOrder = 4;
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

                if(index == 6 || index == 7)
                {
                    index = randomValueLayer4;
                    hantu.transform.position = positionList[index].position;
                    ketapelCursorMovementScript.tembakHitHantu = 0;
                    //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
                }else if(index == 4 || index == 5)
                {
                    index = randomValueLayer3;
                    hantu.transform.position = positionList[index].position;
                    ketapelCursorMovementScript.tembakHitHantu = 0;
                    //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
                }else if(index == 2 || index == 3)
                {
                    index = randomValueLayer2;
                    hantu.transform.position = positionList[index].position;
                    ketapelCursorMovementScript.tembakHitHantu = 0;
                    //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
                }else if(index == 0)
                {
                    index = randomValue;
                    hantu.transform.position = positionList[index].position;
                    ketapelCursorMovementScript.tembakHitHantu = 0;
                    //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
                }else if(index == 1)
                {
                    index = randomValue;
                    hantu.transform.position = positionList[index].position;
                    ketapelCursorMovementScript.tembakHitHantu = 0;
                    //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
                }


            } //tutup if tembakhantu3
        } //tutup if gameover == false


        if(index == 8)
        {
            gameOver = true;
            hantu.transform.position = positionList[index].position;
            ketapelCursorMovementScript.tembakHitHantu = 0;
            //hantu.GetComponent<SpriteRenderer>().sprite = spriteList[index];
            
            if(debugLogGameOver == false)
            {
                Debug.Log("Gameover : KETAPEL");
                debugLogGameOver = true;
                jumpScare.isDead = debugLogGameOver;
            }
            
        }


    }

}
