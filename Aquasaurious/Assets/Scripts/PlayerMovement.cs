using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float playerSpeed = 5.0f;
    private float speedConstant = 0.0f;
    private float health = 1.0f;
    private float rotationSpeed = 720f;
    private float frameCount = 0.0f;

    public PlayerControls playerControls;
    private InputAction swim;


    private void Awake() {
        playerControls = new PlayerControls();
        speedConstant = playerSpeed;
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

        if(health <= 0) End();

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

    void FixedUpdate() {
        if(playerSpeed < speedConstant) {
            playerSpeed = Mathf.Lerp(playerSpeed, speedConstant, frameCount/720.0f);
            frameCount++;
        } else {
            health = 1.0f;
        }
    }

    public void Debuff() {
        playerSpeed = 1.0f;
        frameCount = 0.0f;
        health -= 0.5f;
    }

    public void End() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
