using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] pickupItems;
    public GameObject expPointPrefab;
    public GameObject barrelBreakAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Random.Range(0, 4) == 0)
            {
                DropPickupItem();
            }
            else
            {
                DropExpPoints();
            }
            Instantiate(barrelBreakAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void DropPickupItem()
    {
        Instantiate(pickupItems[Random.Range(0, pickupItems.Length)], transform.position, Quaternion.identity);
    }

    private void DropExpPoints()
    {
        int expPointsAmount = Random.Range(4, 7);
        for (int i = 0; i < expPointsAmount; i++)
        {
            Instantiate(expPointPrefab, new Vector3(transform.position.x + (float)Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f), Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
