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
	
	public bool isRicochet = false;
	public float revolverAttackSpeed = 1f;
	public float revolverRange = 5f;
	public float revolverDamage = 1f;
	public float revolverAdditionalProjectileAmount = 0f;

	void SetRevolverWeapon()
    {
		//GameObject weaponGameObject = Instantiate(revolverSkillTree, playerUIController.FreeWeaponSlot().transform);
		player.playerWeaponAmount++;
	}
    
    void Start()
    {
        player = FindObjectOfType<Player>();
		playerUIController = FindObjectOfType<PlayerUIController>();

		playerShootCooldown = revolverAttackSpeed;
		SetRevolverWeapon();
    }
	
	void Update()
	{
		if(canShoot)
		{
			if(Vector3.Distance(player.transform.position, FindClosestEnemy().transform.position) <= revolverRange)
			{
				canShoot = false;
				StartCoroutine(Shoot());
				playerShootCooldown = 0f;
			}
		}
		else
		{
			if(playerShootCooldown <= revolverAttackSpeed)
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
		for (int i = 0; i < player.playerProjectileAmount + revolverAdditionalProjectileAmount; i++)
		{
			Instantiate(revolverProjectilePrefab, transform.position, transform.rotation);
			yield return new WaitForSeconds(.3f);
		}
	}
}
