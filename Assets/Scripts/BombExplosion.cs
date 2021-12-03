using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float spherecastRadio;
    public float explosionForce;
    Vector3 vectorDistance;
    private float centerModifierX, centerModifierZ;

    public const float modifierValue=1.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 300f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            Explosion();
        }
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ExplosionPlayer();
        }
    }

    public void Explosion()
    {
        //Ray raySphere = new Ray(Vector3.zero, Vector3.one);
        Collider[] collisionList;
        collisionList = Physics.OverlapSphere(transform.position, spherecastRadio);
        if(collisionList.Length>0)
        {
            foreach(Collider nearby in collisionList)
            {
                Rigidbody rb = nearby.GetComponentInParent<Rigidbody>();
                if (rb)
                {

                    rb.AddExplosionForce(explosionForce, transform.position, spherecastRadio,3.0f);
                    //rb.AddExplosionForce(explosionForce, rb.transform.position, spherecastRadio);
                }
            }
            gameObject.SetActive(false);
        }
    }
    public void ExplosionPlayer()
    {
        //Ray raySphere = new Ray(Vector3.zero, Vector3.one);
        Collider[] collisionList;
        collisionList = Physics.OverlapSphere(transform.position, spherecastRadio);
        if (collisionList.Length > 0)
        {
            foreach (Collider nearby in collisionList)
            {
                Rigidbody rb = nearby.GetComponentInParent<Rigidbody>();
                if (rb)
                {
                    vectorDistance = this.transform.position - rb.gameObject.transform.position;
                    if(vectorDistance.z>0)
                    {
                        centerModifierZ = modifierValue;
                    }
                    else
                    {
                        centerModifierZ = -modifierValue;
                    }
                    if (vectorDistance.x > 0)
                    {
                        centerModifierX = modifierValue;
                    }
                    else
                    {
                        centerModifierX = -modifierValue;
                    }

                    rb.AddExplosionForce(explosionForce, new Vector3(transform.position.x + centerModifierX, transform.position.y, transform.position.z + centerModifierZ), spherecastRadio,3.0f);
                    //rb.AddExplosionForce()
                    //rb.AddExplosionForce(explosionForce, rb.transform.position, spherecastRadio);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
