using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public ObjectPooling objectPooler;
    public GameObject bulletPrefab;
    private Vector3 spawnPosition;

    private void Start()
    {
        RequestPool();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            objectPooler.BulletPool(this);
        }
    }

    public void createBullet()
    {
        objectPooler.listBullets.Add(Instantiate(bulletPrefab, ObjectPosition(), Quaternion.identity));
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
