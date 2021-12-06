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
    private Rigidbody rigiBomb;

    //BULLET VARIABLES
    [HideInInspector]
    public List<GameObject> listBullets;
    [Space]
    public int initialBullets;
    public GameObject bulletPrefab;

    //CEREAL VARIABLES
    [HideInInspector]
    public List<GameObject> listCereals;
    [Space]
    public int initialCereals;
    public GameObject cerealPrefab;


    //WOLF VARIABLES
    [HideInInspector]
    public List<GameObject> listWolves;
    [Space]
    public int initialWolves;
    public GameObject wolfPrefab;


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
        InitialCereals();
        InitialWolves();
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
    public void InitialCereals()
    {
        for (int i = 0; i < initialCereals; i++)
        {
            objectActive = Instantiate(cerealPrefab, Vector3.zero, Quaternion.Euler(-90,0,0));
            listCereals.Add(objectActive);
            objectActive.SetActive(false);
        }
    }
    public void InitialWolves()
    {
        for (int i = 0; i < initialWolves; i++)
        {
            objectActive = Instantiate(wolfPrefab, Vector3.zero, Quaternion.identity);
            listWolves.Add(objectActive);
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
                rigiBomb = objectActive.GetComponent<Rigidbody>();
                rigiBomb.velocity = Vector3.zero;
                rigiBomb.angularVelocity = Vector3.zero;
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
    public void FindWolfPool(GliderWolfCreator wolfo)
    {
        found = false;
        for (int i = 0; i < listWolves.Count; i++)
        {
            if (!listWolves[i].activeInHierarchy)
            {
                listWolves[i].transform.SetPositionAndRotation(new Vector3(wolfo.gameObject.transform.position.x,
                                                                        wolfo.gameObject.transform.position.y,
                                                                        wolfo.gameObject.transform.position.z), wolfo.transform.rotation);
                objectActive = listWolves[i];
                objectActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            wolfo.createBomb();
        }
    }
    public void BulletPool(BulletCreator bulleto, BulletPos bulletPos)
    {
        found = false;
        for (int i = 0; i < listBullets.Count; i++)
        {
            if (!listBullets[i].activeInHierarchy)
            {
                listBullets[i].transform.SetPositionAndRotation(bulletPos.BazookaPos(), bulleto.gameObject.transform.rotation);
                objectActive = listBullets[i];
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
    public void CerealPool(CerealCreator cerealo, int qty)
    {
        int foundCereals = 0;
        found = false;
        for (int i = 0; i < listCereals.Count; i++)
        {
            if (!listCereals[i].activeInHierarchy)
            {
                listCereals[i].transform.SetPositionAndRotation(cerealo.RandomPosition(), Quaternion.Euler(-90, 0, 0));
                objectActive = listCereals[i];
                objectActive.SetActive(true);
                found = true;
                foundCereals++;
                if (foundCereals == qty)
                    break;
            }
        }
        if (!found)
        {
            cerealo.createCereal();
        }
    }

    public void CerealPool(CerealCreator cerealo)
    {
        found = false;
        for (int i = 0; i < listCereals.Count; i++)
        {
            if (!listCereals[i].activeInHierarchy)
            {
                listCereals[i].transform.SetPositionAndRotation(cerealo.RandomPosition(), Quaternion.Euler(-90, 0, 0));
                objectActive = listCereals[i];
                objectActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            cerealo.createCereal();
        }
    }


}
