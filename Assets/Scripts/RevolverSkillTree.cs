using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverSkillTree : MonoBehaviour
{
    public Button[] revolverSkillTreeButtons = new Button[10];

    private Player player;
    public RevolverWeapon revolverWeapon;

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

            Time.timeScale = 1;
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

            Time.timeScale = 1;
        }
    }

    public void Add1PRO()
    {
        if (player.playerUpgradePoints >= 2)
        {
            player.playerUpgradePoints -= 2;
            revolverWeapon.revolverAdditionalProjectileAmount++;
            revolverSkillTreeButtons[0].interactable = false;
            revolverSkillTreeButtons[1].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[1].colors = cb;

            Time.timeScale = 1;
        }
    }

    public void Add15AS()
    {
        if (player.playerUpgradePoints >= 3)
        {
            player.playerUpgradePoints -= 3;
            revolverWeapon.revolverAttackSpeed *= 0.85f;
            revolverSkillTreeButtons[1].interactable = false;
            revolverSkillTreeButtons[0].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[0].colors = cb;

            Time.timeScale = 1;
        }
    }

    public void Add15DMG()
    {
        if (player.playerUpgradePoints >= 3)
        {
            player.playerUpgradePoints -= 3;
            revolverWeapon.revolverDamage *= 0.85f;
            revolverSkillTreeButtons[0].interactable = false;
            revolverSkillTreeButtons[1].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[1].colors = cb;

            Time.timeScale = 1;
        }
    }

    public void AddRicochet()
    {
        if (player.playerUpgradePoints >= 6)
        {
            player.playerUpgradePoints -= 6;
            revolverWeapon.revolverDamage *= 0.85f;
            revolverSkillTreeButtons[9].interactable = false;
            revolverSkillTreeButtons[8].interactable = false;
            ColorBlock cb = revolverSkillTreeButtons[0].colors;
            cb.disabledColor = Color.yellow;
            revolverSkillTreeButtons[9].colors = cb;

            Time.timeScale = 1;
        }
    }
}