using System.Collections;
using System.Collections.Generic;
using TowerDefense.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    private bool gameEnd = false;

    void Update() {
        if (gameEnd == true) { return; }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void EndGame() {
        gameEnd = true;
        Debug.Log("Game Over!");
    }

}
