using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;

    [SerializeField] private GameObject playGO;  
    [SerializeField] private GameObject optionGO;  
    [SerializeField] private GameObject quitGO;  
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        optionPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HoverPlay()
    {
        playGO.GetComponent<Image>().enabled = true;
    }

    public void QuitHoverPlay()
    {
        playGO.GetComponent<Image>().enabled = false;
    }

    public void HoverOption()
    {
        optionGO.GetComponent<Image>().enabled = true;
    }

    public void QuitHoverOption()
    {
        optionGO.GetComponent<Image>().enabled = false;
    }

    public void HoverQuit()
    {
        quitGO.GetComponent<Image>().enabled = true;
    }
    public void QuitHoverQuit()
    {
       quitGO.GetComponent<Image>().enabled = false;
    }
}
