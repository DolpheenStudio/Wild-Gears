using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TMP_Text damageText;

    void Start()
    {
        StartCoroutine(DestroyDamagePopup());
    }

    void Update()
    {
        transform.position += new Vector3(1f, 2f, 0f) * Time.deltaTime;
    }

    public void SetDamageText(string damage)
    {
        damageText.text = damage;
    }

    private IEnumerator DestroyDamagePopup()
    {
        yield return new WaitForSeconds(.7f);

        Destroy(gameObject);
    }
}
