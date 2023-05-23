using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;
    public Text ammoText;
    public int ammo = 10;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ammoText.text = (ammo.ToString() + "/10");
    }

    public void UseAmmo()
    {
        ammo -= 1;
        ammoText.text = (ammo.ToString() + "/10");
    }
}
