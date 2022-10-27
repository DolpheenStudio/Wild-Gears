using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    private GameObject targetEnemy;
    public RevolverWeapon revolverWeapon;
    public float ricochetRange;
    private bool isColliding;
    private bool canRicochet;
    private float revolverBulletSpeed = 8f;

    public GameObject[] enemiesArray;
    public List<GameObject> enemiesList = new List<GameObject>();

    void Start()
    {
        revolverWeapon = FindObjectOfType<RevolverWeapon>();

        FindClosestEnemy();
        
        isColliding = false;

        ricochetRange = revolverWeapon.revolverRange;
        if (revolverWeapon.isRicochet) canRicochet = true;
    }

    void Update()
    {
        if (targetEnemy == null) 
		{
			transform.position += transform.forward * Time.deltaTime * revolverBulletSpeed;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, revolverBulletSpeed * Time.deltaTime);
            transform.LookAt(new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y, 0f));
        }
    }

    void FindClosestEnemy()
    {
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemiesArray)
        {
            enemiesList.Add(enemy);
        }

        GameObject tempEnemy = null;

        float distance = Mathf.Infinity;
        foreach (GameObject enemy in enemiesList)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                tempEnemy = enemy;
            }
        }
        targetEnemy = tempEnemy;
    }

    void FindClosestEnemy(GameObject lastEnemy)
    {
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesList.Clear();
        foreach (GameObject enemy in enemiesArray)
        {
            enemiesList.Add(enemy);
        }

        enemiesList.Remove(lastEnemy);
        GameObject tempEnemy = null;

        float distance = Mathf.Infinity;
        foreach (GameObject enemy in enemiesList)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                tempEnemy = enemy;
            }
        }
        targetEnemy = tempEnemy;
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
            if(targetEnemy != null && collision.gameObject.tag == "Enemy") collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(revolverWeapon.revolverDamage);
            if (canRicochet)
            {
                FindClosestEnemy(collision.gameObject);
                if (Vector3.Distance(transform.position, targetEnemy.transform.position) > ricochetRange) Destroy(gameObject);
                isColliding = false;
                canRicochet = false;
            }
            else Destroy(gameObject);
        }
    }
}
