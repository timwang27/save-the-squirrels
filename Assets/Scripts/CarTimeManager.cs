using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarTimeManager : MonoBehaviour
{
    public float timeLeft;
    public Text timeText;
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
        } 
        //else
        //{
        //    timeLeft = 0;
        //    timerOn = false;
        //}
        if (timeLeft <= 0)
        {
            CarGameManager.Instance.LoseGame();
            Destroy(this.gameObject);
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime/ 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
