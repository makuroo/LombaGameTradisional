using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text playerText;
    [SerializeField] private TMPro.TMP_Text ghostText;
    [SerializeField] private EnemyGlow glow;
    [SerializeField] private Light2D playerlight;
    [SerializeField] private GameObject petakUmpetCanvas;
    [SerializeField] private GameObject timerWarningCanvas;
    [SerializeField] private Movement movement;
    [SerializeField] private Image petakUmpetImage;
    [SerializeField] private PetakUmpetTimer timer;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private TutorialPetakUmpet tutorial;
    [SerializeField] private GameObject timelinePanel;
    [SerializeField] private GameObject firstCanvas;
    private bool isStartLerp = false;
    private int prefPetakUmpet;
    [SerializeField] private bool resetPetakUmpetPref;

    // Start is called before the first frame update
    void Start()
    {
        if (resetPetakUmpetPref)
            PlayerPrefs.SetInt("prefPetakUmpet",0);

        PlayerPrefs.SetInt("prefPetakUmpet", 1);

        petakUmpetImage.CrossFadeAlpha(0, 0, true);
        StartCoroutine(WaitForStartCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartLerp)
        {
            isStartLerp = false;
            if (petakUmpetImage.color.a <= 0)
            {
                petakUmpetImage.CrossFadeAlpha(1, 2, true);
                Debug.Log(petakUmpetImage.color.a);
            }
        }

        if (petakUmpetImage.color.a >= 1 && petakUmpetImage.canvasRenderer.GetAlpha()==1)
        {
            petakUmpetCanvas.SetActive(false);
            timerWarningCanvas.SetActive(true);
        }
    }

    private IEnumerator StartDialogue()
    {
        playerText.text = "ada dimana aku gelap sekali";
        yield return new WaitForSeconds(2f);
        ghostText.text = "mari bermain petak umpet denganku bocah";
        yield return new WaitForSeconds(2f);
        playerText.text = "Suara itu, sepertinya itu suara hantu yang sering didengar di sekolah ku";
        audioManager.PlayOneShot("WeweGombel");
        yield return new WaitForSeconds(2f);
        playerText.text = "Tempat ini gelap sekali, Senter ini sepertinya akan membantu aku";
        playerlight.enabled = true;
        yield return new WaitForSeconds(2);
        playerText.text = "";
        ghostText.text = "";
        petakUmpetCanvas.SetActive(true);
        isStartLerp = true;
        petakUmpetImage.CrossFadeAlpha(1, 2, true);
        yield return new WaitForSeconds(5);
        petakUmpetImage.canvasRenderer.SetAlpha(0);
        timerWarningCanvas.SetActive(false);
        glow.startCountDown = true;
        movement.enabled = true;
        timer.startTimer = true;
        tutorial.gameObject.SetActive(true);
        tutorial.startTimer = true;
    }
    private IEnumerator WaitForStartCutscene()
    {
        prefPetakUmpet = PlayerPrefs.GetInt("prefPetakUmpet");
        if (prefPetakUmpet == 0)
        {
            yield return new WaitForSeconds(37);
            timelinePanel.SetActive(false);
            yield return new WaitForSeconds(3);
            firstCanvas.SetActive(false);
            StartCoroutine(StartDialogue());
            petakUmpetImage = petakUmpetCanvas.GetComponentInChildren<Image>();
            petakUmpetImage.canvasRenderer.SetAlpha(0);
        }
        else if(prefPetakUmpet == 1)
        {
            firstCanvas.SetActive(false);
            timelinePanel.SetActive(false);
            StartCoroutine(StartDialogue());
            petakUmpetImage = petakUmpetCanvas.GetComponentInChildren<Image>();
            petakUmpetImage.canvasRenderer.SetAlpha(0);
        }

    }
}
