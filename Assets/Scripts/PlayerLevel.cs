using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private Player player;
	private int expNeeded = 100;
	
    void Start()
    {
        player = GetComponent<Player>();
    }
}
