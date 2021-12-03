using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Vector3 vectorPoint;
    private float angleCollision;
    [HideInInspector]public int cerealCounter;
    private Animator animcharacter;


    private void OnCollisionEnter(Collision other)
    {
        vectorPoint = other.contacts[0].point;
        angleCollision= Vector3.Angle(vectorPoint - this.transform.position, other.transform.up);
        animcharacter = other.gameObject.GetComponentInChildren<Animator>();
        Debug.Log(angleCollision);

        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //jump above
            if (angleCollision < 60 && !PlayerMovement.isGrounded)
            {
                animcharacter.speed = 0.65f;
                animcharacter.SetTrigger("jump");
                AboveInteraction(other);
            }
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                DestroyObject(other);
            }
            if (angleCollision > 125 && !PlayerMovement.isGrounded)
            {
                BelowInteraction(other);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (PlayerMovement.spinning || PlayerMovement.sliding)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void AboveInteraction(Collision other)
    {
        DestroyObject(other);
    }

    public virtual void BelowInteraction(Collision other)
    {
        Destroy(this.gameObject);
    }

    public virtual void DestroyObject(Collision other)
    {
        Destroy(this.gameObject);
    }


}