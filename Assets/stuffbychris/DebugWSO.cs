using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugWSO : MonoBehaviour
{
    Text stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject worldSpaceObject = GameObject.FindGameObjectWithTag("Maze");
        stats.text = worldSpaceObject.transform.position.ToString();
    }
}
