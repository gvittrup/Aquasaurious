using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject ScoreScreen;
    public GameObject InstructionScreen;
    public float levelUpMarker = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        ScoreScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(!InstructionScreen.activeSelf)
        {
            ScoreScreen.SetActive(true);
        }
        scoreText.SetText(score.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            AddScore();

            if(score % levelUpMarker == 0) { 
                gameObject.GetComponent<PlayerMovement>().LevelUp();
            }
        }
    }

    void AddScore()
    {
        score ++;
        if(!gameObject.GetComponent<PlayerMovement>().isDead)
        {
            score ++;
        }
    }
}
