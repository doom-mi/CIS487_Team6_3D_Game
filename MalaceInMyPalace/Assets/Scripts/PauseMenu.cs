using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
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
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
