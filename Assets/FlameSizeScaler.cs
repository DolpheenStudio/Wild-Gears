using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSizeScaler : MonoBehaviour
{
    private FlameThrowerWeapon flameThrowerWeapon;
    public GameObject flameSprite;
    public GameObject flameCollider;

    void Start()
    {
        flameThrowerWeapon = FindObjectOfType<FlameThrowerWeapon>();

        if(flameThrowerWeapon.flameSize == 1)
        {
            flameSprite.transform.localPosition -= new Vector3(0f, .35f, 0f);
            flameCollider.transform.localPosition -= new Vector3(0f, .35f, 0f);
        }

        if (flameThrowerWeapon.flameSize == 2)
        {
            flameSprite.transform.localPosition -= new Vector3(0f, .5f, 0f);
            flameCollider.transform.localPosition -= new Vector3(0f, .5f, 0f);
        }
    }
}
