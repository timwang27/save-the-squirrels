using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public Text ammoText;
    public string startingAmmo = (SpawnScript.numSquirrels * 3).ToString();
    public int ammo = SpawnScript.numSquirrels * 3;
    private bool canShoot = true;

    public void Start()
    {
        ammoText.text = (ammo.ToString() + "/" + startingAmmo);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            ammo--;
            if (ammo < 10)
            {
                ammoText.text = ("0" + ammo.ToString() + "/" + startingAmmo);
            } else
            {
                ammoText.text = (ammo.ToString() + "/" + startingAmmo);
            }
            RaycastHit hit;
            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                if (hit.transform.name == "ShootSquirrel(Clone)")
                {
                    Destroy(hit.transform.gameObject);
                    ShootScoreManager.instance.AddPoint();
                    if (ShootScoreManager.instance.remaining == 0)
                    {
                        FindObjectOfType<GameManager>().WinGame();
                        canShoot = false;
                    }
                    else
                    {
                        FindObjectOfType<ShootAudioManager>().Play("KillSound");
                    }
                }
            }
            else
            {
                FindObjectOfType<ShootAudioManager>().Play("MissSound");
            }
            if (ammo == 0)
            {
                canShoot = false;
                FindObjectOfType<GameManager>().LoseGame();
            }
        }
        else
        {
            FindObjectOfType<ShootAudioManager>().Play("DryFire");
        }
    }
}