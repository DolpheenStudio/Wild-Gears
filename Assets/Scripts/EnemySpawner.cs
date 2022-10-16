using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemySpawnCooldown = 1;
    public Transform spawner;

    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, enemySpawnCooldown);
    }

    void SpawnEnemy()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, (float)Random.Range(0, 360));
        Instantiate(enemyPrefab, spawner.transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
