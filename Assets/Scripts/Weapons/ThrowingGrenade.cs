using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenade : MonoBehaviour
{
   [SerializeField] private Camera cam;
   [SerializeField] private GameObject grenadePref;
   [SerializeField] private Transform spawnPosition;
   [SerializeField] private float throwForce;
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.G))
      {
         GameObject curGrenade = Instantiate(grenadePref, spawnPosition.position, spawnPosition.rotation);
         curGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
      }
   }
}
