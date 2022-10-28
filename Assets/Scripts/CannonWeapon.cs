using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour
{
    private bool isShooting;
    private Player player;
    private PlayerUIController playerUIController;

    public float cannonAttackSpeed;
    public int cannonProjectileAmount = 1;
    public float cannonDamage = 1f;
    public bool isFireField;
    public bool isDoubleShot;

    public GameObject cannonProjectilePrefab;
    public GameObject playerDirectionPointer;
    public GameObject cannonSkillTree;

    void SetCannonWeapon()
    {
        GameObject weaponGameObject = Instantiate(cannonSkillTree, playerUIController.FreeWeaponSlot().transform);
        player.playerWeaponAmount++;
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();
        playerDirectionPointer = GameObject.Find("Player Direction Indicator");

        SetCannonWeapon();
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
            if(isDoubleShot) Instantiate(cannonProjectilePrefab, playerDirectionPointer.transform.position, playerDirectionPointer.transform.rotation * Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(cannonAttackSpeed - .3f);

        isShooting = false;
    }
}
