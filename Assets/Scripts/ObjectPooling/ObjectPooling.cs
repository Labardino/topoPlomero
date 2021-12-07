using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //BOMB VARIABLES
    [HideInInspector]
    public List<GameObject> listBombs;
    public int initialBombs;
    public GameObject bombPrefab, bombActive;
    private Rigidbody rigiBomb;

    //BULLET VARIABLES
    [HideInInspector]
    public List<GameObject> listBullets;
    [Space]
    public int initialBullets;
    public GameObject bulletPrefab, bulletActive;

    //CEREAL VARIABLES
    [HideInInspector]
    public List<GameObject> listCereals;
    [Space]
    public int initialCereals;
    public GameObject cerealPrefab, cerealActive, cerealoActive;


    //WOLF VARIABLES
    [HideInInspector]
    public List<GameObject> listGliderWolves;
    [Space]
    public int initialGliderWolves;
    public GameObject wolfGliderPrefab, gliderActive;

    //WOLF VARIABLES
    [HideInInspector]
    public List<GameObject> listShooterWolves;
    [Space]
    public int initialShooterWolves;
    public GameObject wolfShooterPrefab, shooterActive;

    //Explosion VARIABLES
    [HideInInspector]
    public List<GameObject> listExplosions;
    [Space]
    public int initialExplosions;
    public GameObject explosionPrefab, explosionActive;


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
        InitialExplosions();
        InitialGliderWolves();
        InitialShooterWolves();
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
    public void InitialExplosions()
    {
        for (int i = 0; i < initialExplosions; i++)
        {
            objectActive = Instantiate(explosionPrefab, Vector3.zero, Quaternion.identity);
            listExplosions.Add(objectActive);
            objectActive.SetActive(false);
        }
    }
    public void InitialGliderWolves()
    {
        for (int i = 0; i < initialGliderWolves; i++)
        {
            objectActive = Instantiate(wolfGliderPrefab, Vector3.zero, Quaternion.identity);
            listGliderWolves.Add(objectActive);
            objectActive.SetActive(false);
        }
    }
    public void InitialShooterWolves()
    {
        for (int i = 0; i < initialShooterWolves; i++)
        {
            objectActive = Instantiate(wolfShooterPrefab, Vector3.zero, Quaternion.identity);
            listShooterWolves.Add(objectActive);
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
                bombActive = listBombs[i];
                rigiBomb = bombActive.GetComponent<Rigidbody>();
                rigiBomb.velocity = Vector3.zero;
                rigiBomb.angularVelocity = Vector3.zero;
                bombActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            bombo.createBomb();
        }
    }
    public void GliderWolfPool(GliderWolfCreator wolfo)
    {
        found = false;
        for (int i = 0; i < listGliderWolves.Count; i++)
        {
            if (!listGliderWolves[i].activeInHierarchy)
            {
                listGliderWolves[i].transform.SetPositionAndRotation(new Vector3(wolfo.gameObject.transform.position.x,
                                                                        wolfo.gameObject.transform.position.y,
                                                                        wolfo.gameObject.transform.position.z), wolfo.transform.rotation);
                gliderActive = listGliderWolves[i];
                gliderActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            wolfo.createGliderWolf();
        }
    }

    public GameObject ShooterWolfPool(ShooterWolfCreator wolfoShoot)
    {
        found = false;
        for (int i = 0; i < listShooterWolves.Count; i++)
        {
            if (!listShooterWolves[i].activeInHierarchy)
            {
                listShooterWolves[i].transform.SetPositionAndRotation(new Vector3(wolfoShoot.gameObject.transform.position.x,
                                                                        wolfoShoot.gameObject.transform.position.y,
                                                                        wolfoShoot.gameObject.transform.position.z), wolfoShoot.transform.rotation);
                shooterActive = listShooterWolves[i];
                shooterActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            shooterActive = wolfoShoot.createShooterWolf();
        }
        return shooterActive;
    }
    public void BulletPool(BulletCreator bulleto, BulletPos bulletPos)
    {
        found = false;
        for (int i = 0; i < listBullets.Count; i++)
        {
            if (!listBullets[i].activeInHierarchy)
            {
                listBullets[i].transform.SetPositionAndRotation(bulletPos.BazookaPos(), bulleto.gameObject.transform.rotation);
                bulletActive = listBullets[i];
                bulletActive.SetActive(true);
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
                cerealActive = listCereals[i];
                cerealActive.SetActive(true);
                found = true;
                foundCereals++;
                if (foundCereals == qty)
                    break;
            }
        }
        if (foundCereals < qty)
        {
            for (int i = 0; i < qty - foundCereals; i++)
            {
                cerealo.createCereal();
            }
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
                cerealoActive = listCereals[i];
                cerealoActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            cerealo.createCereal();
        }
    }

    public void ExplosionPool(ExplosionCreator explosio)
    {
        found = false;
        for (int i = 0; i < listExplosions.Count; i++)
        {
            if (!listExplosions[i].activeInHierarchy)
            {
                listExplosions[i].transform.SetPositionAndRotation(explosio.transform.position, Quaternion.identity);
                explosionActive = listExplosions[i];
                explosionActive.SetActive(true);
                found = true;
                break;
            }
        }
        if (!found)
        {
            explosio.createExplosion();
        }
    }

}
