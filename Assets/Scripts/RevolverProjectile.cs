using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverProjectile : MonoBehaviour
{
    private GameObject targetEnemy;
    public RevolverWeapon revolverWeapon;
    private bool isColliding;
    private float weaponDamage;
    void Start()
    {
        FindClosestEnemy();
        
        isColliding = false;
        weaponDamage = revolverWeapon.revolverDamage;
    }

    void Update()
    {
        transform.LookAt(new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y, 0f));
        if (targetEnemy == null) 
		{
			transform.position += transform.forward * Time.deltaTime * 4f;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, 4f * Time.deltaTime);
		}
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject tempEnemy = null;

        float distance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                tempEnemy = enemy;
            }
        }
        targetEnemy = tempEnemy;
    }

    void FindRandomEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= 100f)
            {
                enemiesInRange.Add(enemy);
            }
        }
        targetEnemy = enemiesInRange[Random.Range(0, enemiesInRange.Count)];
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
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(weaponDamage);
                if (revolverWeapon.isRicochet)
                {
                    FindRandomEnemy();

                    isColliding = false;
                }
                //else Destroy(gameObject);
            }
            //else Destroy(gameObject);
        }
    }
}
