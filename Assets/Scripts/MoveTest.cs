using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public static bool spinning, sliding, isGrounded;
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
        //MovePlayer();
    }
    private void FixedUpdate()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovePlayer();
    }

    void MovePlayer()
    {
        if (movementInput.magnitude > 0)
        {
            movementInput.Normalize();
            playerBody.MovePosition(transform.position + movementInput * speed * Time.deltaTime);

            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
