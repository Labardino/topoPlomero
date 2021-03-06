using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        livesPlayer = 5;
        playerCereals = 0;
        maxCereals = 20;
        winGame = false;
    }
    #endregion

    public GameObject player;
    public int livesPlayer, playerCereals, maxCereals;
    public bool winGame;
    private PlayerAudio audioPlay;

    private void Start()
    {
        audioPlay = FindObjectOfType<PlayerAudio>();
    }

    private void Update()
    {
        ExchangeCerealForLife();
    }
    public void FinishedLevel()
    {
        winGame = true;
    }
    public void RemoveOneLife() 
    {
        livesPlayer--;
        audioPlay.hurtSound();
    }

    public void RemoveAllLives()
    {
        livesPlayer = 0;
    }
    public void AddOneCereal()
    {
        playerCereals++;
    }

    public bool ExchangeCerealForLife()
    {
        if (playerCereals >= maxCereals)
        {
            playerCereals = 0;
            livesPlayer++;
            return true;
        }
        return false;
    }
}
