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
        maxCereals = 69;
    }
    #endregion

    public GameObject player;
    public int livesPlayer, playerCereals, maxCereals;

    public void RemoveOneLife()
    {
        livesPlayer--;
    }
    public void AddOneCereal()
    {
        playerCereals++;
    }
    private void Update()
    {
        ExchangeCerealForLife();
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
