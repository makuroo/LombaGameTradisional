using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPetakUmpet : MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private float currTime;
    [SerializeField] private float timer;
    public bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        if (startTimer)
        {
            currTime += Time.deltaTime;
        }

        if (currTime >= timer)
        {
            tutorialCanvas.SetActive(false);
        }
    }
}
