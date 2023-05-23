using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class MazeGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDebugText();
    }
    void UpdateDebugText()
    {
        Debug.Log("attempt update text");
        GameObject textObject = GameObject.FindGameObjectWithTag("RotationText");
        Text rotationText = textObject.GetComponent<Text>();
        var camera = GetComponent<ARSessionOrigin>().camera;
        rotationText.text = "" + camera.transform.position + camera.transform.forward;
    }
}
