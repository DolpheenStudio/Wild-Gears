using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFieldWeapon : MonoBehaviour
{
    public int electricFieldSize = 0;
    public float electricFieldDamage;
    public float electricFieldAttackSpeed = 1f;
    public bool isLifeSteal;
    public bool isSlow;

    private float damageCooldown;
    private int electricFieldSizeOld;
    private PlayerUIController playerUIController;
    private Player player;

    private List<GameObject> enemyInRangeList = new List<GameObject>();

    public GameObject electricFieldSkillTree;

    private void SetElectricField()
    {
        GameObject weaponGameObject = Instantiate(electricFieldSkillTree, playerUIController.FreeWeaponSlot().transform);

        player.playerWeaponAmount++;
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();

        damageCooldown = electricFieldAttackSpeed;
        electricFieldSizeOld = electricFieldSize;

        SetElectricField();
    }

    void Update()
    {
        if(damageCooldown >= 0f)
        {
            damageCooldown -= Time.deltaTime;
        }
        else if (enemyInRangeList.Count > 0)
        {
            foreach (GameObject enemy in enemyInRangeList)
            {
                enemy.GetComponent<Enemy>().DealDamageToEnemy(electricFieldDamage, enemy.transform.position);
                if (isLifeSteal)
                {
                    player.HealPlayer(electricFieldDamage * 0.001f);
                }
            }
            damageCooldown = electricFieldAttackSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            enemyInRangeList.Add(collision.gameObject);
            if (isSlow)
            {
                collision.gameObject.GetComponent<Enemy>().enemySpeed *= 0.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.transform.tag == "Enemy")
        {
            enemyInRangeList.Remove(collision.gameObject);
            if (isSlow)
            {
                collision.gameObject.GetComponent<Enemy>().enemySpeed *= 2f;
            }
        }
    }

    public void IncreaseElectricFieldSize()
    {
        transform.localScale = new Vector3(1 + 0.5f * electricFieldSize, 1 + 0.5f * electricFieldSize, 0f);
    }
}
