using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradePointsCounter : MonoBehaviour
{
    private TMP_Text text;
    private Player player;
    private int oldUpgradePoints;

    void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponent<TMP_Text>();

        oldUpgradePoints = player.playerUpgradePoints;
        text.SetText("Upgrade Points: " + player.playerUpgradePoints.ToString());
    }

    void Update()
    {
        if(oldUpgradePoints != player.playerUpgradePoints)
        {
            text.SetText("Upgrade Points: " + player.playerUpgradePoints.ToString());
            oldUpgradePoints = player.playerUpgradePoints;
        }
    }
}
