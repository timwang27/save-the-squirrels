 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class BeginUIManager : MonoBehaviour
{
    [SerializeField] private GameObject BeginPanel;
    [SerializeField] private List<GameObject> StoryPanels;
    private int storyNumber;
  
    // Start is called before the first frame update
    void Start()
    {
        BeginPanel.SetActive(true);
        storyNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginButtonClick()
    {
        Debug.Log("button clicked");
        BeginPanel.SetActive(false);
        StoryPanels[storyNumber].SetActive(true);
    }

    public void NextButtonClick()
    {
        StoryPanels[storyNumber].SetActive(false);
        storyNumber++;
        StoryPanels[storyNumber].SetActive(true);
    }

    public void EnterGameMap()
    {
        SceneManager.LoadScene("Map");
    }
}
