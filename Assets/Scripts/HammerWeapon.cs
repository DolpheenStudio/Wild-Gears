using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWeapon : MonoBehaviour
{
    public float hammerAttackSpeed;
    public float hammerSpeed = 1f;
    public float hammerAmount = 1f;
    public float hammerDamage = 0.5f;

    private Player player;
    public GameObject hammerComponent;

    private bool isAttacking;
    private bool isRotating;

    void Start()
    {
        player = FindObjectOfType<Player>();
        isAttacking = true;
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
    }

    IEnumerator InstantiateHammers()
    {
        isAttacking = false;
        isRotating = true;
        float hammerRotationAngle = 360 / hammerAmount + player.playerProjectileAmount;
        float hammerRotation = 0f;
        List<GameObject> hammerList = new List<GameObject>();
        for (int i = 0; i < hammerAmount + player.playerProjectileAmount; i++)
        {
            GameObject tempHammer = Instantiate(hammerComponent, transform.position, Quaternion.Euler(0, 0, hammerRotation));
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

