using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointerRotation : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void RotateDirectionPointer(float rotationAngle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle * -1f);
    }
}
