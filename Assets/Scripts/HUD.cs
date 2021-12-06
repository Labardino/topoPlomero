using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Image imageLives, imageCereal;
    public TextMeshProUGUI textLives, textCereal;
    private PlayerManager playerInfo;

    #region Singleton
    public static HUD instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
        UpdatePlayerLives();
        UpdatePlayerCereals();
    }
    public void UpdatePlayerLives()
    {
        textLives.gameObject.SetActive(true);
        imageLives.gameObject.SetActive(true);
        textLives.text = "X " + playerInfo.livesPlayer;
        StartCoroutine(ShowHideInfo(textLives, imageLives));
    }

    public void UpdatePlayerCereals()
    {
        textCereal.gameObject.SetActive(true);
        imageCereal.gameObject.SetActive(true);
        if (playerInfo.ExchangeCerealForLife())
        {
            UpdatePlayerLives();
        }
        textCereal.text = "X " + playerInfo.playerCereals;
        StartCoroutine(ShowHideInfo(textCereal, imageCereal));
    }

    IEnumerator ShowHideInfo(TextMeshProUGUI textInfo, Image imageInfo)
    {
        yield return new WaitForSeconds(3);
        textInfo.gameObject.SetActive(false);
        imageInfo.gameObject.SetActive(false);
    }
}
