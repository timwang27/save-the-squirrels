using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static MusicScript instance;
    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
