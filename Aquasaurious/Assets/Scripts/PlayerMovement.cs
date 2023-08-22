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
    private float rotationSpeed = 720f;
    private float frameCount = 0.0f;
    private ParticleSystem particle;

    private float playerSpeed = 5.0f;
    private float speedConstant = 0.0f;
    public bool isDead;
    public float health = 1.0f;
    public int level = 1;


    public float speedLevelUpFactor = 0.5f;
    public float sizeLevelUpFactor = 0.02f;

    public PlayerControls playerControls;
    private InputAction swim;

    public GameManagerScript gameManager;
    private ConstantForce cForce;
    private Vector3 forceDirection;


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

    public void ToggleSwim(bool x) {
        if(x) swim.Enable();
        else swim.Disable();
    }

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();
        renderer = gameObject.transform.GetChild(1).transform.GetComponent<Renderer>();
        color = renderer.material.color;
        particle = GameObject.Find("LevelUp").GetComponent<ParticleSystem>();
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

    // Simulates ~5 seconds
    public void Debuff() { StartCoroutine(StatusEffects(2f, 0.01f)); }

    IEnumerator StatusEffects(float time, float intervalTime)
    {
        health -= 0.5f;
        playerSpeed = 3.0f;

        float elapsedTime = 0f;
        int index = 0;
        while(elapsedTime < time && health != 1.0f)
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

    public void Spawn() { StartCoroutine(SpawnAnim(0.005f)); }

    IEnumerator SpawnAnim(float intervalTime)
    {
        int layer = LayerMask.NameToLayer("Null");
        gameObject.transform.position = new Vector3(-25f, 0f, 0f);
        gameObject.layer = layer;

        while(gameObject.transform.position.x <= 0.0f)
        {
            Vector3 difference = new Vector3(0.1f, 0.0f, 0.0f);
            gameObject.transform.position += difference;
            yield return new WaitForSecondsRealtime(intervalTime);
        }

        isDead = false;
        health = 1.0f;
        ToggleSwim(true);
        layer = LayerMask.NameToLayer("Player");
        gameObject.layer = layer;
    }

    public void LevelUp() {
        Debug.Log("You leveled up!");

        level++;

        speedConstant += speedLevelUpFactor;
        playerSpeed = speedConstant;

        Vector3 newScale = new Vector3(sizeLevelUpFactor, sizeLevelUpFactor, sizeLevelUpFactor);
        newScale += gameObject.transform.localScale;

        gameObject.transform.localScale = newScale;
        particle.Play();
    }

    //This handles game over canvas and disables player movement
    public void End() {

        
        if(!isDead){
            isDead = true;
            gameManager.gameOver();
            swim.Disable();
            cForce= GetComponent<ConstantForce>();
            forceDirection = new Vector3(0,-75,0);
            cForce.force = forceDirection;
        }


    }


}
