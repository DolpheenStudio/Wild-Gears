using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireField : MonoBehaviour
{
    private float damageCooldown = 0.5f;
    private float fireFieldDamage = 0.1f;

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
            damageCooldown = 0.5f;
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
