using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float weaponDamage;
    private HammerWeapon hammerWeapon;

    void Start()
    {
        hammerWeapon = GetComponentInParent<HammerWeapon>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(hammerWeapon.hammerDamage, collision.transform.position);
        }
    }
}
