using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon : MonoBehaviour
{
    public GameObject revolverProjectilePrefab;
	public GameObject revolverSkillTree;
	public PlayerUIController playerUIController;

	private Player player;
	private bool isEnemyInRange;
	private bool isShooting;
	
	public bool isRicochet = false;
	public bool isFastReload = false;
	public float revolverAttackSpeed = 1f;
	public float revolverRange = 5f;
	public float revolverDamage = 1f;
	public int revolverProjectileAmount = 0;

	void SetRevolverWeapon()
    {
		GameObject weaponGameObject = Instantiate(revolverSkillTree, playerUIController.FreeWeaponSlot().transform);
		player.playerWeaponAmount++;
	}
    
    void Start()
    {
        player = FindObjectOfType<Player>();
		playerUIController = FindObjectOfType<PlayerUIController>();

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
		GameObject[] barrels = GameObject.FindGameObjectsWithTag("PickUps");
		GameObject[] targetableGameObjects = new GameObject[enemies.Length + barrels.Length];
		enemies.CopyTo(targetableGameObjects, 0);
		barrels.CopyTo(targetableGameObjects, enemies.Length);
        GameObject closestTarget = null;

        float distance = Mathf.Infinity;
        foreach (GameObject target in targetableGameObjects)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, target.transform.position);
				closestTarget = target;
            }
        }
        return closestTarget;
    }

    IEnumerator Shoot()
    {
		isShooting = true;
		if(!isFastReload)
        {
			for (int i = 0; i < player.playerProjectileAmount + revolverProjectileAmount; i++)
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
