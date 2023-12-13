using System.Collections;
using System.Collections.Generic;
using TowerDefense.UI;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public static bool gameEnd = false;
    public GameObject gameOverScreen;
    public GameObject buyMenuUI;
    public DialogueTrigger dialogueInit;

    void Update() {
        if (gameEnd == true) { return; }

        if (PlayerStats.Lives <= 0) {
            EndGame();
        }
    }

    void Start() 
    {
        gameEnd = false;
        dialogueInit.TriggerDialogue();
    }

    void EndGame() {
        gameEnd = true;
        buyMenuUI.SetActive(false);
        //gameOverScreen.SetActive(true);
        GameObject newObject = Instantiate(gameOverScreen, Vector3.zero, Quaternion.identity);
        newObject.SetActive(true);
        Debug.Log("Game Over!");
    }

}
