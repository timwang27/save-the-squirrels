using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeTimer : MonoBehaviour
{
    
    public Text timeText;
    public float timeLeft;

    private bool timerOn = false;
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
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                FindObjectOfType<ChrisSceneManager>().LoadLose();
            } 
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

