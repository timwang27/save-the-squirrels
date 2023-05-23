using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAcorn : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var squirrel = other.GetComponent<PlayerTouchMovement>();
        if (squirrel != null)
        {
            CarScoreManager.instance.AddPoint();
            Destroy(this.gameObject);
        }
    }
}
