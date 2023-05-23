using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChrisSceneManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadIntro()
    {
        // TODO
        SceneManager.LoadScene("EnterMazeScence");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MazeScene");
    }

    public void LoadWin()
    {
        PlayerPrefs.SetInt("currEvent", 1);
        SceneManager.LoadScene("MazeEnd");
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("MazeLose");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Map");
    }


}
