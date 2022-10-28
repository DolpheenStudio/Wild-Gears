using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public float cannonBulletSpeed = 10f;
    public GameObject cannonBulletExplosion;

    private bool isColliding;

    private void Start()
    {
        isColliding = false;
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * cannonBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding)
        {
            return;
        }
        if (collision.gameObject.tag != "Player")
        {
            isColliding = true;
            Instantiate(cannonBulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
