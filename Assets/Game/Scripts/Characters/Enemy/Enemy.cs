using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyCollisionHandler _collisionHandler;

    public event Action<Enemy> Eliminated;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;
    }

    private void Update()
    {
        _mover.Move();
    }

    public void Initialize(RocketSpawner rocketSpawner)
    {
        _attacker.Initialize(rocketSpawner);
    }

    public void ResetObject()
    {
        
    }

    private void OnCollision(IInteractable interactable)
    {
        if (interactable is PlayerRocketCollisionHandler || interactable is PlayerCollisionHandler)
            Eliminated?.Invoke(this);
    }
}
