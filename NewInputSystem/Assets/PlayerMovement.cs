using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private Vector2 moveVector;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove");
        moveVector = context.ReadValue<Vector2>();
        
    }

    public void Move()
    {
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y;
        _characterController.Move(move*walkSpeed*Time.deltaTime);
    }
}
