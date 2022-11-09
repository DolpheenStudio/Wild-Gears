using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireField : MonoBehaviour
{
    private float damageCooldown = 0.5f;
    private float fireFieldDamage = 10f;
    private List<GameObject> enemyInRangeList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(DestroyFireField());
    }

    void Update()
    {
        if (damageCooldown >= 0f)
        {
            damageCooldown -= Time.deltaTime;
        }
        else if (enemyInRangeList.Count > 0)
        {
            foreach (GameObject enemy in enemyInRangeList)
            {
                enemy.GetComponent<Enemy>().DealDamageToEnemy(fireFieldDamage, enemy.transform.position);
            }
            damageCooldown = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            enemyInRangeList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            enemyInRangeList.Remove(collision.gameObject);
        }
    }

    IEnumerator DestroyFireField()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
