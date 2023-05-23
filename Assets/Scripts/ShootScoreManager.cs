using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScoreManager : MonoBehaviour
{
    public static ShootScoreManager instance;
    public Text scoreText;
    public int remaining = SpawnScript.numSquirrels;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = (remaining.ToString() + " REMAINING");
    }

    public void AddPoint()
    {
        remaining -= 1;
        if (remaining < 10)
        {
            scoreText.text = ("0" + remaining.ToString() + " REMAINING");
        } else
        {
            scoreText.text = (remaining.ToString() + " REMAINING");
        }
    }
}
