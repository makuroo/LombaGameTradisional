using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    
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

}
