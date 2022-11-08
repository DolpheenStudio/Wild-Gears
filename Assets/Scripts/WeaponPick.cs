using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPick : MonoBehaviour
{
    private Player player;
    public PlayerUIController playerUIController;
    public List<GameObject> weaponList = new List<GameObject>();
    public List<Sprite> weaponIconList = new List<Sprite>();
    public GameObject[] weaponButtons = new GameObject[3];
    public Sprite noWeaponAvailable;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void PickWeapon()
    {
        Time.timeScale = 0;
        playerUIController.EnablePickWeaponScreen();
        playerUIController.DisablePlayerUI();

        if (weaponList.Count == 0)
        {
            for(int i = 0; i < 3; i++)
            {
                weaponButtons[i].GetComponent<WeaponSlot>().weaponSlot = null;
                weaponButtons[i].GetComponent<Image>().sprite = noWeaponAvailable;
            }
        }

        else if(weaponList.Count == 1)
        {
            weaponButtons[0].GetComponent<WeaponSlot>().weaponSlot = weaponList[0];
            weaponButtons[0].GetComponent<Image>().sprite = weaponIconList[0];

            weaponButtons[1].GetComponent<WeaponSlot>().weaponSlot = null;
            weaponButtons[1].GetComponent<Image>().sprite = noWeaponAvailable;

            weaponButtons[2].GetComponent<WeaponSlot>().weaponSlot = null;
            weaponButtons[2].GetComponent<Image>().sprite = noWeaponAvailable;

        }

        else if(weaponList.Count == 2)
        {
            int randomWeapon = Random.Range(0, 2);
            weaponButtons[0].GetComponent<WeaponSlot>().weaponSlot = weaponList[randomWeapon];
            weaponButtons[0].GetComponent<Image>().sprite = weaponIconList[randomWeapon];

            if(randomWeapon == 0)
            {
                weaponButtons[1].GetComponent<WeaponSlot>().weaponSlot = weaponList[1];
                weaponButtons[1].GetComponent<Image>().sprite = weaponIconList[1];
            }
            else
            {
                weaponButtons[1].GetComponent<WeaponSlot>().weaponSlot = weaponList[0];
                weaponButtons[1].GetComponent<Image>().sprite = weaponIconList[0];
            }

            weaponButtons[2].GetComponent<WeaponSlot>().weaponSlot = null;
            weaponButtons[2].GetComponent<Image>().sprite = noWeaponAvailable;
        }
        else
        {
            //First Weapon Slot
            int randomWeapon = Random.Range(0, weaponList.Count);
            weaponButtons[0].GetComponent<WeaponSlot>().weaponSlot = weaponList[randomWeapon];
            weaponButtons[0].GetComponent<Image>().sprite = weaponIconList[randomWeapon];

            //Second Weapon Slot
            int secondRandomWeapon = randomWeapon;

            while(secondRandomWeapon == randomWeapon)
            {
                secondRandomWeapon = Random.Range(0, weaponList.Count);
            }

            weaponButtons[1].GetComponent<WeaponSlot>().weaponSlot = weaponList[secondRandomWeapon];
            weaponButtons[1].GetComponent<Image>().sprite = weaponIconList[secondRandomWeapon];

            //Third Weapon Slot
            int thirdRandomWeapon = secondRandomWeapon;

            while(thirdRandomWeapon == secondRandomWeapon || thirdRandomWeapon == randomWeapon)
            {
                thirdRandomWeapon = Random.Range(0, weaponList.Count);
            }

            weaponButtons[2].GetComponent<WeaponSlot>().weaponSlot = weaponList[thirdRandomWeapon];
            weaponButtons[2].GetComponent<Image>().sprite = weaponIconList[thirdRandomWeapon];
        }
    }
}
