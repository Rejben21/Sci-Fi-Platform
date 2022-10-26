using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public Transform scope, weapon;

    void Update()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(weapon.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(!PlayerController.instance.isTurned)
        {
            weapon.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if(PlayerController.instance.isTurned)
        {
            weapon.rotation = Quaternion.AngleAxis(180 + angle, Vector3.forward);
        }
    }
}
