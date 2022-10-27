using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject[] enemyPrefabs;
    public GameObject hivePrefab;
    public GameObject enemyContainer;

    public float enemySpawnCooldown = 1.5f;
    private float tempEnemySpawnCooldown;
    public int enemySpawnAmount = 1;
    public int enemiesSpawned;
    public int availableEnemyPrefabs = 0;

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
                GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, availableEnemyPrefabs + 1)], spawnPosition, Quaternion.Euler(0f, 0f, 0f));
                enemy.transform.name = "Enemy " + enemiesSpawned;
                enemy.transform.parent = enemyContainer.transform;
            }
            IncreaseSpawn();
            yield return new WaitForSeconds(enemySpawnCooldown);
        }
    }

    void IncreaseSpawn()
    {
        if(enemiesSpawned <= 30)
        {

        }
        else if (enemiesSpawned < 100)
        {
            if (enemiesSpawned % 10 == 0) enemySpawnCooldown -= 0.25f;
        }
        else if (enemiesSpawned == 100)
        {
            enemySpawnCooldown = 1f;
            availableEnemyPrefabs++;
        }
        else if (enemiesSpawned < 180)
        {
            if (enemiesSpawned % 10 == 0) enemySpawnCooldown -= 0.1f;
        }
        else if (enemiesSpawned == 180)
        {
            enemySpawnCooldown = 0.5f;
        }
        else if (enemiesSpawned < 300)
        {
            if(enemiesSpawned % 20 == 0)
            {
                Vector3 spawnPosition = new Vector3(spawner.transform.position.x + Random.Range(-2f, 2f), spawner.transform.position.y + Random.Range(-2f, 2f), 0f);
                GameObject enemy = Instantiate(hivePrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f));
                enemy.transform.name = "Hive " + enemiesSpawned;
                enemy.transform.parent = enemyContainer.transform;
            }
        }
        else if (enemiesSpawned == 300)
        {
            //availableEnemyPrefabs++;
        }
    }
}
