using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
    private void OnCollisionEnter(Collision other)
    {
        this.gameObject.SetActive(false);
    }
}
