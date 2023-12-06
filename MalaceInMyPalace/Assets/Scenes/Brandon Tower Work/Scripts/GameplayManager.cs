using System.Collections;
using System.Collections.Generic;
using TowerDefense.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    private bool gameEnd = false;
    public GameObject gameOverScreen;

    void Update() {
        if (gameEnd == true) { return; }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameEnd = true;
        GameObject newObject = Instantiate(gameOverScreen, Vector3.zero, Quaternion.identity);
        Debug.Log("Game Over!");
    }

}
