using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mapbox.Examples;
using Mapbox.Utils;

public class EventManager : MonoBehaviour
{
    //currentPlayerLocation
    LocationStatus playerLocation;
    public Vector2 currPlayerLocation;
    //4 separate eventlocations
    public Vector2 DoeLocation;
    public Vector2 StadiumLocation;
    public Vector2 CampanileLocation;
    public Vector2 JacobsLocation;

    public int maxDistance = 10000;

    // Start is called before the first frame update
    
    void Start()
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();

        DoeLocation = new Vector2(37.8724045f, -122.2593255f);
        StadiumLocation = new Vector2(37.872527f, -122.260588f);
        CampanileLocation = new Vector2(37.871558f, -122.2599077f);
        JacobsLocation = new Vector2(37.876032f, -122.258743f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // checks currLocation with EventLocation
    public bool LocationMatch(int eventID)
    {
        Vector2 eventLocation = new Vector2(0f, 0f);
        if (eventID == 0) {
            eventLocation = DoeLocation;
        } else if (eventID == 1) {
            eventLocation = StadiumLocation;
        } else if (eventID == 2) {
            eventLocation = CampanileLocation;
        } else if (eventID == 3) {
            eventLocation = JacobsLocation;
        }
        currPlayerLocation = new Vector2((float)playerLocation.GetLocationLat(), (float)playerLocation.GetLocationLong());
        var distance = Vector2.Distance(currPlayerLocation, eventLocation);
        return (distance < maxDistance);
    }




    //clicking on join switches scenes to different minigames that corresponds to different event IDs
    public void ActivateEvent(int eventID)
    {
        if (eventID == 0) //Doe Library & Maze Game
        {
            Debug.Log("Loading Maze Game");
            SceneManager.LoadScene("EnterMazeScene");
        } else if (eventID == 1) //Cal Memorial Stadium & Basketball Game
        {
            Debug.Log("Loading Basketball Game");
            SceneManager.LoadScene("BasketEnter");

        } else if (eventID == 2) //Campanile & Car Race Game
        {
            Debug.Log("Loading Car Race Game");
            SceneManager.LoadScene("CarTitleScene");
        } else if (eventID == 3) //Jacobs Hall & Shooting Game
        {
            SceneManager.LoadScene("ShootStart");
        }
    }


}
