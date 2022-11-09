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
                    player.HealPlayer(electricFieldDamage * 0.01f);
                }
            }
            damageCooldown = electricFieldAttackSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSlow)
        {
            collision.gameObject.GetComponent<Enemy>().enemySpeed *= 0.5f;
        }
        if(collision.transform.tag != "Player")
        {
            enemyInRangeList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isSlow)
        {
            collision.gameObject.GetComponent<Enemy>().enemySpeed *= 2f;
        }
        if (collision.transform.tag != "Player")
        {
            enemyInRangeList.Remove(collision.gameObject);
        }
    }

    public void IncreaseElectricFieldSize()
    {
        transform.localScale = new Vector3(1 + 0.5f * electricFieldSize, 1 + 0.5f * electricFieldSize, 0f);
    }
}
