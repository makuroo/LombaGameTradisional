using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bambu : MonoBehaviour
{

    //LAST UPDATED : 12/09/2023 21:22

    //AutoRotate
    public float rotationSpeed = 10.0f;
    public float balanceForce = 10.0f;
    public float maxRotationAngle = 45.0f;

    //ChangeRotationWhenPressed
    [SerializeField]
    private float currentRotation = 0.0f;
    private float newRotation;

    //Direction
    public int randomDirection;

    //KalahAtauTidak
    public int mainBambuGila = 1;

    //OrangKomponen
    public Transform torso;
    public Transform head;


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


        if (mainBambuGila == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("TekanA");
                SembanginKeKiri();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("TekanD");
                SembanginKeKanan();
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
                torso.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
                head.transform.rotation = Quaternion.Euler(0, 0, currentRotation);



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

    public void SembanginKeKiri()
    {
        newRotation = currentRotation + balanceForce;
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
        currentRotation = newRotation;
    }

    public void SembanginKeKanan()
    {
        newRotation = currentRotation - balanceForce;
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
        currentRotation = newRotation;
    }

}
