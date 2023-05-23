using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootSound
{
    public string name;

    public string group;

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

}