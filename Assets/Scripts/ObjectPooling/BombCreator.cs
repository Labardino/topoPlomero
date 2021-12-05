using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreator : MonoBehaviour
{
    public int bombInitialQty;
    public GameObject bombPrefab;
    public float timerMaxCount;

    [HideInInspector]
    public GameObject bombNew;
    private Vector3 spawnPosition;
    private ObjectPooling objectPooler;
    private float timer;

    private void Start()
    {
        RequestPool();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerMaxCount)
        { 
            objectPooler.FindBombPool(this);
            timer = 0;
        }
    }

    public void createBomb()
    {
        objectPooler.listBombs.Add(Instantiate(bombPrefab, ObjectPosition(), Quaternion.identity));
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
