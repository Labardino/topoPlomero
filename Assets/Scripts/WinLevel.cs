using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    private PlayerManager playerInfo;
    private EndGameUI endoPanel;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
        endoPanel = FindObjectOfType<EndGameUI>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInfo.FinishedLevel();
            endoPanel.ShowWinGame();
        }
    }
}
