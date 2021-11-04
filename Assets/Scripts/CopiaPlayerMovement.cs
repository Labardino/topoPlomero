using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopiaPlayerMovement : MonoBehaviour
{
    private Vector3 movementInput;
    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animcharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movePlayer();

    }

    void movePlayer()
    {
        if (movementInput.magnitude > 0)
        {
            movementInput.Normalize();
            transform.Translate(movementInput * speed * Time.deltaTime, Space.World);
            
            animcharacter.SetBool("walk", true);
            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animcharacter.SetBool("walk", false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
           // animcharacter.SetBool("jump", true);
            //deslizar con shift
            //spin con q
            //caminar con w



            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animcharacter.SetTrigger("slide");
            //playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


}
