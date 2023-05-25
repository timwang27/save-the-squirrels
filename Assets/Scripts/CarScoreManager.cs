using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScoreManager : MonoBehaviour
{
    public static CarScoreManager instance;
    public Text scoreText;
    int score = 0;
    bool wonGame = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<BasketAudioManager>().Play("Music");
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddPoint()
    {
        if (!wonGame)
        {
            score += 1;
            scoreText.text = "Score: " + score.ToString();
            FindObjectOfType<CarAudioManager>().Play("Nom");
            if (score >= 50)
            {
                wonGame = true;
                CarGameManager.Instance.WinGame();
            }
        }
    }

    public void LosePoint()
    {
        if (!wonGame)
        {
            FindObjectOfType<CarAudioManager>().Play("Ew");
            if (score > 1)
            {
            score -= 2;
            } else if (score == 1)
            {
                score -= 1;
            }
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
