using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverProjectile : MonoBehaviour
{
    private GameObject closestEnemy;
    private bool isColliding;
    void Start()
    {
        closestEnemy = FindClosestEnemy();
        transform.LookAt(new Vector3(closestEnemy.transform.position.x, closestEnemy.transform.position.y, 0f));
        isColliding = false;
    }

    void Update()
    {
		if(closestEnemy == null) 
		{
			transform.position += transform.forward * Time.deltaTime * 4f;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, 4f * Time.deltaTime);
		}
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding)
        {
            return;
        }
        if (collision.gameObject.tag != "Player")
        {
            isColliding = true;
            Debug.Log("Trigger with" + collision.name);
            Destroy(gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().DestroyEnemy();
            }
        }
    }
}
