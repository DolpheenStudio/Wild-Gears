using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletExplosion : MonoBehaviour
{
    private CannonWeapon cannonWeapon;
    private Collider2D explosionCollider;
    private void Start()
    {
        cannonWeapon = FindObjectOfType<CannonWeapon>();
        explosionCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag != "Player")
        {
            collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(cannonWeapon.cannonDamage);
            explosionCollider.enabled = false;
            StartCoroutine(Explode());
        }
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
