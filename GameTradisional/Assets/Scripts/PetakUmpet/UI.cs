using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionPanel;

    [SerializeField] private GameObject deadTextGO;

    [SerializeField] private GameObject playGO;
    [SerializeField] private GameObject optionGO;
    [SerializeField] private GameObject quitGO;
    [SerializeField] private GameObject jumpScarePanel;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private Sprite deadText;

    public bool isPaused = false;
    public bool isDead = false;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "PetakUmpet")
        {
            if (!isDead)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isPaused = !isPaused;
                    Time.timeScale = isPaused ? 0 : 1;
                }
                pausePanel.SetActive(isPaused);
            }
            else
            {
                StartCoroutine(DeadCoroutine());
            }
        }else if(sceneName == "BambuGila")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                Time.timeScale = isPaused ? 0 : 1;
            }
            pausePanel.SetActive(isPaused);
        }else if(sceneName == "ketapel")
        {
            if (!isDead)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isPaused = !isPaused;
                    Time.timeScale = isPaused ? 0 : 1;
                }
                pausePanel.SetActive(isPaused);
            }
            else
            {
                StartCoroutine(DeadCoroutine());
            }
        }

    }
    public void Options()
    {
        optionPanel.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        if(sceneName == "PetakUmpet")
        {
            SceneManager.LoadScene(1);
        }else if(sceneName == "BambuGila")
        {
            SceneManager.LoadScene(2);
        }else if(sceneName == "ketapel")
        {
            SceneManager.LoadScene(3);
        }

        Time.timeScale = 1;
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

    private IEnumerator DeadCoroutine()
    {
        jumpScarePanel.SetActive(true);
        audioManager.PlayOneShot("JumpScare");
        yield return new WaitForSeconds(2);
        deadTextGO.GetComponent<Image>().sprite = deadText;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
