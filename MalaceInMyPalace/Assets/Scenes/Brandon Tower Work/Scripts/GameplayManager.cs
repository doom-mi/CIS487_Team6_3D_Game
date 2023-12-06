using System.Collections;
using System.Collections.Generic;
using TowerDefense.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public static bool gameEnd;

    public GameObject gameOverUI;
    public GameObject buyMenuUI;


    void Start ()
    {
        gameEnd = false;
    }
    void Update() {
        if (gameEnd == true) { return; }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameEnd = true;
        buyMenuUI.SetActive(false);
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");
    }

}
