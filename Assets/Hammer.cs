using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private bool isColliding;
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
        isColliding = true;
        if(isColliding)
        {
            return;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DealDamageToEnemy(hammerWeapon.hammerDamage);
        }
    }
}
