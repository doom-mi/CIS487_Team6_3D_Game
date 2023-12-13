using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{

     public TextMeshProUGUI roundsText;

    void OnEnable()
    {
        if(roundsText != null)
        {
        roundsText.text = PlayerStats.Rounds.ToString() + " Waves Survived";
        }
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadCurrentScene()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene by using its index
        SceneManager.LoadScene(currentSceneIndex);
    }
}
