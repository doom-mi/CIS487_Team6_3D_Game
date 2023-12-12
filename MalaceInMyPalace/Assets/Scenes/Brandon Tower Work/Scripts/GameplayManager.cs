using System.Collections;
using System.Collections.Generic;
using TowerDefense.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public static bool gameEnd = false;
    public GameObject gameOverScreen;
    public GameObject buyMenuUI;

    void Update() {
        if (gameEnd == true) { return; }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void Start() 
    {
        gameEnd = false;
    }

    void EndGame() {
        gameEnd = true;
        buyMenuUI.SetActive(false);
         gameOverScreen.SetActive(true);
        //GameObject newObject = Instantiate(gameOverScreen, Vector3.zero, Quaternion.identity);
        Debug.Log("Game Over!");
    }

}
