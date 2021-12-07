using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    private PlayerManager playerInfo;
    public GameObject gameOverPanel, winGamePanel;

    #region Singleton
    public static EndGameUI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowWinGame()
    {
        winGamePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
