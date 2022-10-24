using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    public float enemySpeed;
	public GameObject expPointPrefab;
	public float enemyHealth;
	public float enemyDamage;
	
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
		
		if(enemyHealth <= 0f)
        {
			DestroyEnemy();
        }
		
		if(Vector3.Distance(transform.position, player.transform.position) <= 1f)
        {
			if (player.isDamagable) player.DealDamage(enemyDamage);
        }
    }

	public void DealDamageToEnemy(float damage)
    {
		enemyHealth -= damage;
    }
	
	public void DestroyEnemy()
	{
		int expPointsAmount = Random.Range(5, 8);
		for(int i = 0; i < expPointsAmount; i++)
		{
			Instantiate(expPointPrefab, new Vector3(transform.position.x + (float) Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f), Quaternion.Euler(0f, 0f, 0f));
		}
		Destroy(gameObject);
	}
}
