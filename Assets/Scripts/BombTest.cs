using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTest : MonoBehaviour
{
    public GameObject bomba, bombNew;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            bombNew = Instantiate(bomba, this.transform.position, Quaternion.identity, this.transform);
        }
    }
}
