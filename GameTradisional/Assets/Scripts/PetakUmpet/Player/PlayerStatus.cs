using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool IsHiding { get; set; }
    private SpriteRenderer sr;
    private Movement playerMovement;
    private GameObject flashLights;
    private GameObject playerLights;
    private bool canUseE = false;
    private void Start()
    {
        IsHiding = false;
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<Movement>();
        flashLights = transform.GetChild(0).gameObject;
        playerLights = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (canUseE)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsHiding = !IsHiding;
                canUseE = false;
            }

            if (IsHiding)
            {
                sr.enabled = false;
                playerMovement.enabled = false;
                flashLights.SetActive(false);
                playerLights.SetActive(false);
                canUseE = true;
            }
            else
            {
                sr.enabled = true;
                playerMovement.enabled = true;
                flashLights.SetActive(true);
                playerLights.SetActive(true);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lemari"))
        {
            collision.transform.parent.GetChild(1).gameObject.SetActive(true);
            canUseE = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lemari"))
        {
            collision.transform.parent.GetChild(1).gameObject.SetActive(false);
            canUseE = true;
        }
    }
}
