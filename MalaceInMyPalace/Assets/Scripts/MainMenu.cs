using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

        AudioManager audioManager;
            [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

        private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        } 
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

   public void Play()
    {
        // call first level or level selection scene
        UnityEngine.Debug.Log("Navigating to Level Selector Scene");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

public void SetMusicVolume()
{
    float volume = musicSlider.value;
    myMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    SaveMusicVolume(); // Save the updated music volume
}

public void SetSFXVolume()
{
    float volume = SFXSlider.value;
    myMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    SaveSFXVolume(); // Save the updated SFX volume
}

private void SaveMusicVolume()
{
    PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    PlayerPrefs.Save();
}

private void SaveSFXVolume()
{
    PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    PlayerPrefs.Save();
}

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

        public void playSound()
    {
        audioManager.PlaySFX(audioManager.optionClicked);
    }

       public void LoadLevel1()
    {
        SceneManager.LoadScene("DomsNewScene");
    }

           public void LoadLevel2()
    {
        SceneManager.LoadScene("Kyle");
    }


    public void Quit()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Application Quitting");
    }
}
