using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public bool isPaused;
        [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

      AudioManager audioManager;
      private bool isFirstStart = true;

          private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
                Time.timeScale = 1f; 
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SFXVolume") && isFirstStart)
        {
            LoadVolume();
            isFirstStart = false;
        } 
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            SaveVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused )
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        isPaused = false;
        audioManager.PlaySFX(audioManager.closePauseMenu);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        audioManager.PlaySFX(audioManager.openPauseMenu);
        isPaused = true;
        Time.timeScale = 0f;
    }

        public void playSound()
    {
        audioManager.PlaySFX(audioManager.optionClicked);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

     public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
        if (!isFirstStart) {
        SaveVolume();
        }
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFXVolume", Mathf.Log10(volume)*20);
        if (!isFirstStart) {
        SaveVolume();
        }
    }

        private void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
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

    public void RestartGame()
    {
        // Reload the scene to fully restart it
        audioManager.PlaySFX(audioManager.optionClicked);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
