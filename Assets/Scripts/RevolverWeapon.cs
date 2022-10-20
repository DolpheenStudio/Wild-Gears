using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon : MonoBehaviour
{
    public GameObject revolverProjectilePrefab;
	public GameObject revolverSkillTree;

	private Player player;
	private bool canShoot;
	private float playerShootCooldown;
	private PlayerUIController playerUIController;

	void SetRevolverWeapon()
    {
		GameObject weaponGameObject = Instantiate(revolverSkillTree, playerUIController.FreeWeaponSlot().transform);
		player.playerWeaponAmount++;
	}
    
    void Start()
    {
        player = FindObjectOfType<Player>();
		playerUIController = FindObjectOfType<PlayerUIController>();

		playerShootCooldown = player.playerAttackSpeed;
		SetRevolverWeapon();
    }
	
	void Update()
	{
		if(canShoot)
		{
			if(Vector3.Distance(player.transform.position, FindClosestEnemy().transform.position) <= player.playerRange)
			{
				canShoot = false;
				StartCoroutine(Shoot());
				playerShootCooldown = 0f;
			}
		}
		else
		{
			if(playerShootCooldown <= player.playerAttackSpeed)
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
    IEnumerator Shoot()
    {
		for (int i = 0; i < player.playerProjectileAmount; i++)
		{
			Instantiate(revolverProjectilePrefab, transform.position, transform.rotation);
			Debug.Log("Shoot");
			yield return new WaitForSeconds(.5f);
		}
	}
}
