using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField]private bool hasIncreaseBlendTime = false;
    private bool hasLookDoor = false;
    [SerializeField] private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        currSec += Time.deltaTime;
        if (currSec >= 60)
        {
            currSec = 0;
            currMin++;
        }
        string formattedText = currMin.ToString("00") + ":" + Mathf.Floor(currSec).ToString("00");
        timerText.text = formattedText;

        if (currMin == timer && !hasLookDoor)
        {
            camTransition.IncreaseCameraPriority();
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
        yield return new WaitForSeconds(2);
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
