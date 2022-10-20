using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Enemy enemy;
    public Slider enemyHealthBar;
    private bool isActive;

    void Start()
    {
        enemyHealthBar.maxValue = enemy.enemyHealth;
        enemyHealthBar.gameObject.SetActive(false);
    }

    void Update()
    {
        enemyHealthBar.value = enemy.enemyHealth;
        if(enemyHealthBar.value < enemyHealthBar.maxValue && !isActive)
        {
            enemyHealthBar.gameObject.SetActive(true);
        }
    }
}
