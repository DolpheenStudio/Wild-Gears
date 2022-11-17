using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBreak : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyBarrelAnimation());
    }

    private IEnumerator DestroyBarrelAnimation()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
