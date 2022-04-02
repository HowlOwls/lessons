using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask playerLayer;
   [SerializeField] private Transform player;
   [SerializeField] private float sightRange = 15f;
   [SerializeField] private float attackRange = 10f;
   [SerializeField] private float dist;
   [SerializeField] private bool playerInSightRange;
   [SerializeField] private bool playerInAttackRange;
   [SerializeField] private bool alreadyAttack;
   [SerializeField] private float timeBtwAttack = 2f;
   private void Awake()
   {
       player = GameObject.Find("player").transform;
   }

   private void Update()
   { 
       playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
      playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
      dist = Vector3.Distance(player.transform.position, transform.position);

      if (playerInSightRange && !playerInAttackRange)
      {
          transform.LookAt(player);
      }
      
      
      
      if (playerInSightRange && playerInAttackRange)
      {
          Attack();
      }
   }
   private void Attack()
   {
       transform.LookAt(player);
       if (!alreadyAttack)
       {
           var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
           alreadyAttack = true;
           Invoke(nameof(ResetAttack), timeBtwAttack);
       }
   }
   private void ResetAttack()
   {
       alreadyAttack = false;
   }
   private void OnDrawGizmos()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, attackRange);
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, sightRange);
   }
}
