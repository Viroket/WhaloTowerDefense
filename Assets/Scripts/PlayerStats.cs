using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerState playerState;
    public static PlayerCore playerCore;

    public static int Money;
    public int startMoney = 100;

    public static int Score;
    public int startScore = 0;

    public static int Lives;


    private void Awake()
    {
        playerCore = new PlayerCore();
        playerState = new PlayerState();
    }
    void Start()
    {
        InvokeRepeating("PlayerScoreFounds", 1f, 1f);
        Lives = playerCore.Hp;
        playerState.AddFunds(startMoney);
        Money = playerState.Funds;
        playerState.AddScore(startScore);
        Score = playerState.Score;

    }

    void PlayerScoreFounds()
    {
        playerState.AddScore(10);
        playerState.AddFunds(10);
    }

    public static int CurrentScore()
    {
        Score = playerState.Score;
        return Score;
    }

    public static int CurrentLives()
    {
        Lives = playerCore.Hp;
        return Lives;
    }

    public static void TakeDamage()
    {
        playerCore.TakeDamage(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
