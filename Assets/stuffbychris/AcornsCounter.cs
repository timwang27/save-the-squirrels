using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcornsCounter : MonoBehaviour
{
    Text counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<Text>();
        updateAcornsAmount();
    }

    // Update is called once per frame
    public void updateAcornsAmount()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        counter.text = "Acorns Left: " + player.GetComponent<Controller>().acorns();
    }

}
