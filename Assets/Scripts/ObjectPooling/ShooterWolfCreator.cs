using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterWolfCreator : MonoBehaviour
{
    public GameObject wolfShooterPrefab;


    [HideInInspector]
    public GameObject wolfShooterNew;
    private Vector3 spawnPosition;
    private ObjectPooling objectPooler;

    private void Start()
    {
        RequestPool();

    }

    public GameObject createShooterWolf()
    {
        wolfShooterNew = Instantiate(wolfShooterPrefab, ObjectPosition(), this.transform.rotation);
        objectPooler.listShooterWolves.Add(wolfShooterNew);
        return wolfShooterNew;
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
