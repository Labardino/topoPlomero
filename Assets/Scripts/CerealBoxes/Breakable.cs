using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Vector3 vectorPoint;
    [HideInInspector]
    public int cerealQty;

    private float angleCollision;
    [HideInInspector]
    public Animator animcharacter;
    [HideInInspector]
    public CerealCreator cerealo;

    private void Start()
    {
        cerealo = this.gameObject.GetComponent<CerealCreator>();
        cerealQty = RandoCerealQty();
    }


    private void OnCollisionEnter(Collision other)
    {
        vectorPoint = other.contacts[0].point;
        angleCollision= Vector3.Angle(vectorPoint - this.transform.position, other.transform.up);
        animcharacter = other.gameObject.GetComponentInChildren<Animator>();
        //Debug.Log(angleCollision);


        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //jump above
            if (angleCollision < 60 && !PlayerMovement.isGrounded)
            {
                AboveInteraction(other);
            }
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                CreateCereal();
                DestroyObject(other);
            }
            if (angleCollision > 60 && !PlayerMovement.isGrounded)
            {
                BelowInteraction(other);
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {

        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (PlayerMovement.spinning || PlayerMovement.sliding)
            {
                CreateCereal();
                Destroy(this.gameObject);
            }
        }

    }

    public virtual void AboveInteraction(Collision other)
    {
        CreateCereal();
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

    public virtual int RandoCerealQty()
    {
        return Random.Range(3, 5);
    }

    public virtual void CreateCereal()
    {
        Debug.Log(cerealQty);
        if (cerealo)
            cerealo.CerealBoxDestroyed(cerealQty);
    }

}