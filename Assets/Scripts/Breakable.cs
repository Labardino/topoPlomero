using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Vector3 vectorPoint;
    float angleCollision;

    private void OnCollisionEnter(Collision other)
    {
        vectorPoint = other.contacts[0].point;
        angleCollision= Vector3.Angle(vectorPoint - this.transform.position, other.transform.up);
        Debug.Log(angleCollision);
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //jump above
            if (angleCollision < 60 && PlayerMovement.isGrounded)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject);
            }
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                Debug.Log("Spin collision");
                Destroy(this.gameObject);
            }
            if (angleCollision > 125 && PlayerMovement.isGrounded)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * -3, ForceMode.Impulse);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (PlayerMovement.spinning || PlayerMovement.sliding)
        {
            Debug.Log("Spin Stay collision");
            Destroy(this.gameObject);
        }
    }
}
