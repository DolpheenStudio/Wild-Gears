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
	public bool isOnFire = false;

	public GameObject onFireAnimation;
	public GameObject damagePopupPrefab;
	
    void Start()
    {
		onFireAnimation.SetActive(false);
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
		if(enemyHealth <= 0f)
        {
			DestroyEnemy();
        }
		
		if(Vector3.Distance(transform.position, player.transform.position) <= 1f)
        {
			if (player.isDamagable) player.DealDamage(enemyDamage);
        }
    }

	public void SetOnFire(float damage)
    {
		StartCoroutine(SetOnFireCoroutine(damage));
    }

	public IEnumerator SetOnFireCoroutine(float damage)
    {
		onFireAnimation.SetActive(true);
		isOnFire = true;
		while (true)
		{
			Debug.Log("Fire");
			DealDamageToEnemy(damage, transform.position);
			yield return new WaitForSeconds(.5f);
			Debug.Log("End Fire");
		}
    }

	public void DealDamageToEnemy(float damage, Vector3 damagePosition)
    {
		enemyHealth -= damage;
		GameObject damagePopup = Instantiate(damagePopupPrefab, damagePosition, Quaternion.identity);
		damagePopup.GetComponent<DamagePopup>().SetDamageText(damage.ToString());
    }
	
	public void DestroyEnemy()
	{
		int expPointsAmount = Random.Range(4, 7);
		for(int i = 0; i < expPointsAmount; i++)
		{
			Instantiate(expPointPrefab, new Vector3(transform.position.x + (float) Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f), Quaternion.Euler(0f, 0f, 0f));
		}
		Destroy(gameObject);
	}
}
