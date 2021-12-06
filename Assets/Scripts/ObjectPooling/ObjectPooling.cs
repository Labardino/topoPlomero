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
    public Rigidbody rigiBomb;

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
    public void BulletPool(BulletCreator bulleto)
    {
        found = false;
        for (int i = 0; i < listBullets.Count; i++)
        {
            if (!listBullets[i].activeInHierarchy)
            {
                listBullets[i].transform.SetPositionAndRotation(new Vector3(bulleto.gameObject.transform.position.x,
                                                                        bulleto.gameObject.transform.position.y - 0.5f,
                                                                        bulleto.gameObject.transform.position.z), Quaternion.identity);
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
