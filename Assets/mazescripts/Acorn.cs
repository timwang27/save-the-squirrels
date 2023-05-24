using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Controller>().updateAcornsAmount(-1);
            Destroy(this.gameObject);
        }
    }

}
