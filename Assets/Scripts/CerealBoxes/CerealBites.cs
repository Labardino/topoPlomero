using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBites : MonoBehaviour
{
    public bool pickable;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (pickable)
            {
                Debug.Log("comi cereal");
                pickable = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPickup());
    }
    IEnumerator WaitPickup()
    {
        yield return new WaitForSeconds(1f);
        pickable = true;
    }
}
