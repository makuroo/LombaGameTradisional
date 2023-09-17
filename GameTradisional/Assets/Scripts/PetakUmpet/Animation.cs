using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
       playerMovement =  GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", playerMovement.isMoving);
        anim.SetBool("isRunning", playerMovement.isRunning);
    }
}
