 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarGameManager : MonoBehaviour
{
    public static CarGameManager Instance = null;

    #region Unity_functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region Scene_transitions

    public void StartGame()
    {
        SceneManager.LoadScene("CarMainGame");
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("CarLoseScene");
        MusicScript.instance.GetComponent<AudioSource>().Stop();
    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("currEvent", 3);
        SceneManager.LoadScene("CarEnd");
        MusicScript.instance.GetComponent<AudioSource>().Stop();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("CarTitleScene");
        MusicScript.instance.GetComponent<AudioSource>().Play();
    }

    #endregion

}