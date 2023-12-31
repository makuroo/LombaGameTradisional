using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

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
    public int randomDirectionStrong;
    public float randomDirectionLemah;
    public float randomDirectionMid;
    private float rotationInput;

    //KalahAtauTidak
    public int mainBambuGila = 1;

    //OrangKomponen
    public Transform torso;
    public Transform head;

    public float timer;
    int once = 0;

    public SpriteRenderer rendererA;
    public SpriteRenderer rendererD;

    public Light2D[] lightWarna;

    public PlayableDirector cutsceneGameover;
    public PlayableDirector cutsceneRestart;

    void Start()
    {
        randomDirectionStrong = Random.Range(-1, 2);
        randomDirectionLemah = (Random.Range(0, 1) == 0) ? -0.2f : 0.2f;
        randomDirectionMid = (Random.Range(0, 1) == 0) ? -0.6f : 0.6f;

        if (randomDirectionStrong == 0)
        {
            randomDirectionStrong = -1;
        }else if(randomDirectionStrong == 2)
        {
            randomDirectionStrong = 1;
        }

    }

    void Update()
    {

        timer = timer + Time.deltaTime;

        for(int i = 0; i < lightWarna.Length; i++)
        {
            if(Mathf.Abs(currentRotation) >= 20)
            {
                lightWarna[i].color = new Color(1, Mathf.Clamp(lightWarna[i].color.g - Mathf.Abs(currentRotation)/1000, 0, 1), Mathf.Clamp(lightWarna[i].color.b - Mathf.Abs(currentRotation)/1000, 0, 1));
            }
            else
            {
                lightWarna[i].color = new Color(1, Mathf.Clamp(lightWarna[i].color.g + Mathf.Abs(currentRotation) / 300, 0, 1), Mathf.Clamp(lightWarna[i].color.b + + Mathf.Abs(currentRotation) / 300, 0, 1));
            }

        }

        if (mainBambuGila == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rendererA.color = new Color(rendererA.color.r, rendererA.color.g, rendererA.color.b,1);
            }
            else
            {
                rendererA.color = new Color(rendererA.color.r, rendererA.color.g, rendererA.color.b, 0.5f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rendererD.color = new Color(rendererA.color.r, rendererA.color.g, rendererA.color.b, 1);
            }
            else
            {
                rendererD.color = new Color(rendererA.color.r, rendererA.color.g, rendererA.color.b, 0.5f);
            }





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
                    randomDirectionStrong = -1;
                    randomDirectionLemah = -0.2f;
                    randomDirectionMid = -0.6f;
                }
                else if (currentRotation > 0)
                {
                    randomDirectionStrong = 1;
                    randomDirectionLemah = 0.2f;
                    randomDirectionMid = 0.6f;
                }

                if(timer >= 1 && timer <= 5)
                {
                   rotationInput = randomDirectionLemah * rotationSpeed;
                }else if(timer >= 5 && timer <=15)
                {
                    rotationInput = randomDirectionMid * rotationSpeed;
                }
                else if(timer >= 15)
                {
                    rotationInput = randomDirectionStrong * rotationSpeed;
                }

                
                currentRotation += rotationInput * Time.deltaTime ;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);
                transform.rotation = Quaternion.Euler(0, 0, currentRotation);
                torso.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
                head.transform.rotation = Quaternion.Euler(0, 0, currentRotation);



            }
        }

    } //tutup update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("bambuGround") && once == 0)
        {
            mainBambuGila = 0;
            Debug.Log("GAME OVER : BambuGila");
            PlayerPrefs.SetInt("BambuPlayedOnce", 1);
            cutsceneGameover.Play();
            StartCoroutine(delayLoadScene());

            //once = 1;

        }
    }

    private IEnumerator delayLoadScene()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("delayloadscenekerja");
        SceneManager.LoadScene("BambuGila");
        //cutsceneRestart.Play();
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
