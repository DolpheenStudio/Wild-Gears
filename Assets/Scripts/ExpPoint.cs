using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
	private Player player;
	public bool isInRange = false;
	
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
		float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= player.playerPickupRange) 
		{
			isInRange = true;
		}
		if(isInRange)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, player.playerSpeed * Time.deltaTime * 2f);
		}
		if(distance <= .5f)
        {
			CollectExp();
        }
    }

	void CollectExp()
    {
		player.playerExp++;
		Destroy(gameObject);
    }
}
