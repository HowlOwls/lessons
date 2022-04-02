using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Триггер сработал");
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion,1f);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
