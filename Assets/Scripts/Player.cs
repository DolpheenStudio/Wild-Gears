using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 3f;
    public float playerAttackSpeed = 2f;
	public float playerPickupRange = 2f;
	public float playerRange = 5f;
	public int playerProjectileAmount = 1;
	public int playerLevel = 1;
    public int playerExp = 0;
    public int playerMaxExp = 100;
    public int playerUpgradePoints = 0;
    public int playerWeaponAmount = 0;

    public GameObject revolverWeaponPrefab;

    void Start()
    {
        SetPlayerWeapon(revolverWeaponPrefab);
    }

    void Update()
    {
        if(playerExp >= playerMaxExp)
        {
            LevelUp();
            playerUpgradePoints++;
        }
    }

    private void LevelUp()
    {
        playerExp = 0;
        playerLevel++;
        playerMaxExp += 50;

        Time.timeScale = 0;
    }

    public void SetPlayerWeapon(GameObject playerWeapon)
    {
        if(playerWeaponAmount < 3)
        {
            GameObject weaponGameObject = Instantiate(playerWeapon, transform.position, transform.rotation);
            weaponGameObject.transform.SetParent(transform, true);
        }
    }
}
