using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Sprite[] weaponSprites;
    private SpriteRenderer spriteRenderer;

    public Transform pistolFirePoint;
    public Transform[] shotgunFirePoints;
    public Transform rifleFirePoint;

    private Animator animator;
    public bool canAttack = true;
    public bool canShoot;

    public float timeToShoot;
    private float shootTime;
    public GameObject bulletPrefab;
    public GameObject shootEffect;
    public GameObject grenadePrefab;

    public enum CurrentWeapon
    {
        Knife,
        Pistol,
        Shotgun,
        Rifle,
    }

    public CurrentWeapon currentWeapon;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();

        shootTime = timeToShoot;
    }

    private void Update()
    {
        SwitchWeapon();
        
        shootTime -= Time.deltaTime;

        if(shootTime <= 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == CurrentWeapon.Knife && canAttack)
        {
            canAttack = false;
            KnifeAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == CurrentWeapon.Pistol && canShoot)
        {
            Instantiate(bulletPrefab, pistolFirePoint.position, pistolFirePoint.rotation);
            Instantiate(shootEffect, pistolFirePoint.position, pistolFirePoint.rotation, transform.parent);
            shootTime = 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == CurrentWeapon.Shotgun && canShoot)
        {
            Instantiate(bulletPrefab, shotgunFirePoints[0].position, shotgunFirePoints[0].rotation);
            Instantiate(bulletPrefab, shotgunFirePoints[1].position, shotgunFirePoints[1].rotation);
            Instantiate(bulletPrefab, shotgunFirePoints[2].position, shotgunFirePoints[2].rotation);
            Instantiate(bulletPrefab, shotgunFirePoints[3].position, shotgunFirePoints[3].rotation);
            Instantiate(bulletPrefab, shotgunFirePoints[4].position, shotgunFirePoints[4].rotation);
            Instantiate(shootEffect, shotgunFirePoints[0].position, shotgunFirePoints[0].rotation, transform.parent);
            shootTime = 0.6f;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && currentWeapon == CurrentWeapon.Rifle && canShoot)
        {
            Instantiate(bulletPrefab, rifleFirePoint.position, rifleFirePoint.rotation);
            Instantiate(shootEffect, rifleFirePoint.position, rifleFirePoint.rotation, transform.parent);
            shootTime = 0.1f;
        }
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        }
    }

    private void KnifeAttack()
    {
        animator.SetTrigger("KnifeAttack");
    }

    private void CanAttack()
    {
        canAttack = true;
    }

    private void SwitchWeapon()
    {
        switch (currentWeapon)
        {
            case CurrentWeapon.Knife:
                spriteRenderer.sprite = weaponSprites[0];
                break;
            case CurrentWeapon.Pistol:
                spriteRenderer.sprite = weaponSprites[1];
                break;
            case CurrentWeapon.Shotgun:
                spriteRenderer.sprite = weaponSprites[2];
                break;
            case CurrentWeapon.Rifle:
                spriteRenderer.sprite = weaponSprites[3];
                break;
            default:
                spriteRenderer.sprite = weaponSprites[0];
                break;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
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
