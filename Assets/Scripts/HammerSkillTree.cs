using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HammerSkillTree : MonoBehaviour
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

    public Button addInfiniteButton;
    public Button addLongerHammerButton;



    private Player player;
    public HammerWeapon hammerWeapon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        hammerWeapon = player.GetComponentInChildren<HammerWeapon>();
        addProjectileButton.interactable = false;
        addProjectileButton2.interactable = false;
        addInfiniteButton.interactable = false;
        addLongerHammerButton.interactable = false;
        isAddProjectileButton = false;
        isAddProjectileButton2 = false;

        upgradeTierIndicator.value = 0;
    }

    public void AddAttackSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            hammerWeapon.hammerAttackSpeed -= 0.05f;
            attackSpeedUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    public void AddDamage()
    {
        if (player.playerUpgradePoints >= 1)
        {
            hammerWeapon.hammerDamage += 0.1f;
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
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addInfiniteButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddProjectileButton2) addLongerHammerButton.interactable = true;
            attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
    }

    public void AddProjectile() 
    {
        hammerWeapon.hammerAmount++;

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

    public void AddInfinite()
    {
        hammerWeapon.isInfinite = true;
        ReloadUpgradeTierIndicator();
        addInfiniteButton.interactable = false;
        addLongerHammerButton.interactable = false;

        var buttonColor = addInfiniteButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addInfiniteButton.colors = buttonColor;
    }

    public void AddLongerHammer()
    {
        hammerWeapon.isLongerHammer = true;
        ReloadUpgradeTierIndicator();
        addInfiniteButton.interactable = false;
        addLongerHammerButton.interactable = false;

        var buttonColor = addLongerHammerButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addLongerHammerButton.colors = buttonColor;
    }
}