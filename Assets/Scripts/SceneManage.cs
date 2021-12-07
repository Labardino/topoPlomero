using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public PlayerManager playerInfo;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        if(playerInfo.livesPlayer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
