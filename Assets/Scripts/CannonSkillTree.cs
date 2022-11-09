using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannonSkillTree : MonoBehaviour
{
    public Button addAttackSpeedButton;
    public TMP_Text attackSpeedUpgradeCounter;
    private int attackSpeedUpgrades;

    public Button addDamageButton;
    public TMP_Text damageUpgradeCounter;
    private int damageUpgrades;

    public Slider upgradeTierIndicator;

    public Button addProjectileButton;
    public bool isAddProjectileButton = false;

    public Button addProjectileButton2;
    public bool isAddProjectileButton2 = false;

    public Button addFireField;
    public Button addDoubleShot;

    private Player player;
    public CannonWeapon cannonWeapon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        cannonWeapon = player.GetComponentInChildren<CannonWeapon>();
        addProjectileButton.interactable = false;
        addProjectileButton2.interactable = false;
        addFireField.interactable = false;
        addDoubleShot.interactable = false;
        isAddProjectileButton = false;
        isAddProjectileButton2 = false;

        upgradeTierIndicator.value = 0;
    }

    public void AddAttackSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            cannonWeapon.cannonAttackSpeed -= 0.05f;
            attackSpeedUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    public void AddDamage()
    {
        if (player.playerUpgradePoints >= 1)
        {
            cannonWeapon.cannonDamage += 10f;
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
            if (attackSpeedUpgrades + damageUpgrades >= 7 && !isAddProjectileButton) addProjectileButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 14 && isAddProjectileButton && !isAddProjectileButton2) addProjectileButton2.interactable = true;
            if (attackSpeedUpgrades > 0) attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            if (damageUpgrades > 0) damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
        else
        {
            addAttackSpeedButton.interactable = false;
            addDamageButton.interactable = false;
            if (attackSpeedUpgrades + damageUpgrades >= 14 && isAddProjectileButton && !isAddProjectileButton2) addProjectileButton2.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addFireField.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addDoubleShot.interactable = true;
            attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
    }

    public void AddProjectile()
    {
        cannonWeapon.cannonProjectileAmount++;

        if (!isAddProjectileButton)
        {
            addProjectileButton.interactable = false;
            isAddProjectileButton = true;
            var buttonColor = addProjectileButton.colors;
            buttonColor.disabledColor = Color.yellow;
            addProjectileButton.colors = buttonColor;
        }
        else
        {
            addProjectileButton2.interactable = false;
            isAddProjectileButton2 = true;
            var buttonColor = addProjectileButton2.colors;
            buttonColor.disabledColor = Color.yellow;
            addProjectileButton2.colors = buttonColor;
        }
        ReloadUpgradeTierIndicator();
    }

    public void AddFireField()
    {
        cannonWeapon.isFireField = true;
        ReloadUpgradeTierIndicator();
        addFireField.interactable = false;
        addDoubleShot.interactable = false;

        var buttonColor = addFireField.colors;
        buttonColor.disabledColor = Color.yellow;
        addFireField.colors = buttonColor;
    }

    public void AddDoubleShot()
    {
        cannonWeapon.isDoubleShot = true;
        ReloadUpgradeTierIndicator();
        addDoubleShot.interactable = false;
        addFireField.interactable = false;

        var buttonColor = addDoubleShot.colors;
        buttonColor.disabledColor = Color.yellow;
        addDoubleShot.colors = buttonColor;
    }
}