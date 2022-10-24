using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWeapon : MonoBehaviour
{
    public float hammerAttackSpeed;
    public float hammerSpeed = 1f;
    public float hammerAmount = 1f;
    public float hammerDamage = 0.5f;
    public bool isInfinite;
    public bool isLongerHammer;

    private Player player;
    public GameObject hammerPrefab;
    public GameObject longerHammerPrefab;
    public GameObject hammerSkillTree;
    public PlayerUIController playerUIController;

    private bool isAttacking;
    private bool isRotating;

    void SetHammerWeapon()
    {
        GameObject weaponGameObject = Instantiate(hammerSkillTree, playerUIController.FreeWeaponSlot().transform);
        player.playerWeaponAmount++;
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();
        isAttacking = true;

        SetHammerWeapon();
    }

    void Update()
    {
        if(isAttacking)
        {
            StartCoroutine(InstantiateHammers());
        }
        if(isRotating)
        {
            transform.rotation *= Quaternion.Euler(0f, 0f, hammerSpeed * Time.deltaTime);
        }
        if (isInfinite) hammerAttackSpeed = .01f;
        if (isLongerHammer) hammerPrefab = longerHammerPrefab;
    }

    IEnumerator InstantiateHammers()
    {
        isAttacking = false;
        isRotating = true;
        float hammerRotationAngle = 360 / (hammerAmount + player.playerProjectileAmount);
        float hammerRotation = 0f;
        List<GameObject> hammerList = new List<GameObject>();
        for (int i = 0; i < hammerAmount + player.playerProjectileAmount; i++)
        {
            GameObject tempHammer = Instantiate(hammerPrefab, transform.position, Quaternion.Euler(0, 0, hammerRotation));
            hammerList.Add(tempHammer);
            tempHammer.transform.SetParent(transform);
            hammerRotation += hammerRotationAngle;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject hammer in hammerList)
        {
            Destroy(hammer);
        }
        yield return new WaitForSeconds(hammerAttackSpeed);
        isAttacking = true;
        isRotating = false;
    }
}

