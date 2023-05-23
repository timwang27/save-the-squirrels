using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject squirrel;
    public static int numSquirrels = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        int numSpawned = 0;
        int currSpawn = 0;
        while (numSpawned < numSquirrels + 5)
        {
            yield return new WaitForSeconds(3);
            int rotation = Random.Range(0, 180);
            Instantiate(squirrel, spawnPoints[currSpawn].position, Quaternion.Euler(0, rotation, 0));
            currSpawn = (currSpawn + 1) % spawnPoints.Length;
            numSpawned++;
        }
    }
}
