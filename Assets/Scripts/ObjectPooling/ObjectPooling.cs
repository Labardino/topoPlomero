using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //BOMB VARIABLES
    [HideInInspector]
    public List<GameObject> listBombs;
    public int initialBombs;
    public GameObject bombPrefab;

    //BULLET VARIABLES
    [HideInInspector]
    public List<GameObject> listBullets;
    [Space]
    public int initialBullets;
    public GameObject bulletPrefab;

    //POOLING VARIABLES
    private GameObject objectActive;
    private bool found;

    #region Singleton
    public static ObjectPooling instance;
    private void Awake()
    {
        instance = this;
        listBombs = new List<GameObject>();
        listBullets = new List<GameObject>();
    }
    #endregion
    private void Start()
    {
        InitialBombs();
        InitialBullets();
    }

    public void InitialBombs()
    {
        for (int i = 0; i < initialBombs; i++)
        {
            objectActive = Instantiate(bombPrefab, Vector3.zero, Quaternion.identity);
            listBombs.Add(objectActive);
            objectActive.SetActive(false);
        }
    }
    public void InitialBullets()
    {
        for (int i = 0; i < initialBullets; i++)
        {
            objectActive = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            listBullets.Add(objectActive);
            objectActive.SetActive(false);
        }
    }

    public void FindBombPool(BombCreator bombo)
    {
        found = false;
        for (int i = 0; i < listBombs.Count; i++)
        {
            if (!listBombs[i].activeInHierarchy)
            {
                listBombs[i].transform.SetPositionAndRotation(new Vector3(bombo.gameObject.transform.position.x,
                                                                        bombo.gameObject.transform.position.y - 0.5f,
                                                                        bombo.gameObject.transform.position.z), Quaternion.identity);
                objectActive = listBombs[i];
                objectActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            bombo.createBomb();
        }
    }
    public void BulletPool(BulletCreator bulleto)
    {
        found = false;
        for (int i = 0; i < listBombs.Count; i++)
        {
            if (!listBombs[i].activeInHierarchy)
            {
                listBombs[i].transform.SetPositionAndRotation(new Vector3(bulleto.gameObject.transform.position.x,
                                                                        bulleto.gameObject.transform.position.y - 0.5f,
                                                                        bulleto.gameObject.transform.position.z), Quaternion.identity);
                objectActive = listBombs[i];
                objectActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            bulleto.createBullet();
        }
    }
}
