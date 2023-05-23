using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var squirrel = other.GetComponent<PlayerTouchMovement>();
        if (squirrel != null)
        {
            CarScoreManager.instance.LosePoint();
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(7);
        Destroy(this.gameObject);
    }
}
