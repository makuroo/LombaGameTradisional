using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Playables;

public class PetakUmpetTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float currSec;
    [SerializeField] float currMin;
    [SerializeField] List<Transform> doors = new();
    [SerializeField] CameraTransition camTransition;
    private int blendTime;
    [SerializeField] Movement playerMovement;
    [SerializeField] Pathfinding.AIPath aiPath;
    [SerializeField] EnemyGlow glow;
    [SerializeField]private bool hasIncreaseBlendTime = false;
    [SerializeField] private GameObject doorLight;
    private bool hasLookDoor = false;
    [SerializeField] private float timer;
    public bool startTimer  = false;

    private int playerPrefPetakUmpet;
    public PlayableDirector cutsceneIntro;
    public int DevChange;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00";
        playerPrefPetakUmpet = PlayerPrefs.GetInt("prefPetakUmpet");
        if(playerPrefPetakUmpet == 0)
        {
            cutsceneIntro.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(DevChange == 1)
        {
            PlayerPrefs.SetInt("prefPetakUmpet", 1);
        }else if(DevChange == 2)
        {
            PlayerPrefs.SetInt("prefPetakUmpet", 0);
        }
        

        if (startTimer)
        {
            currSec += Time.deltaTime;
        }
        
        if (currSec >= 60)
        {
            currSec = 0;
            currMin++;
        }
        string formattedText = currMin.ToString("00") + ":" + Mathf.Floor(currSec).ToString("00");
        timerText.text = formattedText;

        if (currMin >= timer && !hasLookDoor)
        {
            playerMovement.canGetOut = true;
            camTransition.IncreaseCameraPriority();
            doorLight.GetComponent<Light2D>().enabled = true;
            doors[0].eulerAngles = new Vector3(0, 0, -45);
            doors[1].eulerAngles = new Vector3(0, 0, 45);
            playerMovement.enabled = false;
            aiPath.isStopped = true;
        }

        if (camTransition.finishedBlend && !hasIncreaseBlendTime)
        {
            hasIncreaseBlendTime = true;
            blendTime++;
            Debug.LogError(blendTime);

            StartCoroutine(WaitForBlend());
        }
    }

    private IEnumerator WaitForBlend()
    {
        doorLight.SetActive(true);
        yield return new WaitForSeconds(3);
        if (blendTime < 2)
        {
            if (!hasLookDoor)
                hasLookDoor = true;
            camTransition.DecreaseCameraPriority();
            yield return new WaitForSeconds(2);
            playerMovement.enabled = true;
            aiPath.isStopped = false;
        }

    }
}
