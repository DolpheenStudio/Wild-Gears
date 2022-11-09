using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlameThrowerSkillTree : MonoBehaviour
{
    public Button addAttackSpeedButton;
    public TMP_Text attackSpeedUpgradeCounter;
    private int attackSpeedUpgrades;

    public Button addDamageButton;
    public TMP_Text damageUpgradeCounter;
    private int damageUpgrades;

    public Slider upgradeTierIndicator;

    public Button addSizeButton;
    public bool isAddSizeButton = false;

    public Button addSizeButton2;
    public bool isAddSizeButton2 = false;

    public Button addFlameCrossButton;
    public Button addSetOnFireButton;



    private Player player;
    public FlameThrowerWeapon flameThrowerWeapon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        flameThrowerWeapon = player.GetComponentInChildren<FlameThrowerWeapon>();
        addSizeButton.interactable = false;
        addSizeButton2.interactable = false;
        addFlameCrossButton.interactable = false;
        addSetOnFireButton.interactable = false;
        isAddSizeButton = false;
        isAddSizeButton2 = false;

        upgradeTierIndicator.value = 0;
    }

    public void AddAttackSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            flameThrowerWeapon.flameThrowerAttackSpeed -= 0.05f;
            attackSpeedUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    public void AddDamage()
    {
        if (player.playerUpgradePoints >= 1)
        {
            flameThrowerWeapon.flameThrowerDamage += 2f;
            damageUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    void ReloadUpgradeTierIndicator()
    {
        if (attackSpeedUpgrades + damageUpgrades < 20)
        {
            upgradeTierIndicator.value = attackSpeedUpgrades + damageUpgrades;
            if (attackSpeedUpgrades + damageUpgrades >= 7 && !isAddSizeButton) addSizeButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 14 && isAddSizeButton && !isAddSizeButton2) addSizeButton2.interactable = true;
            if (attackSpeedUpgrades > 0) attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            if (damageUpgrades > 0) damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
        else
        {
            addAttackSpeedButton.interactable = false;
            addDamageButton.interactable = false;
            if (attackSpeedUpgrades + damageUpgrades >= 14 && isAddSizeButton && !isAddSizeButton2) addSizeButton2.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddSizeButton2) addFlameCrossButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddSizeButton2) addSetOnFireButton.interactable = true;
            attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
    }

    public void AddSize() 
    {
        flameThrowerWeapon.flameSize++;

        if(!isAddSizeButton)
        {
            addSizeButton.interactable = false;
            isAddSizeButton = true;
            var buttonColor = addSizeButton.colors;
            buttonColor.disabledColor = Color.yellow;
            addSizeButton.colors = buttonColor;
        }
        else
        {
            addSizeButton2.interactable = false;
            isAddSizeButton2 = true;
            var buttonColor = addSizeButton2.colors;
            buttonColor.disabledColor = Color.yellow;
            addSizeButton2.colors = buttonColor;
        }
        ReloadUpgradeTierIndicator();
    }

    public void AddFlameCross ()
    {
        flameThrowerWeapon.isFlameCross = true;
        ReloadUpgradeTierIndicator();
        addFlameCrossButton.interactable = false;
        addSetOnFireButton.interactable = false;

        var buttonColor = addFlameCrossButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addFlameCrossButton.colors = buttonColor;
    }

    public void AddSetOnFire()
    {
        flameThrowerWeapon.isSetOnFire = true;
        ReloadUpgradeTierIndicator();
        addFlameCrossButton.interactable = false;
        addSetOnFireButton.interactable = false;

        var buttonColor = addSetOnFireButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addSetOnFireButton.colors = buttonColor;
    }
}