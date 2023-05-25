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
        StartCoroutine(WinGameIE());
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("ShootLose");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Map");
    }

    IEnumerator WinGameIE()
    {
        FindObjectOfType<ShootAudioManager>().Play("WinSound");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ShootEnd");
    }
}