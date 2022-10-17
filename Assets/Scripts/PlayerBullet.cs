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
		if(closestEnemy == null) 
		{
			transform.position += transform.forward * Time.deltaTime * 2f;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, 2f * Time.deltaTime);
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
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Enemy")
		{
			Destroy(gameObject);
			coll.gameObject.GetComponent<Enemy>().DestroyEnemy();
		}
	}
}
