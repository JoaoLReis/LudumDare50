using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalTime;

    public MeteorShower meteorShower;
    public EndPopup endPopup;

    public Player player;

    public static float timeSinceGameStart = 0;
    public static float timeRemaining;
    public static bool isCountingTime = true;

    public static int numKills = 0;

    void Awake()
    {
        timeRemaining = totalTime;
        timeSinceGameStart = 0;
        isCountingTime = true;
        numKills = 0;
    }

    void Update()
    {
        if(!isCountingTime)
            return; 

        timeRemaining -= Time.deltaTime;
        timeSinceGameStart += Time.deltaTime;

        if(timeRemaining < 0)
        {
            timeRemaining = 0;
            EndGame();
        }
    }

    public void EndGame()
    {
        isCountingTime = false;
        player.isDead = true;
        player.playerMovement.Reset();
        player.playerShooting.Reset();
        meteorShower.StartMeteorShower();
        endPopup.ShowEndPopup();        
    }
}
