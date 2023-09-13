using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEButtonBambu : MonoBehaviour
{

    //LAST UPDATED : 12/09/2023 21:22

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


        if (Input.GetKeyDown(KeyCode.Space) && qteActive)
        {
            Debug.Log("QTE Success");
            HideQTE();
            RandomWaktuMuncul();
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
        textQTE.text = "SPACE";
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

}
