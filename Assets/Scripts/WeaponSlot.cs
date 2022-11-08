using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    public GameObject weaponSlot;
    private Player player;
    private PlayerUIController playerUIController;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerUIController = FindObjectOfType<PlayerUIController>();
    }

    public void ChooseWeapon()
    {
        if (weaponSlot != null)
        {
            player.SetPlayerWeapon(weaponSlot);
            WeaponPick weaponPick = gameObject.transform.parent.parent.GetComponent<WeaponPick>();
            int weaponIndex = weaponPick.weaponList.IndexOf(weaponSlot);
            weaponPick.weaponList.Remove(weaponPick.weaponList[weaponIndex]);
            weaponPick.weaponIconList.Remove(weaponPick.weaponIconList[weaponIndex]);
        }

        playerUIController.DisablePickWeaponScreen();
        playerUIController.EnablePlayerUI();
        Time.timeScale = 1;
    }
}
