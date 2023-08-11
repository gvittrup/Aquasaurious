using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float[] transparency = { .05f, .1f, .15f, .2f, .25f, .3f, .35f, .4f, .45f, 0.5f,
                                .55f, .6f, .65f, .7f, .75f, .8f, .85f, .9f, .95f, 1f,
                                .95f, .9f, .85f, .75f, .7f, .65f, .6f, .55f, .5f,
                                .45f, .4f, .35f, .3f, .25f, .2f, .15f, .1f, .05f };

    private Renderer renderer;
    private Color color;
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
        renderer = gameObject.transform.GetChild(1).transform.GetComponent<Renderer>();
        color = renderer.material.color;
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

    public void Debuff() { StartCoroutine(StatusEffects(2f, 0.01f)); }

    IEnumerator StatusEffects(float time, float intervalTime)
    {
        health -= 0.5f;
        playerSpeed = 3.0f;

        float elapsedTime = 0f;
        int index = 0;
        while(elapsedTime < time)
        {
            color.a = transparency[index % transparency.Length];
            renderer.material.color = color;

            elapsedTime += Time.deltaTime;
            playerSpeed += Time.deltaTime;
            index++;

            yield return new WaitForSecondsRealtime(intervalTime);
        }

        playerSpeed = speedConstant;
        health = 1.0f;
        color.a = 1.0f;
        renderer.material.color = color;
    }

    public void End() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
