using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBites : MonoBehaviour
{
    private bool pickable;
    private float rotationsPerMinute = 20;
    public PlayerManager playerInfo;
    public HUD hudInfo;
    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
        hudInfo = FindObjectOfType<HUD>();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (pickable)
            {
                pickable = false;
                playerInfo.AddOneCereal();
                hudInfo.UpdatePlayerCereals();
                this.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, (float)(6.0 * rotationsPerMinute * Time.deltaTime));
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPickup());
        StartCoroutine(NoPickup());
    }
    IEnumerator WaitPickup()
    {
        yield return new WaitForSeconds(0.3f);
        pickable = true;
    }

    IEnumerator NoPickup()
    {
        yield return new WaitForSeconds(30f);
        this.gameObject.SetActive(false);
    }

}
