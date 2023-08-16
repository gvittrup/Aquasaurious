using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FishMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Vector3 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed,0,0);

        // This is to prevent objects from being static - adds atmospheric rotation
        if(gameObject.CompareTag("SceneComponent")) { 
            Vector3 torque = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)); 
            rb.AddTorque(torque);
        }

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    void Update()
    {
        if(transform.position.x < screenBounds.x * 2) 
        {
            Destroy(this.gameObject);
        }
    }

        private void OnCollisionEnter(Collision collision)
    {

        //Outer Switch = Object Collided With
        //Inner Switch = Object Colliding / Object Script Attached To
        switch(collision.gameObject.tag) {
            
            //Collided with Player
            case "Player":
                switch(gameObject.tag) {
                    case "Fish":
                        Destroy(gameObject);
                        break;
                    case "Ground":
                        collision.gameObject.GetComponent<PlayerMovement>().Debuff();
                        break;
                    case "SceneComponent":
                        collision.gameObject.GetComponent<PlayerMovement>().Debuff();
                        break;
                    case "KillFish":
                        Destroy(gameObject);
                        collision.gameObject.GetComponent<PlayerMovement>().End();
                        break;
                    default:
                        break;
                }
                break;
            
            //Collided w/ Kill Fish
            case "KillFish":
                switch(gameObject.tag) {
                    case "Fish":
                        Destroy(gameObject);
                        break;
                    default:
                        break;
                }
                break;

            //Collided w/ Scene Boundary (Water / Ground)
            case "SceneBoundary":
                switch(gameObject.tag) {
                    case "SceneComponent":
                        rb.AddForce(-5.0f, 0f, 0f, ForceMode.Impulse);
                        break;
                    default:
                        break;
                }
                break;

            default:
                break;
        }

    }
}
