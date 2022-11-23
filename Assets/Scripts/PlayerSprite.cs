using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private Player player;
    public GameObject playerMovingSprite;
    public GameObject playerStandingSprite;

    private Vector3 lastPlayerPosition;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerStandingSprite.SetActive(true);
        playerMovingSprite.SetActive(false);

        lastPlayerPosition = transform.position;
    }

    void Update()
    {
        if (lastPlayerPosition == transform.position)
        {
            playerStandingSprite.SetActive(true);
            playerMovingSprite.SetActive(false);
        }
        else
        {
            playerStandingSprite.SetActive(false);
            playerMovingSprite.SetActive(true);
        }
        lastPlayerPosition = transform.position;
    }
}
