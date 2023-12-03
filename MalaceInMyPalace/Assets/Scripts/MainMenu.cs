using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play()
    {
        // call first level or level selection scene
        UnityEngine.Debug.Log("Navigating to Level Selector Scene");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   

    public void Quit()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Application Quitting");
    }
}
