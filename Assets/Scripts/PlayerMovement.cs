using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [SerializeField] private float moveSpeed, jumpForce, glideGravity;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody playerBody;
    private BoxCollider playerBoxCollider;
    private float horizontalMove;
    private bool isJump, isGliding, canGlide;

    private void Start()
    {
        isJump = false;
        playerBoxCollider = GetComponent<BoxCollider>();
        playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw(HORIZONTAL_AXIS) * moveSpeed;
        //verticalMove = Input.GetAxisRaw(VERTICAL_AXIS) * moveSpeed;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerBody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            canGlide = true;
        }
        
        if(Input.GetKey(KeyCode.LeftControl) && canGlide && !isGrounded())
        {
            //update velocity
            Vector3 currentVelocity = new Vector3(horizontalMove, glideGravity, moveSpeed);
            playerBody.velocity = currentVelocity;
        }
        else
        {
            //update velocity
            Vector3 currentVelocity = new Vector3(horizontalMove, playerBody.velocity.y, moveSpeed);
            playerBody.velocity = currentVelocity;
        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.01f;
        bool isHitting = Physics.Raycast(playerBoxCollider.bounds.center, Vector3.down, playerBoxCollider.bounds.extents.y + extraHeight, whatIsGround);
        
        Color rayColor;
        
        if(isHitting)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerBoxCollider.bounds.center, Vector3.down * (playerBoxCollider.bounds.extents.y + extraHeight), rayColor);
        
        return isHitting;
    }

}
