using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // private CharacterController controller;
    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float playerSpeed = 5.0f;
    private float rotationSpeed = 720f;
    public PlayerControls playerControls;
    private InputAction swim;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        swim = playerControls.Swim.Move;
        swim.Enable();
    }

    private void OnDisable() {
        swim.Disable();
    }

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();
    }

    void Update()
    {

        /* This handles the physical movement of the gameobject */
        Vector2 input = swim.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, input.y, 0);
        
        move.Normalize();

        rb.velocity = new Vector3(move.x * playerSpeed, move.y * playerSpeed, 0f);


        /* This handles the rotation of the game object */
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(-move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }


}
