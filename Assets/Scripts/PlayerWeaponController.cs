using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform[] firePoints;
    private PlayerAimWeapon playerAimWeapon;

    public float timeToShoot;

    public GameObject bulletPrefab;

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

        if (currentWeapon == CurrentWeapon.Knife && Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Knife Attack");
        }
        else if (currentWeapon == CurrentWeapon.Pistol && Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Pistol Shoot");
            Instantiate(bulletPrefab, firePoints[0].position, weapons[1].transform.rotation);
        }
        else if (currentWeapon == CurrentWeapon.Shotgun && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shotgun Shoot");
            Instantiate(bulletPrefab, firePoints[1].position, weapons[2].transform.rotation).GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10, 10));
        }
        else if (currentWeapon == CurrentWeapon.Rifle && Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Rifle Shoot");
            Instantiate(bulletPrefab, firePoints[2].position, weapons[3].transform.rotation);
        }
    }
}
