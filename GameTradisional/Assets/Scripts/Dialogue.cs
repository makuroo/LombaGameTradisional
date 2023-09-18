using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text playerText;
    [SerializeField] private TMPro.TMP_Text ghostText;
    [SerializeField] private EnemyGlow glow;
    [SerializeField] private Light2D playerlight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartDialogue()
    {
        playerText.text = "ada dimana aku gelap sekali";
        yield return new WaitForSeconds(2f);
        ghostText.text = "mari bermain petak umpet denganku bocah";
        yield return new WaitForSeconds(2f);
        playerText.text = "Suara itu, sepertinya itu suara hantu yang sering didengar di sekolah ku";
        yield return new WaitForSeconds(2f);
        playerText.text = "Tempat ini gelap sekali, Senter ini sepertinya akan membantu aku";
        playerlight.enabled = true;
        glow.startCountDown = true;
    }
}
