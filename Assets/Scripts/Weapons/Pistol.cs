using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private WeaponLogic weapon;
    [SerializeField] private float range = 5f;
    [SerializeField] private float fireRate;
    public int curAmmo;
    public int allAmmo;
    public int fullAmmo = 45;
    public int damage = 100;

    private float nextFire = 0;

    private void Update()
    {
      Shoot();
      Reload();
    }

    private void Shoot()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire && curAmmo > 0)
        {
            nextFire = Time.time + 1f / fireRate;
            weapon.ShootLogic(range);
            curAmmo--;
        }
    }
    
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
        {
            int reason = 15 - curAmmo;
            if (allAmmo >= reason)
            {
                int result = allAmmo - reason;
                allAmmo = result;
                curAmmo = 15;
            }
            else
            {
                curAmmo = curAmmo + allAmmo;
                allAmmo = 0;
            }
        }
    }
}
