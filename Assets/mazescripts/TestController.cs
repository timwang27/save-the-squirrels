using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{

    float x_input;
    float y_input;
    float speed = 0.0f;
    public int acornsLeft;
    public float maxSpeed;

    Rigidbody PlayerRB;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        x_input = Input.GetAxis("Horizontal");
        y_input = Input.GetAxis("Vertical");


        if (x_input != 0 || y_input != 0)
        {
            StartCoroutine(lerpSpeed(maxSpeed, 5.0f));
        } else
        {
            speed = 0.0f;
            StopAllCoroutines();
        }

        if (x_input > 0)
        {
            PlayerRB.AddForce(Vector3.right * speed);
        }
        if (x_input < 0)
        {
            PlayerRB.AddForce(-Vector3.right * speed);
        }
        if (y_input > 0)
        {
            PlayerRB.AddForce(Vector3.forward * speed);
        }
        if (y_input < 0)
        {
            PlayerRB.AddForce(-Vector3.forward * speed);
        }

        if (Input.GetKeyDown("q"))
        {
            Debug.Log(acornsLeft);
        }

    }

    IEnumerator lerpSpeed(float endSpeed, float transitionTime)
    {
        float elapsedTime = 0.0f;
        while (speed != endSpeed)
        {
            speed = Mathf.Lerp(speed, endSpeed, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
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
