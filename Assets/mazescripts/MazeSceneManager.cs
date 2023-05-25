using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

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
        StartCoroutine(LoadWinIE());
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("MazeLose");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Map");
    }

    IEnumerator LoadWinIE()
    {
        PlayerPrefs.SetInt("currEvent", 1);
        FindObjectOfType<MazeAudioManager>().Play("WinSound");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MazeEnd");
    }


}
