using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    private GameObject enemy;
    
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (enemy == null)
        {
           enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            
        }
    }
}
