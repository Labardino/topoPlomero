using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBreakable : Breakable
{
    public int maxCounter;
    private void Start()
    {
        cerealCounter = 0;
    }

    public override void BelowInteraction(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * -3, ForceMode.Impulse);
        cerealCounter++;
        if(cerealCounter == maxCounter)
        {
            Destroy(this.gameObject);
        }
    }
}
