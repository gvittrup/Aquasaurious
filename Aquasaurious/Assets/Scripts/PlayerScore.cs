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
    public float LEVEL_UP_LIMIT = 25.0f;

    void Start()
    {
        ScoreScreen.SetActive(false);
    }

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
            AddScore(1);

            if(score % LEVEL_UP_LIMIT == 0) { 
                gameObject.GetComponent<PlayerMovement>().LevelUp();
            }
        }
    }

    void AddScore(int s)
    {
        if(!gameObject.GetComponent<PlayerMovement>().isDead)
        {
            score += s;
        }
    }

    public void SetScore(int s) {
        score = s;
    }
}
