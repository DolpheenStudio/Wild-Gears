using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVisibility : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) >= 30)
        {
            gameObject.SetActive(false);
        }
    }
}
