using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool IsHiding { get; set; }
    private SpriteRenderer sr;
    private Movement playerMovement;
    private GameObject lights;
    private bool canUseE = false;
    private void Start()
    {
        IsHiding = false;
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<Movement>();
        lights = transform.GetChild(0).gameObject;
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
                lights.SetActive(false);
                canUseE = true;
            }
            else
            {
                sr.enabled = true;
                playerMovement.enabled = true;
                lights.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lemari"))
        {
            canUseE = true;
        }
    }
}
