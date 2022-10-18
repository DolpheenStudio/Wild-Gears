using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameObject movementJoystick;
    public GameObject pauseBG;
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            movementJoystick.SetActive(false);
            pauseBG.SetActive(true);

        }
        else
        {
            movementJoystick.SetActive(true);
            pauseBG.SetActive(false);
        }
    }
}
