using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transition;
    public void StartGame()
    {
        SceneManager.LoadScene("ShootGame");
    }
    public void WinGame()
    {
        SceneManager.LoadScene("ShootEnd");
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("ShootLose");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Map");
    }
}