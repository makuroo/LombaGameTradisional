using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class QTEButtonBambu : MonoBehaviour
{

    //LAST UPDATED : 15/09/2023 15:17

    //Component
    public Text textQTE;
    public Image imageQTE;

    //Random Interval Appear & durasi
    public float minAppearTime = 3f; 
    public float maxAppearTime = 8f; 
    public float durasiDisplayTime = 5f; //timer qtenya muncul sampe tutup

    //WarnaButton
    public Color startColor = Color.white;
    public Color endColor = Color.red;

    //QTE
    private float appearTimer;
    private float qteTimerDurasi; //timer jalan ketika qtenya muncul
    private bool qteActive = false;
    private string[] qteText = {"SPACE","E","F","M","K","L","O"};
    private int randomIndex;
    private string randomCharacter;


    //Script
    public Bambu bambuScript;

    private void Start()
    {
        HideQTE();
        RandomWaktuMuncul();
    }

    private void Update()
    {

        if(bambuScript.mainBambuGila == 1)
        {
            appearTimer -= Time.deltaTime;

            if (appearTimer <= 0f && !qteActive)
            {
                ShowQTE();
            }
        }
        
        if(bambuScript.mainBambuGila == 1)
        {
            if(randomCharacter == "SPACE")
            {
                if (Input.GetKeyDown(KeyCode.Space) && qteActive)
                {
                    qteSuccess();
                }else if(!Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && qteActive && Input.anyKey)
                {
                    qteFailed();
                    Konsekuensi();
                }
            }else if(randomCharacter == "E")
            {
                if (Input.GetKeyDown(KeyCode.E) && qteActive)
                {
                    qteSuccess();
                }
                else if(!Input.GetKeyDown(KeyCode.E) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }
            else if(randomCharacter == "F")
            {
                if (Input.GetKeyDown(KeyCode.F) && qteActive)
                {
                    qteSuccess();
                }
                else if(!Input.GetKeyDown(KeyCode.F) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }
            else if(randomCharacter == "M")
            {
                if (Input.GetKeyDown(KeyCode.M) && qteActive)
                {
                    qteSuccess();
                
                }else if(!Input.GetKeyDown(KeyCode.M) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }
            else if(randomCharacter == "K")
            {
                if (Input.GetKeyDown(KeyCode.K) && qteActive)
                {
                    qteSuccess();
                }
                else if(!Input.GetKeyDown(KeyCode.K) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }else if(randomCharacter == "L")
            {
                if (Input.GetKeyDown(KeyCode.L) && qteActive)
                {
                    qteSuccess();
                }else if(!Input.GetKeyDown(KeyCode.L) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }else if(randomCharacter == "O")
            {
                if (Input.GetKeyDown(KeyCode.O) && qteActive)
                {
                    qteSuccess();
                }
                else if(!Input.GetKeyDown(KeyCode.O) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    qteFailed();
                    Konsekuensi();
                }
            }
        }



        if (qteActive)
        {
            qteTimerDurasi -= Time.deltaTime;
            if (qteTimerDurasi <= 0f)
            {
                Debug.Log("Gagal QUICK TIME EVENT : BAMBU");
                Konsekuensi();
                HideQTE();
                RandomWaktuMuncul();
            }
            else
            {
                float gradianWarna = 1 - (qteTimerDurasi / durasiDisplayTime);
                imageQTE.color = Color.Lerp(startColor, endColor, gradianWarna);
            }
        }

    } //tutup update

    private void RandomWaktuMuncul()
    {
        appearTimer = Random.Range(minAppearTime, maxAppearTime);
    }

    public void ShowQTE()
    {
        randomIndex = Random.Range(0, qteText.Length);
        randomCharacter = qteText[randomIndex];
        textQTE.text = randomCharacter;
        imageQTE.enabled = true;
        qteActive = true;
        qteTimerDurasi = durasiDisplayTime;
    }

    public void HideQTE()
    {
        textQTE.text = "";
        imageQTE.enabled = false;
        qteActive = false;
    }

    private void Konsekuensi()
    {
        bambuScript.balanceForce = 30;

        if (bambuScript.randomDirection == 1)
        {
            bambuScript.SembanginKeKiri();
            bambuScript.balanceForce = 3;
        }
        else if (bambuScript.randomDirection == -1)
        {
            bambuScript.SembanginKeKanan();
            bambuScript.balanceForce = 3;
        }
    }

    private void qteSuccess()
    {
        Debug.Log("QTE Success");
        HideQTE();
        RandomWaktuMuncul();
    }

    private void qteFailed()
    {
        Debug.Log("wrong key pressed BAMBUGILA");
        HideQTE();
        RandomWaktuMuncul();
    }

}
