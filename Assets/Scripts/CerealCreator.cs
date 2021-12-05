using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealCreator : MonoBehaviour
{
    public ObjectPooling objectPooler;
    public GameObject cerealPrefab;
    private Vector3 spawnPosition;

    private void Start()
    {
        RequestPool();
    }

    public void CerealBoxDestroyed(int qty)
    {
        objectPooler.CerealPool(this, qty);
    }

    public void CerealBoxCounter()
    {
        objectPooler.CerealPool(this);
    }

    public void createCereal()
    {
        objectPooler.listBullets.Add(Instantiate(cerealPrefab, ObjectPosition(), Quaternion.identity));
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

    public Vector3 RandomPosition()
    {
        float randomModifierX, randomModifierZ;
        randomModifierX = Random.Range(-1.5f, 1.5f);
        randomModifierZ = Random.Range(-1.5f, 1.5f);
        spawnPosition = new Vector3(this.transform.position.x + randomModifierX, this.transform.position.y + 0.5f, this.transform.position.z + randomModifierZ);
        return spawnPosition;
    }
}
