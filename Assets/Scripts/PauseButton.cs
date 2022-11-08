using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private PlayerUIController playerUIController;

    private void Start()
    {
        playerUIController = FindObjectOfType<PlayerUIController>();
    }
    public void PauseButtonClick()
    {
        Time.timeScale = 0;
        playerUIController.EnableUpgradeScreen();
        playerUIController.DisablePlayerUI();
    }
}
