using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
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
    public float durasiDisplayTime; //timer qtenya muncul sampe tutup
    private float timerGame;

    //WarnaButton
    public Color startColor = Color.white;
    public Color endColor = Color.red;

    //QTE
    private float appearTimer;
    private float qteTimerDurasi; //timer jalan ketika qtenya muncul
    private bool qteActive = false;
    public SpriteRenderer[] keyFolder;
    public Light2D keyLight;
    public SpriteRenderer spriteKeyQTE;
    private int indexKey;
    private int randomIndex;
    public GameObject keyQTE;

    private int bambuPref;
    public GameObject reichadGameplay;

    //Script
    public Bambu bambuScript;

    public PlayableDirector cutsceneVictory;
    private void Start()
    {
        HideQTE();
        RandomWaktuMuncul();
        bambuPref = PlayerPrefs.GetInt("BambuPlayedOnce");

    }

    private void Update()
    {
        if (timerGame >= 30)
        {
            bambuScript.mainBambuGila = 0;
            cutsceneVictory.Play();
            HideQTE();
            StartCoroutine(disableGameplayVictory());
        }


        if (bambuScript.mainBambuGila == 1)
        {

            if (qteActive == true)
            {
                if (indexKey == 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space) && qteActive)
                    {
                        qteSuccess();
                    }
                    else if (!Input.GetKeyDown(KeyCode.Space) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("WRONG SPACE");
                        qteFailed();
                        Konsekuensi();
                    }

                }
                else if (indexKey == 1)
                {
                    if (Input.GetKeyDown(KeyCode.M) && qteActive)
                    {
                        qteSuccess();

                    }
                    else if (!Input.GetKeyDown(KeyCode.M) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("WRONG M");
                        qteFailed();
                        Konsekuensi();
                    }

                }
                else if (indexKey == 2)
                {
                    if (Input.GetKeyDown(KeyCode.K) && qteActive)
                    {
                        qteSuccess();
                    }
                    else if (!Input.GetKeyDown(KeyCode.K) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("WRONG K");
                        qteFailed();
                        Konsekuensi();
                    }

                }
                else if (indexKey == 3)
                {
                    if (Input.GetKeyDown(KeyCode.L) && qteActive)
                    {
                        qteSuccess();
                    }
                    else if (!Input.GetKeyDown(KeyCode.L) && qteActive && Input.anyKey && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("WRONG L");
                        qteFailed();
                        Konsekuensi();
                    }
                }
            }

        }
    }

    private IEnumerator disableGameplayVictory()
    {
        yield return new WaitForSeconds(2.3f);
        reichadGameplay.SetActive(false);

    }

    private void FixedUpdate()
    {
        timerGame = timerGame + Time.deltaTime;

        if (bambuScript.mainBambuGila == 1)
        {

            if (bambuPref == 0)
            {
                if (timerGame >= 31)
                {
                    Debug.Log("a");
                    appearTimer -= Time.deltaTime;

                    if (appearTimer <= 0f && !qteActive)
                    {
                        ShowQTE();
                    }
                }
            } else if (bambuPref == 1)
            {
                if (timerGame >= 15)
                {
                    appearTimer -= Time.deltaTime;

                    if (appearTimer <= 0f && !qteActive)
                    {
                        ShowQTE();
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
                    //float gradianWarna = 1 - (qteTimerDurasi / durasiDisplayTime);
                    //spriteKeyQTE.color = Color.Lerp(startColor, endColor, gradianWarna);
                    spriteKeyQTE.color = new Color(1, Mathf.Clamp(spriteKeyQTE.color.g - durasiDisplayTime / 1050, 0, 1), Mathf.Clamp(spriteKeyQTE.color.b - durasiDisplayTime / 1050, 0, 1));
                    keyLight.color = new Color(1, Mathf.Clamp(keyLight.color.g - durasiDisplayTime / 1050, 0, 1), Mathf.Clamp(keyLight.color.b - durasiDisplayTime / 1050, 0, 1));
                    keyLight.intensity = keyLight.intensity + Time.deltaTime * 5;
                }
            }

        } //tutup update



    }
    private void RandomWaktuMuncul()
    {
        appearTimer = Random.Range(minAppearTime, maxAppearTime);
    }

    public void ShowQTE()
    {
        randomIndex = Random.Range(0, keyFolder.Length);
        indexKey = randomIndex;
        Debug.Log(indexKey);
        keyQTE.GetComponent<SpriteRenderer>().sprite = keyFolder[indexKey].sprite;
        keyLight.lightCookieSprite = keyFolder[indexKey].sprite;

        qteActive = true;
        qteTimerDurasi = durasiDisplayTime;
    }

    public void HideQTE()
    {
        keyQTE.GetComponent<SpriteRenderer>().sprite = null;
        keyLight.lightCookieSprite = null;
        spriteKeyQTE.color = new Color(1, 1, 1);
        keyLight.color = new Color(1, 1, 1);
        qteActive = false;
        keyLight.intensity = 5;
        //durasiDisplayTime = 5;
    }

    private void Konsekuensi()
    {
        bambuScript.balanceForce = 30;

        if (bambuScript.mainBambuGila == 1)
        {
            if (bambuScript.randomDirectionStrong == 1)
            {
                bambuScript.SembanginKeKiri();
                bambuScript.balanceForce = 3;
            }
            else if (bambuScript.randomDirectionStrong == -1)
            {
                bambuScript.SembanginKeKanan();
                bambuScript.balanceForce = 3;
            }
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
