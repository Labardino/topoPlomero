using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float spherecastRadio;
    public float explosionForce;
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 300f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Terrain") || collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        Ray raySphere = new Ray(Vector3.zero, Vector3.one);
        Collider[] collisionList;
        collisionList = Physics.OverlapSphere(transform.position, spherecastRadio);
        if(collisionList.Length>0)
        {
            foreach(Collider nearby in collisionList)
            {
                Rigidbody rb = nearby.GetComponentInParent<Rigidbody>();

                if (rb)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, spherecastRadio);
                    rb.AddExplosionForce(explosionForce, rb.transform.position, spherecastRadio);
                }
                    
            }
            gameObject.SetActive(false);
        }
    }
}
