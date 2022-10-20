using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgradeInfo : MonoBehaviour
{
    public GameObject playerLevelInfo;
    public GameObject playerUpgradePointsInfo;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();    
    }

    
    void Update()
    {
        playerLevelInfo.GetComponent<TMP_Text>().SetText("Level " + player.playerLevel);
        playerUpgradePointsInfo.GetComponent<TMP_Text>().SetText("Upgrade Points " + player.playerUpgradePoints);
    }
}
