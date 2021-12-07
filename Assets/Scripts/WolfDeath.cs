using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                DeactivateWolf();
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                DeactivateWolf();
            }
        }
    }

    public virtual void DeactivateWolf()
    {
        gameObject.SetActive(false);
    }
}
