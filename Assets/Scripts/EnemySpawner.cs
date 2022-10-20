using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject enemyPrefab;
    public GameObject enemyContainer;

    private float enemySpawnCooldown = 2f;
    private int enemySpawnAmount = 1;
    private int enemiesSpawned = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void FixedUpdate()
    {
        if(enemiesSpawned % 10 == 0)
        {
            if (enemySpawnCooldown >= 0.1f) enemySpawnCooldown -= 0.1f;
            else 
            {
                enemySpawnAmount++;
                enemySpawnCooldown = 2f;
            }
            
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(1 > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (float)Random.Range(0, 360));
            for (int i = 0; i < enemySpawnAmount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawner.transform.position.x + Random.Range(-2f, 2f), spawner.transform.position.y + Random.Range(-2f, 2f), 0f);
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));
                enemy.transform.parent = enemyContainer.transform;
            }
            yield return new WaitForSeconds(enemySpawnCooldown);
        }
    }
}
