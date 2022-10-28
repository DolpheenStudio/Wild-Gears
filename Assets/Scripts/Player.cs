using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
	public float playerPickupRange;
	public int playerProjectileAmount;
	public int playerLevel;
    public int playerExp = 0;
    public int playerMaxExp;
    public int playerUpgradePoints = 0;
    public int playerWeaponAmount = 0;
    public float playerHealth;
    public float playerMaxHealth;

    public bool isDamagable = true;

    private float playerDamageCooldown = 0.2f;

    public GameObject revolverWeaponPrefab;
    public GameObject hammerWeaponPrefab;
    public WeaponPick weaponPick;

    void Awake()
    {
        playerMaxHealth = playerHealth;
    }

    private void Start()
    {
        weaponPick.PickWeapon();
    }

    void Update()
    {
        if(playerExp >= playerMaxExp)
        {
            LevelUp();
        }

        if(playerDamageCooldown >= 0f)
        {
            playerDamageCooldown -= Time.deltaTime;
        }
        else
        {
            isDamagable = true;
        }

        if(playerHealth <= 0f)
        {
            PlayerDeath();
        }
    }

    private void LevelUp()
    {
        playerExp -= playerMaxExp;
        playerLevel++;
        playerUpgradePoints++;
        playerMaxExp += 5;

        if (playerLevel == 10 || playerLevel == 20)
        {
            weaponPick.PickWeapon();
        }
    }

    public void SetPlayerWeapon(GameObject playerWeapon)
    {
        if(playerWeaponAmount < 3)
        {
            GameObject weaponGameObject = Instantiate(playerWeapon, transform.position, transform.rotation);
            weaponGameObject.transform.SetParent(transform, true);
        }
    }

    public void DealDamage(float damage)
    {
        if(isDamagable)
        {
            playerHealth -= damage;
            playerDamageCooldown = 0.2f;
            isDamagable = false;
        }
    }

    void PlayerDeath()
    {
        SceneManager.LoadScene(1);
    }
}
