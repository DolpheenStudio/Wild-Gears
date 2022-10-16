using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    private float enemySpeed = 1f;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }
}
