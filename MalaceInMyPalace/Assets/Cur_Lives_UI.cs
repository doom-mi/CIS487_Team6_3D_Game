using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cur_Lives_UI : MonoBehaviour
{
    public Text currencyUI;
    public Text livesUI;
    public Text waveCounterUI;

    // Update is called once per frame
    void Update()
    {
        currencyUI.text = "Money: " + PlayerStats.Money.ToString();
        livesUI.text = "Lives: " + PlayerStats.Lives.ToString();
        waveCounterUI.text = "Wave: " + PlayerStats.Rounds.ToString();

    }
}
