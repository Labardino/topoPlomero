using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public ObjectCreator objectCreator;
    public List<GameObject> listBalls;
    private float rando;
    private GameObject objectActive;
    private bool found;

    // Start is called before the first frame update
    void Awake()
    {
        listBalls = objectCreator.totalObjects;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            found = false;
            for (int i = 0; i < listBalls.Count; i++)
            {
                if (!listBalls[i].activeInHierarchy)
                {
                    listBalls[i].transform.SetPositionAndRotation(objectCreator.findRandomPos(), Quaternion.identity);
                    objectActive = listBalls[i];
                    objectActive.SetActive(true);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                objectCreator.createBall();
            }
        }
    }
}
