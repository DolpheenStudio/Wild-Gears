using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Player player;
    private Enemy enemy;

    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.enemySpeed * Time.deltaTime);
    }
}
