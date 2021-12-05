using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreator : MonoBehaviour
{
    public List<GameObject> totalBombs;
    public int bombQty;
    private float rando;
    public GameObject bombPrefab, bombNew;
    private Vector3 spawnPosition;

    private void Awake()
    {
        totalBombs = new List<GameObject>();
        spawnPosition = Vector3.zero;
        for (int i = 0; i < bombQty; i++)
        {
            bombNew = Instantiate(bombPrefab, findRandomPos(), Quaternion.identity, this.transform);
            totalBombs.Add(bombNew);
            bombNew.SetActive(false);
        }
    }

    public void createBomb()
    {
        totalBombs.Add(Instantiate(bombPrefab, findRandomPos(), Quaternion.identity, this.transform));
    }
    public Vector3 findRandomPos()
    {
        rando = Random.Range(-3f, 3f);
        return new Vector3(rando, this.transform.position.y, this.transform.position.z);
    }

}
