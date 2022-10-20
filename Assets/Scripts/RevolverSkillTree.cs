using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverSkillTree : MonoBehaviour
{
    public Button[] revolverSkillTreeButtons = new Button[10];

    private Player player;
    public RevolverWeapon revolverWeapon;

    private int upgradeTier = 0;

    void Start()
    {
        player = FindObjectOfType<Player>();
        revolverWeapon = player.GetComponentInChildren<RevolverWeapon>();
    }

    public void Add10AS()
    {
        if (player.playerUpgradePoints >= 1)
        {
            player.playerUpgradePoints -= 1;
            revolverWeapon.revolverAttackSpeed *= 0.9f;
            revolverSkillTreeButtons[1].interactable = false;
            revolverSkillTreeButtons[0].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[0].colors = cb;

            upgradeTier++;
        }
    }

    public void Add10DMG()
    {
        if (player.playerUpgradePoints >= 1)
        {
            player.playerUpgradePoints -= 1;
            revolverWeapon.revolverDamage *= 1.1f;
            revolverSkillTreeButtons[0].interactable = false;
            revolverSkillTreeButtons[1].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[1].colors = cb;

            upgradeTier++;
        }
    }

    public void Add1PRO()
    {
        if (player.playerUpgradePoints >= 2 && upgradeTier >= 1)
        {
            player.playerUpgradePoints -= 2;
            revolverWeapon.revolverAdditionalProjectileAmount++;
            revolverSkillTreeButtons[2].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[2].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[2].colors = cb;

            upgradeTier++;
        }
    }

    public void Add15AS()
    {
        if (player.playerUpgradePoints >= 3 && upgradeTier >= 2)
        {
            player.playerUpgradePoints -= 3;
            revolverWeapon.revolverAttackSpeed *= 0.85f;
            revolverSkillTreeButtons[4].interactable = false;
            revolverSkillTreeButtons[3].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[3].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[3].colors = cb;

            upgradeTier++;
        }
    }

    public void Add15DMG()
    {
        if (player.playerUpgradePoints >= 3 && upgradeTier >= 2)
        {
            player.playerUpgradePoints -= 3;
            revolverWeapon.revolverDamage *= 0.85f;
            revolverSkillTreeButtons[3].interactable = false;
            revolverSkillTreeButtons[4].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[4].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[4].colors = cb;

            upgradeTier++;
        }
    }

    public void Add1PRO2()
    {
        if (player.playerUpgradePoints >= 4 && upgradeTier >= 3)
        {
            player.playerUpgradePoints -= 3;
            revolverWeapon.revolverAdditionalProjectileAmount++;
            revolverSkillTreeButtons[5].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[5].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[5].colors = cb;

            upgradeTier++;
        }
    }

    public void Add20AS()
    {
        if (player.playerUpgradePoints >= 5 && upgradeTier >= 4)
        {
            player.playerUpgradePoints -= 5;
            revolverWeapon.revolverAttackSpeed *= 0.80f;
            revolverSkillTreeButtons[7].interactable = false;
            revolverSkillTreeButtons[6].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[6].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[6].colors = cb;

            upgradeTier++;
        }
    }

    public void Add20DMG()
    {
        if (player.playerUpgradePoints >= 5 && upgradeTier >= 4)
        {
            player.playerUpgradePoints -= 5;
            revolverWeapon.revolverDamage *= 0.80f;
            revolverSkillTreeButtons[6].interactable = false;
            revolverSkillTreeButtons[7].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[7].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[7].colors = cb;

            upgradeTier++;
        }
    }

    public void AddRicochet()
    {
        if (player.playerUpgradePoints >= 6 && upgradeTier >= 5)
        {
            player.playerUpgradePoints -= 6;
            revolverWeapon.isRicochet = true;
            revolverSkillTreeButtons[9].interactable = false;
            revolverSkillTreeButtons[8].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[8].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[9].colors = cb;

            upgradeTier++;
        }
    }

    public void AddFastReload()
    {
        if (player.playerUpgradePoints >= 6 && upgradeTier >= 5)
        {
            player.playerUpgradePoints -= 6;
            revolverWeapon.revolverAttackSpeed = 1.5f;
            revolverSkillTreeButtons[8].interactable = false;
            revolverSkillTreeButtons[9].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[9].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[9].colors = cb;

            upgradeTier++;
        }
    }
}