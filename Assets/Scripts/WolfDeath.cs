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
                DestroyObject(other);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (PlayerMovement.spinning || PlayerMovement.sliding)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void DestroyObject(Collision other)
    {
        Destroy(this.gameObject);
    }
}
