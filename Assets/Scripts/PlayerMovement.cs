using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public static bool spinning, sliding, isGrounded, shouldJump;
    private Vector3 movementInput;
    public CapsuleCollider playerCollider;
    public LayerMask ground;

    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator animcharacter;
    // Start is called before the first frame update
    void Awake()
    {
        isGrounded = spinning = sliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Grounded();
        JumpPlayer();
        ActionsPlayer();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(movementInput.magnitude > 0)
        {
            movementInput.Normalize();
            animcharacter.SetBool("walk", true);
            playerBody.MovePosition(transform.position + movementInput *  speed * Time.deltaTime);

            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
            animcharacter.SetBool("walk", false);

        if(shouldJump)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animcharacter.SetTrigger("jump");
            shouldJump = false;
        }
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            shouldJump = true;
        }
    }

    void ActionsPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spinning = true;
            animcharacter.SetTrigger("spin");
            StartCoroutine(ActionTime(spinning));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isGrounded)
            {
                sliding = true;
                animcharacter.SetTrigger("slide");
                StartCoroutine(ActionTime(sliding));
            }
        }
    }

    IEnumerator ActionTime(bool action)
    {
        yield return new WaitForSeconds(1.5f);
        spinning = sliding = false;
    }

    private bool Grounded()
    {
        isGrounded = Physics.CheckCapsule(playerCollider.bounds.center, 
            new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y, playerCollider.bounds.center.z),
            playerCollider.radius * .9f, ground);
        return isGrounded;
    }
}
