using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketGameManager : MonoBehaviour
{  
    void Start()
    {
        FindObjectOfType<BasketAudioManager>().Play("squirrelSong");
    }

    public void toGame()
    {
        SceneManager.LoadScene("Basketball");
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("BasketLose");
    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("currEvent", 2);
        SceneManager.LoadScene("BasketEnd");
    }

}
