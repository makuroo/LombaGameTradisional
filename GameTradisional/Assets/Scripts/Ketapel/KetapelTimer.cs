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

    public PolygonCollider2D[] polygonCollider;

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

            switch (index)
            {
                case 0:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if(index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < polygonCollider.Length; i++)
                    {
                        if (index == i)
                        {
                            polygonCollider[i].enabled = true;
                        }
                        else
                        {
                            polygonCollider[i].enabled = false;
                        }
                    }
                    break;

                default:
                    break;
            }

            //if(index == 0)
            //{
            //    polygonCollider[0].enabled = true;
                
            //}else if(index == 1)
            //{
            //    polygonCollider[1].enabled = true;

            //}
            //else if (index == 2)
            //{
            //    polygonCollider[2].enabled = true;

            //}
            //else if (index == 3)
            //{
            //    polygonCollider[3].enabled = true;

            //}
            //else if (index == 4)
            //{
            //    polygonCollider[4].enabled = true;

            //}
            //else if (index == 5)
            //{
            //    polygonCollider[5].enabled = true;

            //}
            //else if (index == 6)
            //{
            //    polygonCollider[6].enabled = true;

            //}
            //else if (index == 7)
            //{
            //    polygonCollider[7].enabled = true;

            //}



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
