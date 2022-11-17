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

    public GameObject[] targetsArray;
    public List<GameObject> targetsList = new List<GameObject>();

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
        targetsArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject target in targetsArray)
        {
            targetsList.Add(target);
        }
        targetsArray = GameObject.FindGameObjectsWithTag("PickUps");
        foreach (GameObject target in targetsArray)
        {
            targetsList.Add(target);
        }

        GameObject tempTarget = null;

        float distance = Mathf.Infinity;
        foreach (GameObject target in targetsList)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, target.transform.position);
                tempTarget = target;
            }
        }
        targetEnemy = tempTarget;
    }

    void FindClosestEnemy(GameObject lastTarget)
    {
        targetsArray = GameObject.FindGameObjectsWithTag("Enemy");
        targetsList.Clear();
        foreach (GameObject targets in targetsArray)
        {
            targetsList.Add(targets);
        }

        targetsArray = GameObject.FindGameObjectsWithTag("PickUps");
        foreach (GameObject target in targetsArray)
        {
            targetsList.Add(target);
        }

        targetsList.Remove(lastTarget);
        GameObject tempEnemy = null;

        float distance = Mathf.Infinity;
        foreach (GameObject target in targetsList)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, target.transform.position);
                tempEnemy = target;
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
            if(targetEnemy != null && collision.gameObject.tag == "Enemy") collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(revolverWeapon.revolverDamage, transform.position);
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
