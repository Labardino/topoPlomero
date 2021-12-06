using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBites : MonoBehaviour
{
    private bool pickable;
    private float rotationsPerMinute = 20;

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

    private void Update()
    {
        transform.Rotate(0, 0, (float)(6.0 * rotationsPerMinute * Time.deltaTime));
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
