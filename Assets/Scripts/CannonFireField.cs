using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireField : MonoBehaviour
{
    private float damageCooldown = 1f;
    private float fireFieldDamage = 0.2f;

    private void Start()
    {
        StartCoroutine(destroyFireField());
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(damageCooldown <= 0f)
        {
            if(collision.transform.tag != "Player")
            {
                collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(fireFieldDamage);
            }
            damageCooldown = 1f;
        }
        else
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    IEnumerator destroyFireField()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
