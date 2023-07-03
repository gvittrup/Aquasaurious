using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // groundedPlayer = controller.isGrounded;
        // if (groundedPlayer && playerVelocity.y < 0)
        // {
        //     playerVelocity.y = 0f;
        // }


        /* This handles the physical movement of the gameobject */
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        /* This handles the rotation of the game object */
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }



        // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        // playerVelocity.y += gravityValue * Time.deltaTime;
        // controller.Move(playerVelocity * Time.deltaTime);
    }
}
