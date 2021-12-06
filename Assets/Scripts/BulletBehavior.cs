using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    private PlayerManager playerInfo;
    private HUD hudInfo;

    private void OnEnable()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
        hudInfo = FindObjectOfType<HUD>();
    }
    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInfo.RemoveOneLife();
            hudInfo.UpdatePlayerLives();
        }
        this.gameObject.SetActive(false);
    }
}
