using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarScoreManager : MonoBehaviour
{

    public static CarScoreManager instance;

    public TMP_Text scoreText;
    public AudioSource nom;
    public AudioSource ew;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddPoint()
    {
        CarScoreManager.instance.nom.Stop();
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        CarScoreManager.instance.nom.Play();
        if (score >= 50)
        {
            CarGameManager.Instance.WinGame();
        }
    }

    public void LosePoint()
    {
        CarScoreManager.instance.ew.Stop();
        if (score > 1)
        {
           score -= 2;
        } else if (score == 1)
        {
            score -= 1;
        }
        CarScoreManager.instance.ew.Play();
        scoreText.text = "Score: " + score.ToString();
    }
}
