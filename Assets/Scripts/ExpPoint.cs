using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
	private Player player;
	private bool isInRange = false;
	
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= player.playerPickupRange) 
		{
			isInRange = true;
		}
		if(isInRange)
		{
			transform.position = transform.forward * Time.deltaTime * player.playerSpeed;
		}
    }
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.name == "Player")
		{
			Destroy(gameObject);
		}
	}
}
