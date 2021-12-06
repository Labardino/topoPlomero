using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderWolf : MonoBehaviour
{
    public float flyingSpeed;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward *Time.deltaTime * flyingSpeed);
    }
}
