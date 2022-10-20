using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject enemyPrefab;
    public GameObject enemyContainer;

    private float enemySpawnCooldown = 2f;
    private int enemiesSpawned = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void FixedUpdate()
    {
        if(enemiesSpawned % 30 == 0)
        {
            if (enemySpawnCooldown >= 0.1f) enemySpawnCooldown -= 0.1f;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(1 > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (float)Random.Range(0, 360));
            GameObject enemy = Instantiate(enemyPrefab, spawner.transform.position, Quaternion.Euler(0f, 0f, 0f));
            enemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(enemySpawnCooldown);
        }
    }
}
