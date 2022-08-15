using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerJump : MonoBehaviour
{
    private CharacterController _characterController;
    
    [SerializeField] private float jumpForce=10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private const float Gravity = -9.8f;
    private Vector3 playerVelocity;
    private bool jump; //New input system
    private bool grounded;
    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.red);
        if (grounded == true)
            canJump = true;
        else
            canJump = false;
        Jump();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("OnJump");
        jump = context.ReadValueAsButton();
    }
    

    public void Jump()
    {
        Debug.Log("I'm jumping");
        if (jump==true && canJump == true)
        {
            canJump = false;
            playerVelocity.y+= Mathf.Sqrt(jumpForce * -3.0f * Gravity);
        }
        playerVelocity.y += Gravity * Time.deltaTime;
        _characterController.Move(playerVelocity * Time.deltaTime);
    }
}
