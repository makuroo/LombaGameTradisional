using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetapelCursorMovement : MonoBehaviour
{
    //UPDATED : 17/09/2023 14:25

    public Camera mainCamera;
    public int tembakHitHantu;

    public Vector2 position;
    public Animator animationTarik;
    private bool buttonPressed;
    private float clickDuration;
    private bool readyToShoot;

    public SpriteRenderer bekasTembak;

    private void Update()
    {
        position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = position;


        if (Input.GetMouseButton(0))
        {
            animationTarik.SetBool("isTarik", true);
            buttonPressed = true;
        }else if (!Input.GetMouseButton(0))
        {
            buttonPressed = false;
            animationTarik.SetBool("isTarik", false);
        }


        if (buttonPressed)
        {

            //Debug.Log(clickDuration);
            clickDuration += Time.deltaTime;
            if(clickDuration >= 0.4)
            {
                readyToShoot = true;


            }else if(clickDuration <= 0)
            {
                animationTarik.SetBool("isTarik", false); //auto tutup anim if spam
            }
        }else if (!buttonPressed)
        {
            clickDuration = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {


            Vector2 position2D = new Vector2(position.x, position.y);
            RaycastHit2D hit = Physics2D.Raycast(position2D, Vector2.zero);

            if (readyToShoot)
            {

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("ketapelHantu"))
                    {
                        Debug.Log("Hit Hantu");
                        tembakHitHantu++;
                    }else
                    {
                        Debug.Log("WRONG!");
                    }


                }
                animationTarik.SetBool("isTarik", false);
                buttonPressed = false;
                readyToShoot = false;
            }


        } //tutup if getmousebuttonup

    }

    private IEnumerator BekasTembak()
    {
        bekasTembak.enabled = true;
        yield return new WaitForSeconds(0.2f);
    }



}