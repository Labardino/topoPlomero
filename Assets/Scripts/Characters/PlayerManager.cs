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
        livesPlayer = 3;
        playerCereals = 0;
    }
    #endregion

    public GameObject player;
    public int livesPlayer, playerCereals;

    public void RemoveOneLife()
    {
        livesPlayer--;
    }

    private void Update()
    {
        ExchangeMoneyForLife();
    }

    public void ExchangeMoneyForLife()
    {
        if (playerCereals >= 100)
        {
            playerCereals = 0;
            livesPlayer++;
        }

    }
}
