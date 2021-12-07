using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterParentCollider : MonoBehaviour
{
    public ShooterWolfCreator childSpawn;
    private ObjectPooling objectPooler;
    public GameObject instanceShooter;

    private void Start()
    {
        RequestChild();
        RequestPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            instanceShooter = objectPooler.ShooterWolfPool(childSpawn);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Glider"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            instanceShooter.gameObject.SetActive(false);
        }
    }
    public void RequestPool()
    {
        objectPooler = FindObjectOfType<ObjectPooling>();
    }
    public void RequestChild()
    {
        childSpawn = GetComponentInChildren<ShooterWolfCreator>();
    }

}
