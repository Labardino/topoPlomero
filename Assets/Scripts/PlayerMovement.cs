using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
        public static bool spinning, sliding, isGrounded;
    private Vector3 movementInput;
    private CapsuleCollider playerCollider;
    public LayerMask ground;

    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = GetComponent<CapsuleCollider>();
        spinning = sliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovePlayer();
        ActionsPlayer();
    }

    void MovePlayer()
    {
        if(movementInput.magnitude > 0)
        {
            movementInput.Normalize();
            transform.Translate(movementInput *  speed * Time.deltaTime, Space.World);

            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void ActionsPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spinning = true;
            StartCoroutine(ActionTime(spinning));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Grounded())
        {
            sliding = true;
            StartCoroutine(ActionTime(sliding));
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
