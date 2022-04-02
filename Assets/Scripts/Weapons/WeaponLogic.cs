using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Camera playerCamera;


    private void Awake()
    {
        playerCamera = Camera.main;
    }


    public void ShootLogic(float range)
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
            Debug.Log(hit.collider.name);
    }
}
