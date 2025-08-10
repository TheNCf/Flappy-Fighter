using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputRegisterer _inputRegisterer;

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

    private void OnEnable()
    {
        _inputRegisterer.Jump += OnJump;
        _inputRegisterer.Attack += OnAttack;
        _playerCollisionHandler.CollisionDetected += OnCollision;
    }

    private void Update()
    {
        _playerMover.UpdateAngle();
    }

    private void OnDisable()
    {
        _inputRegisterer.Jump -= OnJump;
        _inputRegisterer.Attack -= OnAttack;
        _playerCollisionHandler.CollisionDetected -= OnCollision;
    }

    private void OnJump()
    {
        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            _playerMover.Reset();
        }
        _playerMover.GainAltitude();
    }

    private void OnAttack()
    {

    }

    private void OnCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            Time.timeScale = 0.0f;
        }
    }
}
