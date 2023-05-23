using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject eventPanelUserInRange;
    [SerializeField] private GameObject eventPanelUserNotInRange;
    [SerializeField] private GameObject cluePanel;
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private EventManager eventManager;

    public GameObject[] clues;
    public int ClueID; //Will control where in the array you are

    bool isUIPanelActive;
    int tempEventID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //LocationCheck
    public void LocationCheck()
    {
        if (eventManager.LocationMatch(ClueID)) {
            Debug.Log("Joined event:" + ClueID);
            eventManager.ActivateEvent(ClueID);
        } else {
            cluePanel.SetActive(false);
            eventPanelUserNotInRange.SetActive(true);
        }
        
    }

   

    public void CloseButtonClick()
    {
        eventPanelUserInRange.SetActive(false);
        eventPanelUserNotInRange.SetActive(false);
        cluePanel.SetActive(false);
        instructionsPanel.SetActive(false);
        isUIPanelActive = false;
        GameObject.Find("CluesButton").GetComponent<Button>().interactable = true;
        for (int j = 0; j < clues.Length; j++)
        {
            {
                clues[j].SetActive(false);
            }
        }
    }

    
    public void CluesClick()
    {
        /* if (isUIPanelActive == false)
        {
            cluePanel.SetActive(true);
            ClueID = 0;
            clues[ClueID].SetActive(true);
            isUIPanelActive = true;
            GameObject.Find("CluesButton").GetComponent<Button>().interactable = false;
        } */
        if (isUIPanelActive == false)
        {
            if (!PlayerPrefs.HasKey("currEvent"))
            {
                PlayerPrefs.SetInt("currEvent", 0);
            }
            ClueID = PlayerPrefs.GetInt("currEvent");
            Debug.Log("This is the ClueID");
            Debug.Log(ClueID);
            cluePanel.SetActive(true);
            clues[ClueID].SetActive(true);
            Debug.Log(clues[ClueID]);
            isUIPanelActive = true;
            GameObject.Find("CluesButton").GetComponent<Button>().interactable = false;
        }

    }

    public void InstructionsClick()
    {
        if (isUIPanelActive == false)
        {
            instructionsPanel.SetActive(true);
            isUIPanelActive = true;
        }
    }
    
    // public void BtnNext()
    // {
    //     PlayerPrefs.SetInt("currEvent", PlayerPrefs.GetInt("currEvent") + 1);
    //     ClueID = PlayerPrefs.GetInt("currEvent");
    //     Debug.Log(ClueID);
    //     clues[ClueID - 1].SetActive(false);
    //     clues[ClueID].SetActive(true);
        
    // }

    

/*
    public void BtnPrev ()
    {
        if (ClueID - 1 >= 0){
            ClueID--;
        }
        //clues.SetActive(false);
        clues[ClueID + 1].SetActive(false);
        clues[ClueID].SetActive(true);
    }
    */
}
