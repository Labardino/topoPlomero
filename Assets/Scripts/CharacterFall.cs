using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFall : MonoBehaviour
{
    private PlayerManager playerInfo;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInfo.RemoveAllLives();
        }
    }
}
