using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    public int startLives = 20;
    public static int Rounds;

    private void Start() {

        Money = startMoney;
        Lives = startLives;
        Rounds = 1;
    } 
}
