using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBreakable : Breakable
{
    public override void AboveInteraction(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 8, ForceMode.Impulse);
    }
}
