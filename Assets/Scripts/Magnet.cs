using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Player player;
    private float playerPickupRangeOld;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= 1f)
        {
            ExpPoint[] expPoints = FindObjectsOfType<ExpPoint>();
            foreach(ExpPoint expPoint in expPoints)
            {
                expPoint.isInRange = true;
            }
            Destroy(gameObject);
        }
    }
}
