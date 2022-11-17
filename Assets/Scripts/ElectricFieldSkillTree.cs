using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElectricFieldSkillTree : MonoBehaviour
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

    public Button addLifeStealButton;
    public Button addSlowButton;



    private Player player;
    public ElectricFieldWeapon electricFieldWeapon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        electricFieldWeapon = player.GetComponentInChildren<ElectricFieldWeapon>();
        addSizeButton.interactable = false;
        addSizeButton2.interactable = false;
        addLifeStealButton.interactable = false;
        addSlowButton.interactable = false;
        isAddSizeButton = false;
        isAddSizeButton2 = false;

        upgradeTierIndicator.value = 0;
    }

    public void AddAttackSpeed()
    {
        if (player.playerUpgradePoints >= 1)
        {
            electricFieldWeapon.electricFieldAttackSpeed -= 0.025f;
            attackSpeedUpgrades++;
            player.playerUpgradePoints--;
            ReloadUpgradeTierIndicator();
        }
    }

    public void AddDamage()
    {
        if (player.playerUpgradePoints >= 1)
        {
            electricFieldWeapon.electricFieldDamage += 5f;
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
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddSizeButton2) addLifeStealButton.interactable = true;
            if (attackSpeedUpgrades + damageUpgrades >= 20 && isAddSizeButton2) addSlowButton.interactable = true;
            attackSpeedUpgradeCounter.SetText(attackSpeedUpgrades.ToString());
            damageUpgradeCounter.SetText(damageUpgrades.ToString());
        }
    }

    public void AddSize()
    {
        electricFieldWeapon.electricFieldSize++;
        electricFieldWeapon.IncreaseElectricFieldSize();

        if (!isAddSizeButton)
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

    public void AddLifeSteal()
    {
        electricFieldWeapon.isLifeSteal = true;
        ReloadUpgradeTierIndicator();
        addLifeStealButton.interactable = false;
        addSlowButton.interactable = false;

        var buttonColor = addLifeStealButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addLifeStealButton.colors = buttonColor;
    }

    public void AddSlow()
    {
        electricFieldWeapon.isSlow = true;
        ReloadUpgradeTierIndicator();
        addSlowButton.interactable = false;
        addLifeStealButton.interactable = false;

        var buttonColor = addSlowButton.colors;
        buttonColor.disabledColor = Color.yellow;
        addSlowButton.colors = buttonColor;
    }
}