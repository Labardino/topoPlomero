using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCreator : MonoBehaviour
{
    public GameObject explosionPrefab;

    [HideInInspector]
    public GameObject explosionNew;
    private Vector3 spawnPosition;
    private ObjectPooling objectPooler;

    private void Start()
    {
        RequestPool();
    }

    public void PoolExplosion()
    {
        objectPooler.ExplosionPool(this);
    }

    public void createExplosion()
    {
        objectPooler.listBombs.Add(Instantiate(explosionPrefab, ObjectPosition(), Quaternion.identity));
    }

    public void RequestPool()
    {
        objectPooler = FindObjectOfType<ObjectPooling>();
    }

    Vector3 ObjectPosition()
    {
        spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        return spawnPosition;
    }
}
