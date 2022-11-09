using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject flameCollider;
    public FlameThrowerWeapon flameThrowerWeapon;

    private float damageCooldown = 0.3f;
    private List<GameObject> enemyInRangeList = new List<GameObject>();

    void Start()
    {
        flameThrowerWeapon = FindObjectOfType<FlameThrowerWeapon>();
        StartCoroutine(DestroyFlame());
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
                enemy.GetComponent<Enemy>().DealDamageToEnemy(flameThrowerWeapon.flameThrowerDamage, enemy.transform.position);
            }
            damageCooldown = 0.3f;
        }
    }

    IEnumerator DestroyFlame()
    {
        for(int i = 0; i < 5; i++)
        {
            flameCollider.GetComponent<BoxCollider2D>().size += new Vector2(0.4f, 0.4f);
            flameCollider.GetComponent<Collider2D>().offset += new Vector2(0f, 0.20f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            enemyInRangeList.Add(collision.gameObject);
            if (flameThrowerWeapon.isSetOnFire)
            {
                if(!collision.gameObject.GetComponent<Enemy>().isOnFire) collision.gameObject.GetComponent<Enemy>().SetOnFire(0.1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            enemyInRangeList.Remove(collision.gameObject);
        }
    }
}
