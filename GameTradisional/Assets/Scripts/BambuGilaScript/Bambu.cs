using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bambu : MonoBehaviour
{

    //LAST UPDATED : 12/09/2023 00:42

    //AutoRotate
    public float rotationSpeed = 10.0f;
    public float balanceForce = 10.0f;
    public float maxRotationAngle = 45.0f;

    //ChangeRotationWhenPressed
    private float currentRotation = 0.0f;
    private float newRotation;

    //Direction
    [SerializeField]
    private int randomDirection;

    //KalahAtauTidak
    private int mainBambuGila = 1;


    void Start()
    {
        randomDirection = Random.Range(-1, 2);
        if(randomDirection == 0)
        {
            randomDirection = -1;
        }else if(randomDirection == 2)
        {
            randomDirection = 1;
        }
    }

    void Update()
    {
        if(mainBambuGila == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("TekanA");
                newRotation = currentRotation + balanceForce;
                transform.rotation = Quaternion.Euler(0, 0, newRotation);
                currentRotation = newRotation;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("TekanD");
                newRotation = currentRotation - balanceForce;
                transform.rotation = Quaternion.Euler(0, 0, newRotation);
                currentRotation = newRotation;
            }
            else
            {
                if (currentRotation < 0)
                {
                    randomDirection = -1;
                }
                else if (currentRotation > 0)
                {
                    randomDirection = 1;
                }

                float rotationInput = randomDirection * rotationSpeed;
                currentRotation += rotationInput * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);
                transform.rotation = Quaternion.Euler(0, 0, currentRotation);
            }
        }

    } //tutup update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bambuGround"))
        {
            mainBambuGila = 0;
            Debug.Log("GAME OVER : BambuGila");
        }
    }


}
