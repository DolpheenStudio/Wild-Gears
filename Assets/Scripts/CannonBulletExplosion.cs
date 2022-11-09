using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletExplosion : MonoBehaviour
{
    private CannonWeapon cannonWeapon;
    private Collider2D explosionCollider;
    private bool isColliding = false;

    public GameObject cannonFireFieldPrefab;

    private void Start()
    {
        cannonWeapon = FindObjectOfType<CannonWeapon>();
        explosionCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isColliding)
        {
            return;
        }
        if(collision.transform.tag != "Player")
        {
            isColliding = true;
            if(collision.gameObject != null) collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(cannonWeapon.cannonDamage, transform.position);
            explosionCollider.enabled = false;
            StartCoroutine(Explode());
            if (cannonWeapon.isFireField) Instantiate(cannonFireFieldPrefab, transform.position, transform.rotation);
        }
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
