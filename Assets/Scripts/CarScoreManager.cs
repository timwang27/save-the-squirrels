using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarScoreManager : MonoBehaviour
{
    public static CarScoreManager instance;
    public TMP_Text scoreText;
    int score = 0;

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
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        FindObjectOfType<CarAudioManager>().Play("Nom");
        //Change to 50
        if (score >= 5)
        {
            CarGameManager.Instance.WinGame();
        }
    }

    public void LosePoint()
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
