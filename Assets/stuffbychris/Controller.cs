using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private Rigidbody player;
    public bool isFlat;
    public int acornsLeft;
    public float movespeed;
    public bool gameFinished;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        gameFinished = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if (acornsLeft == 0)
        {
            gameFinished = true;
            FindObjectOfType<ChrisSceneManager>().LoadWin();
        }

        Vector3 tilt = Input.acceleration;

        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        player.AddForce(tilt * movespeed);

    }

    public int acorns()
    {
        return acornsLeft;
    }

    public void updateAcornsAmount(int amount)
    {
        acornsLeft += amount;
        GameObject text = GameObject.FindGameObjectWithTag("Text");
        AcornsCounter acornsCount = text.GetComponent<AcornsCounter>();
        acornsCount.updateAcornsAmount();
    }

}
