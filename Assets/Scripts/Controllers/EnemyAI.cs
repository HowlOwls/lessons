using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask groundLayer, playerLayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    
    public float dist;
    [SerializeField] private float sightRange = 10;
    [SerializeField] private float attackRange = 5;
    
    [SerializeField] private bool playerInSightRange, playerInAttackRange;
    [SerializeField] private bool walkPointSet;
    [SerializeField] private bool alreadyAttack;

    private float timeBtwAttack = 5f;
    private float walkPointRange = 500f;
    private Vector3 walkPoint;
    private Rigidbody rb;
    private float speed = 3f;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
       
        dist = Vector3.Distance(player.transform.position, transform.position);
        

        if (playerInSightRange && !playerInAttackRange) // Если в радиусе обнаружения идет преследует игрока
        {
            
            agent.SetDestination(player.transform.position);
        }

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
       
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 3f)
            walkPointSet = false;

    }
    
    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttack)
        {
            Rigidbody rb = Instantiate(bullet, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
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
