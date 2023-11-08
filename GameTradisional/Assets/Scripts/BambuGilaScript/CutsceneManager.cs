using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private int devChange;
    private int playerPrefBambu;
    public GameObject cutscene;
    public GameObject folderCutscene;
    public GameObject folderGameplay;
    public GameObject reichadJalan;

    public PlayableDirector cutsceneRetry;

    void Start()
    {

        playerPrefBambu = PlayerPrefs.GetInt("BambuPlayedOnce");
        if(playerPrefBambu == 1)
        {
            cutsceneRetry.Play();
            cutscene.SetActive(false);
            folderCutscene.SetActive(false);
            folderGameplay.SetActive(true);
            reichadJalan.SetActive(true);
        }
        


    }

    private void Update()
    {
        if(devChange== 1)
        {
            PlayerPrefs.SetInt("BambuPlayedOnce", 0);
            Debug.Log("DEV RESET PREFS");
        }
    }

}
