using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePoint : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 1f)
        {
            player.playerUpgradePoints++;
            Destroy(gameObject);
        }
    }
}
