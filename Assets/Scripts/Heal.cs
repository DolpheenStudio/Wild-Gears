using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Player player;
    private float playerPickupRangeOld;

    public float playerHeal = 10f;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 1f)
        {
            if (player.playerHealth + 10 <= player.playerMaxHealth) player.playerHealth += playerHeal;
            else player.playerHealth = player.playerMaxHealth;
            Destroy(gameObject);
        }
    }
}
