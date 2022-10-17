using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    private Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        InvokeRepeating("Shoot", 2f, player.playerAttackSpeed);
    }

    void Shoot()
    {
        Instantiate(playerBulletPrefab, transform.position, transform.rotation);
    }
}
