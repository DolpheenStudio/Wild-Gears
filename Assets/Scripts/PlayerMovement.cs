using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController controller;
    private Player player;
    public DirectionPointerRotation directionPointer;

    private float joystickSensitivity = .2f;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector2 input = playerInput.actions["Movement"].ReadValue<Vector2>();
        if (Math.Abs(input.x) >= joystickSensitivity || Math.Abs(input.y) >= joystickSensitivity)
        {
            Vector3 move = new Vector3(input.x, input.y, 0f).normalized;
            controller.Move(move * Time.deltaTime * player.playerSpeed);
            directionPointer.RotateDirectionPointer(Mathf.Rad2Deg * Mathf.Atan2(move.x, move.y));
        }
    }
}
