using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon : MonoBehaviour
{
    public GameObject revolverProjectilePrefab;
	public GameObject revolverSkillTree;

	private Player player;
	private bool isEnemyInRange;
	private bool isShooting;
	
	public bool isRicochet = false;
	public bool isFastReload = false;
	public float revolverAttackSpeed = 1f;
	public float revolverRange = 5f;
	public float revolverDamage = 1f;
	public int revolverAdditionalProjectileAmount = 0;

	void SetRevolverWeapon()
    {
		//GameObject weaponGameObject = Instantiate(revolverSkillTree, playerUIController.FreeWeaponSlot().transform);
		player.playerWeaponAmount++;
	}
    
    void Start()
    {
        player = FindObjectOfType<Player>();

		SetRevolverWeapon();
    }
	
	void Update()
	{
		isEnemyInRange = Vector3.Distance(player.transform.position, FindClosestEnemy().transform.position) <= revolverRange;
		if (isEnemyInRange && !isShooting)
		{
			StartCoroutine(Shoot());
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
		isShooting = true;
		if(!isFastReload)
        {
			for (int i = 0; i < player.playerProjectileAmount + revolverAdditionalProjectileAmount; i++)
			{
				if (!isEnemyInRange) break;
				Instantiate(revolverProjectilePrefab, transform.position, transform.rotation);
				yield return new WaitForSeconds(.3f);
			}
			yield return new WaitForSeconds(revolverAttackSpeed - .3f);
		}
		else
        {
			while(isEnemyInRange)
            {
				if (!isEnemyInRange) break;
				Instantiate(revolverProjectilePrefab, transform.position, transform.rotation);
				yield return new WaitForSeconds(.3f);
			}
        }
		isShooting = false;
	}
}
