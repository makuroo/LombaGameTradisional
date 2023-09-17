using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] private Slider volSlider;


    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.volume = volSlider.value;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        if (SceneManager.GetActiveScene().buildIndex == 0)
            Play("MainMenuMusic");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.audioType == 0)
        {
            s.source.loop = true;
        }
        else
        {
            s.source.loop = false;
        }
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying == false)
            s.source.PlayOneShot(s.clip);
    }

    public void SetVolume()
    {
        foreach (Sound s in sounds)
        {
            s.volume = volSlider.value;
            PlayerPrefs.SetFloat("Volume", volSlider.value);

            PlayerPrefs.Save();
            s.source.volume = s.volume;
        }
    }

}
