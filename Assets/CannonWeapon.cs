using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour
{
    private bool isShooting;
    private Player player;

    public float cannonAttackSpeed;
    public int cannonProjectileAmount = 1;
    public float cannonDamage = 1f;

    public GameObject cannonProjectilePrefab;
    public GameObject playerDirectionPointer;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerDirectionPointer = GameObject.Find("Player Direction Indicator");
    }

    void Update()
    {
        if(!isShooting) StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        isShooting = true;

        for (int i = 0; i < player.playerProjectileAmount + cannonProjectileAmount; i++)
        {
            Instantiate(cannonProjectilePrefab, playerDirectionPointer.transform.position, playerDirectionPointer.transform.rotation);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(cannonAttackSpeed - .3f);

        isShooting = false;
    }
}
