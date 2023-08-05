using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FishMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed,0,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < screenBounds.x * 2) 
        {
            Destroy(this.gameObject);
        }
    }

        private void OnCollisionEnter(Collision collision)
    {

        //If the collision object is by either a fish or a ground element (coral) and against the player
        if(collision.gameObject.tag == "Player" && (gameObject.tag == "Fish"|| gameObject.tag == "Ground"))
        {
            Destroy(gameObject);
        }

        //If KillFish and Fish collide
        if(collision.gameObject.tag == "KillFish" && gameObject.tag == "Fish")
        {
            Destroy(gameObject);
        }

        //If KillFish and Fish collide
        if(collision.gameObject.tag == "Player" && gameObject.tag == "KillFish")
        {
            Debug.Log("Farts!!!!");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
