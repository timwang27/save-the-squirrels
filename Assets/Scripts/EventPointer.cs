using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mapbox Library
using Mapbox.Examples;
using Mapbox.Utils;

public class EventPointer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] float amplitude = 2.0f;
    [SerializeField] float frequency = 0.5f;

    LocationStatus playerLocation;
    public Vector2d eventPos;
    public int eventID;

    //Vector2d eventLocation;

    MenuUIManager menuUIManager;
    EventManager eventManager;
   //SpawnOnMap spawnOnMap;

    // Start is called before the first frame update
    void Start()
    {
        eventPos = new Vector2d(37.8724045, -122.2593255);
        menuUIManager = GameObject.Find("Canvas").GetComponent<MenuUIManager>();
        eventManager = GameObject.Find("-EventManager").GetComponent<EventManager>();
        //spawnOnMap = GameObject.Find("-EventSpawner").GetComponent<SpawnOnMap>();
        //eventLocation = spawnOnMap._locations[eventID];
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotatePointer();
    }

    void FloatAndRotatePointer()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime*Mathf.PI*frequency)*amplitude)+15, transform.position.z);
    }
    public void OnMouseDown()
    {
        //need to update this so it gets each event ID, and based on the ID, displays different EVENT PANEL!
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        var currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.GetLocationLat(), playerLocation.GetLocationLong());
        var eventLocation = new GeoCoordinatePortable.GeoCoordinate(eventPos[0], eventPos[1]);
        var distance = currentPlayerLocation.GetDistanceTo(eventLocation);
        Debug.Log("Event Pos 0 is: " + eventPos[0]);
        Debug.Log("Event Pos 1 is: " + eventPos[1]);
        Debug.Log("Distance is: " + distance);
        /**
        if(distance < eventManager.maxDistance)
        {
            menuUIManager.DisplayStartEventPanel(eventID);
        } else
        {
            menuUIManager.DisplayUserNotInRangePanel();
        }
        **/
    }

}
