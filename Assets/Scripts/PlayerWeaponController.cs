using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject[] weapons;
    private PlayerAimWeapon playerAimWeapon;

    public enum CurrentWeapon
    {
        Knife,
        Pistol,
        Shotgun,
        Rifle,
    }

    public CurrentWeapon currentWeapon;

    void Start()
    {
        playerAimWeapon = GetComponentInParent<PlayerAimWeapon>();
    }

    void Update()
    {
        switch(currentWeapon)
        {
            case CurrentWeapon.Knife:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                weapons[3].SetActive(false);
                playerAimWeapon.weapon = weapons[0].transform;
                break;
            case CurrentWeapon.Pistol:
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
                weapons[3].SetActive(false);
                playerAimWeapon.weapon = weapons[1].transform;
                break;
            case CurrentWeapon.Shotgun:
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                weapons[3].SetActive(false);
                playerAimWeapon.weapon = weapons[2].transform;
                break;
            case CurrentWeapon.Rifle:
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                weapons[3].SetActive(true);
                playerAimWeapon.weapon = weapons[3].transform;
                break;
            default:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                weapons[3].SetActive(false);
                playerAimWeapon.weapon = weapons[0].transform;
                break;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = CurrentWeapon.Knife;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = CurrentWeapon.Pistol;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = CurrentWeapon.Shotgun;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = CurrentWeapon.Rifle;
        }
    }
}
