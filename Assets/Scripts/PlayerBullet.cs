using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private GameObject closestEnemy;
    void Start()
    {
        closestEnemy = FindClosestEnemy();
        transform.LookAt(closestEnemy.transform);
    }

    void Update()
    {
        Vector3.MoveTowards(transform.position, closestEnemy.transform.position, 1f * Time.deltaTime);
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;

        float distance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
