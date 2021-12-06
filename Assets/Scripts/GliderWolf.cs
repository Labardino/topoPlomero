using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderWolf : MonoBehaviour
{
    public float flyingSpeed;
    public GameObject lobo;
    // Start is called before the first frame update
    void Start()
    {
        lobo.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        lobo.SetActive(true);
        Fly();
    }
    IEnumerator Fly()
    {
        lobo.transform.position= Vector3.forward*Time.deltaTime*flyingSpeed;
        yield return new WaitForSeconds(.1f);
    }
}
