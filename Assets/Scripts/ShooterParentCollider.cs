using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterParentCollider : MonoBehaviour
{
    public ShooterWolfCreator[] childSpawn;
    private ObjectPooling objectPooler;
    public GameObject[] instanceShooter;

    private void Start()
    {
        RequestChild();
        RequestPool();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for (int i = 0; i < childSpawn.Length; i++)
            {
               instanceShooter[i] = objectPooler.ShooterWolfPool(childSpawn[i]);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for (int i = 0; i < instanceShooter.Length; i++)
            {
                Debug.Log("dede");
                instanceShooter[i].SetActive(false);
            }
        }
    }
    public void RequestPool()
    {
        objectPooler = FindObjectOfType<ObjectPooling>();
    }
    public void RequestChild()
    {
        childSpawn = GetComponentsInChildren<ShooterWolfCreator>();
        instanceShooter = new GameObject[childSpawn.Length];
    }

}
