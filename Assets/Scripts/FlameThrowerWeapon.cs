using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerWeapon : MonoBehaviour
{
    public GameObject playerDirectionIndicator;
    private Player player;
    private PlayerUIController playerUIController;
    private bool isShooting;

    public int flameSize = 0;
    public float flameThrowerAttackSpeed;
    public float flameThrowerDamage = 0.5f;
    
    public GameObject flamePrefab;

    public bool isFlameCross;
    public bool isSetOnFire;

    void Start()
    {
        playerDirectionIndicator = GameObject.Find("Player Direction Indicator");
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();

        isShooting = false;
    }


    void Update()
    {
        if (!isShooting) StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        isShooting = true;

        GameObject flame = Instantiate(flamePrefab, playerDirectionIndicator.transform.position , playerDirectionIndicator.transform.rotation);
        flame.transform.localScale += new Vector3(0.5f * flameSize, 0.5f * flameSize, 0f);
        flame.transform.parent = playerDirectionIndicator.transform;

        if (isFlameCross)
        {
            for (int i = 1; i < 4; i++)
            {
                GameObject crossFlame = Instantiate(flamePrefab, playerDirectionIndicator.transform.position, playerDirectionIndicator.transform.rotation * Quaternion.Euler(0f, 0f, 90f * i));
                crossFlame.transform.localScale += new Vector3(0.5f * flameSize, 0.5f * flameSize, 0f);
                crossFlame.transform.parent = playerDirectionIndicator.transform;
            }
        }

        yield return new WaitForSeconds(flameThrowerAttackSpeed);

        isShooting = false;
    }
}
