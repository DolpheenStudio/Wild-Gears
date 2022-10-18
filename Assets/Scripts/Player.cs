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

    public GameObject revolverWeaponPrefab;

    void Start()
    {
        SetPlayerWeapon();
    }

    void Update()
    {
        if(playerExp >= playerMaxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerExp = 0;
        playerLevel++;
        playerMaxExp += 50;

        Time.timeScale = 0;
    }

    public void SetPlayerWeapon()
    {
        GameObject revolverWeapon = Instantiate(revolverWeaponPrefab, transform.position, transform.rotation);
        revolverWeapon.transform.SetParent(transform, true);
    }
}
