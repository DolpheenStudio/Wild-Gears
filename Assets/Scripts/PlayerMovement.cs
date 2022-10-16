using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController controller;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = playerInput.actions["Movement"].ReadValue<Vector2>();
        Debug.Log(input);
        controller.Move(new Vector3(input.x, 0f, input.y) * Time.deltaTime);
    }
}
