using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHiveMovement : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    private Vector3 movementDirection;

    public float enemyHiveMovementSpeed = 2f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        movementDirection = player.transform.position - transform.position;
    }


    void Update()
    {
        transform.position += movementDirection * Time.deltaTime * enemyHiveMovementSpeed;

        if (Vector3.Distance(transform.position, player.transform.position) >= 50f) Destroy(gameObject);
    }
}
