using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputRegisterer _inputRegisterer;

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

    private bool _isActive = false;

    public event Action GameOver;

    public bool IsActive 
    { 
        get => _isActive; 
        
        set 
        { 
            _isActive = value; 
            _playerMover.enabled = value;

            if (_isActive == false)
                _playerMover.Reset();
        } 
    }

    private void OnEnable()
    {
        _inputRegisterer.Jump += OnJump;
        _inputRegisterer.Attack += OnAttack;
        _playerCollisionHandler.CollisionDetected += OnCollision;
    }

    private void Update()
    {
        if (IsActive)
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
        _playerMover.GainAltitude();
    }

    private void OnAttack()
    {
        _playerAttacker.Attack(_playerCollisionHandler.Collider);
    }

    private void OnCollision(IInteractable interactable)
    {
        if (interactable is Terminator || interactable is EnemyRocketCollisionHandler || interactable is EnemyCollisionHandler)
        {
            GameOver?.Invoke();
        }
    }
}
