using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    private ObjectPooling objectPooler;
    public GameObject bulletPrefab;
    private Vector3 spawnPosition;
    private BulletPos bulletSpawn;

    private void Start()
    {
        RequestPool();
    }

    private void OnEnable()
    {
        bulletSpawn = GetComponentInChildren<BulletPos>();
    }
    public void PoolBullet()
    {
        objectPooler.BulletPool(this, bulletSpawn);
    }

    public void createBullet()
    {
        objectPooler.listBullets.Add(Instantiate(bulletPrefab, bulletSpawn.BazookaPos(), this.transform.rotation));
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
