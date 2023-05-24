using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score + "/5";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Acorn"))
        {
            FindObjectOfType<BasketAudioManager>().Play("Point");
            score += 1;
            scoreText.text = "Score: " + score + "/5";
            if (score == 5)
            {
                FindObjectOfType<BasketGameManager>().WinGame();
            }
        }
    }

    public int getScore()
    {
        return score;
    }
}
