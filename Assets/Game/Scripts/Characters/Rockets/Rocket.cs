using System;
using UnityEngine;

public class Rocket : MonoBehaviour, IPoolableObject
{
    [SerializeField] private RocketMover _mover;
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action<Rocket> Eliminated;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollision;
    }
    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollision;
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    public void ResetObject()
    {

    }

    public void OnCollision(IInteractable interactable)
    {
        Eliminated?.Invoke(this);
    }
}
