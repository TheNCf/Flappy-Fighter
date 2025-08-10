using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRegisterer : MonoBehaviour
{
    private InputActions _inputActions;

    public Action Jump;
    public Action Attack;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Jump.performed += OnJumpPerformed;
        _inputActions.Player.Attack.performed += OnAttackPerformed;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Jump.performed -= OnJumpPerformed;
        _inputActions.Player.Attack.performed -= OnAttackPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump?.Invoke();
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Attack?.Invoke();
    }
}
