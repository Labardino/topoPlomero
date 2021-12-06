using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCollider : MonoBehaviour
{
    public GliderWolfCreator childSpawn;
    public float timerMaxCount;


    [HideInInspector]
    private float timer;
    private bool inTrigger;
    private ObjectPooling objectPooler;

    private void Start()
    {
        RequestChild();
        RequestPool();
        inTrigger = false;
    }

    private void Update()
    {
        if(inTrigger)
        {
            timer += Time.deltaTime;
            if (timer >= timerMaxCount)
            {
                objectPooler.FindWolfPool(childSpawn);
                timer = 0;
            }
        }
       
    }
    public void RequestChild()
    {
        childSpawn = GetComponentInChildren<GliderWolfCreator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            timer = timerMaxCount;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inTrigger = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Glider"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inTrigger = false;
            timer = 0;
        }
    }
    public void RequestPool()
    {
        objectPooler = FindObjectOfType<ObjectPooling>();
    }

}
