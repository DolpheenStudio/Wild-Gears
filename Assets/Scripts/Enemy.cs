using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    private float enemySpeed = 1f;
	public GameObject expPointPrefab;
	
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }
	
	public void DestroyEnemy()
	{
		for(int i = 0; i < Random.Range(3, 6); i++)
		{
			Instantiate(expPointPrefab, new Vector3(transform.position.x + (float) Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f), Quaternion.Euler(0f, 0f, 0f));
			Destroy(gameObject);
		}	
	}
}