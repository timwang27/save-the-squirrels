using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballGameManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Player is starting basketball game");
        SceneManager.LoadScene("Basketball");
    }
    public void WinGame()
    {
        Debug.Log("Player has won basketball game");
        //StartCoroutine(MakeTransition("WinScene", 2f, 2f));
    }
    public void LoseGame()
    {
        Debug.Log("Player has lost basketball game");
        //StartCoroutine(MakeTransition("LoseScene", 2f, 2f));
    }
    public void Quit()
    {
        Debug.Log("Player has quit game");
        SceneManager.LoadScene("Map");
    }
}