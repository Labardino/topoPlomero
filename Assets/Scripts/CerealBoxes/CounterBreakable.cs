using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBreakable : Breakable
{
    public int cerealCounter;
    private void Start()
    {
        cerealo = this.gameObject.GetComponent<CerealCreator>();
        cerealCounter = 0;
        cerealQty = RandoCerealQty();
    }

    public override void BelowInteraction(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * -3, ForceMode.Impulse);
        cerealCounter++;
        cerealo.CerealBoxCounter();
        if(cerealCounter == cerealQty)
        {
            Destroy(this.gameObject);
        }
    }
}
