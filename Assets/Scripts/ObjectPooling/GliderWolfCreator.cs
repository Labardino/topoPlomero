using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderWolfCreator : MonoBehaviour
{
    public int wolfInitialQty;
    public GameObject wolfPrefab;


    [HideInInspector]
    public GameObject wolfNew;
    private Vector3 spawnPosition;
    private ObjectPooling objectPooler;

    private void Start()
    {
        RequestPool();

    }

    public void createBomb()
    {
        objectPooler.listWolves.Add(Instantiate(wolfPrefab, ObjectPosition(), Quaternion.identity));
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
