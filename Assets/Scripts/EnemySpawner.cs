using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject enemyPrefab;
    public GameObject enemyContainer;

    public float enemySpawnCooldown = 1.5f;
    private float tempEnemySpawnCooldown;
    public int enemySpawnAmount = 1;
    public int enemiesSpawned;

    void Start()
    {
        tempEnemySpawnCooldown = enemySpawnCooldown;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (float)Random.Range(0, 360));
            enemiesSpawned++;
            for (int i = 0; i < enemySpawnAmount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawner.transform.position.x + Random.Range(-2f, 2f), spawner.transform.position.y + Random.Range(-2f, 2f), 0f);
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));
                enemy.transform.name = "Enemy " + enemiesSpawned;
                enemy.transform.parent = enemyContainer.transform;
                if (enemiesSpawned % 10 == 0) IncreaseSpawn();
            }
            yield return new WaitForSeconds(tempEnemySpawnCooldown);
        }
    }

    void IncreaseSpawn()
    {
        if (tempEnemySpawnCooldown >= 1f) tempEnemySpawnCooldown -= 0.2f;
        else
        {
            tempEnemySpawnCooldown = enemySpawnCooldown - 1;
            enemySpawnAmount++;
        }
    }
}
