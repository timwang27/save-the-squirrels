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
        StartCoroutine(WinGameIE());
    }

    IEnumerator WinGameIE()
    {
        PlayerPrefs.SetInt("currEvent", 2);
        FindObjectOfType<BasketAudioManager>().Play("WinSound");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BasketEnd");
    }

}
