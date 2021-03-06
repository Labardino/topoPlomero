using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private PlayerManager playerInfo;
    private EndGameUI endPanel;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
        endPanel = FindObjectOfType<EndGameUI>();
    }

    private void Update()
    {
        if(playerInfo.livesPlayer <= 0)
        {
            LoseLevel();
        }
    }

    public void LoseLevel()
    {
        endPanel.ShowGameOver();
        StartCoroutine(SceneDelay(SceneManager.GetActiveScene()));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SceneDelay(Scene sceneo)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneo.name);
    }
}
