using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pistol : MonoBehaviour
{
   
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float spread;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float upwardForce = 10f;
    [SerializeField] private float range = 100f;
    private float timeShot;
    private float startTime;
    public int curAmmo;
    public int allAmmo;
    public int fullAmmo = 45;
    private void Update()
    {
        if (timeShot <= 0)
        {
            if(Input.GetButtonDown("Fire1") && curAmmo > 0)
                ShootLogic();
            timeShot = startTime;
        }
        else
        {
            timeShot -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
        {
            Reload();
        }
    }

    public void ShootLogic()
    {
        Vector3 targetPoint;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range, mask))
        {
            print("попал в " + hit.collider.name);
            targetPoint = hit.point; 
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }
      
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 directionWhithSpread = directionWithoutSpread + new Vector3(x, y, 0);
    
        GameObject curBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        curBullet.transform.forward = directionWhithSpread.normalized;
        curBullet.GetComponent<Rigidbody>().AddForce(directionWhithSpread.normalized * shootForce, ForceMode.Impulse);
        curBullet.GetComponent<Rigidbody>().AddForce(cam.transform.up * upwardForce, ForceMode.Impulse);
      
       curAmmo--;
    }

    private void Reload()
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
