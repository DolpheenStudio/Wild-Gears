using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    private Player player;
	private bool canShoot = true;
	private float playerShootCooldown;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
		playerShootCooldown = player.playerAttackSpeed;
    }
	
	void Update()
	{
		if(canShoot)
		{
			if(Vector3.Distance(player.transform.position, FindClosestEnemy().transform.position) <= player.playerRange)
			{
				Shoot();
				canShoot = false;
				playerShootCooldown = 0f;
			}
		}
		else 
		{
			if(playerShootCooldown < player.playerAttackSpeed)
			{
				playerShootCooldown += Time.deltaTime;
			}
			else 
			{
				canShoot = true;
			}
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
    void Shoot()
    {
		for(int i = 0; i < player.playerProjectileAmount; i++)
		{
			Instantiate(playerBulletPrefab, transform.position, transform.rotation);
			StartCoroutine(Waiter(1));
		}
    }
	
	IEnumerator Waiter(float time)
	{
		yield return new WaitForSeconds(time);
	}
}
