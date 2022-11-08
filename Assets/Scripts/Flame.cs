using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject flameCollider;
    public FlameThrowerWeapon flameThrowerWeapon;

    private float damageCooldown = 0.3f;

    void Start()
    {
        flameThrowerWeapon = FindObjectOfType<FlameThrowerWeapon>();
        StartCoroutine(DestroyFlame());
    }

    void Update()
    {
        Debug.Log(Time.time);
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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (damageCooldown <= 0f)
        {
            if (collision.transform.tag != "Player")
            {
                collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(flameThrowerWeapon.flameThrowerDamage);
            }
            damageCooldown = 0.3f;
        }
        else
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (flameThrowerWeapon.isSetOnFire)
        {
            if (collision.transform.tag != "Player")
            {
                if(!collision.gameObject.GetComponent<Enemy>().isOnFire) StartCoroutine(collision.gameObject.GetComponent<Enemy>().SetOnFire(0.1f));
            }
        }
    }
}
