using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    
    public Text timeText;
    public float timeLeft;
    public GameObject target;
    public int winScore;
    

    private bool timerOn = false;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
            score = target.GetComponent<ScoreCounter>().getScore();
            if (timeLeft <= 0 && score < winScore)
            {
                timeLeft = 0;
                FindObjectOfType<BasketGameManager>().LoseGame();
            }
        }
        else
        {
            timeLeft = 0;
            timerOn = false;
        }
        
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    

    
}
