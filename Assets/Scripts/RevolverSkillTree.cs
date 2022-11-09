using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RevolverSkillTree : MonoBehaviour
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

    public Button addRicochetButton;
    public Button addFastReloadButton;



    private Player player;
    public RevolverWeapon revolverWeapon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        revolverWeapon = player.GetComponentInChildren<RevolverWeapon>();
        addProjectileButton.interactable = false;
        addProjectileButton2.interactable = false;
        addRicochetButton.interactable = false;
        addFastReloadButton.interactable = false;
        isAddProjectileButton = false;
        isAddProjectileButton2 = false;

        upgradeTierIndicator.value = 0;
    }

    public void AddAttackSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            revolverWeapon.revolverAttackSpeed -= 0.05f;
            attackSpeedUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    public void AddDamage()
    {
        if (player.playerUpgradePoints >= 1)
        {
            revolverWeapon.revolverDamage += 10f;
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
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addRicochetButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addFastReloadButton.interactable = true;
            attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
    }

    public void AddProjectile() 
    {
        revolverWeapon.revolverProjectileAmount++;

        if(!isAddProjectileButton)
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

    public void AddRicochet()
    {
        revolverWeapon.isRicochet = true;
        ReloadUpgradeTierIndicator();
        addRicochetButton.interactable = false;
        addFastReloadButton.interactable = false;

        var buttonColor = addRicochetButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addRicochetButton.colors = buttonColor;
    }

    public void AddFastReload()
    {
        revolverWeapon.isFastReload = true;
        ReloadUpgradeTierIndicator();
        addRicochetButton.interactable = false;
        addFastReloadButton.interactable = false;

        var buttonColor = addFastReloadButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addFastReloadButton.colors = buttonColor;
    }
}