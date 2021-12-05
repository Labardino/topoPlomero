using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public List<GameObject> totalObjects;
    public int objQuantity;
    private float rando;
    public GameObject objPrefab, newObject;
    private Vector3 spawnPosition;

    private void Awake()
    {
        totalObjects = new List<GameObject>();
        spawnPosition = Vector3.zero;
        for (int i = 0; i < objQuantity; i++)
        {
            newObject = Instantiate(objPrefab, findRandomPos(), Quaternion.identity, this.transform);
            totalObjects.Add(newObject);
            newObject.SetActive(false);
        }
    }

    public void createBall()
    {
        totalObjects.Add(Instantiate(objPrefab, findRandomPos(), Quaternion.identity, this.transform));
    }
    public Vector3 findRandomPos()
    {
        rando = Random.Range(-3f, 3f);
        return new Vector3(rando, this.transform.position.y, this.transform.position.z);
    }

}
