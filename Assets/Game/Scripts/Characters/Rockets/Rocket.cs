using System;
using UnityEngine;

public class Rocket : MonoBehaviour, IPoolableObject
{
    [SerializeField] private RocketMover _mover;
    [SerializeField] private RocketCollisionHandler _collisionHandler;

    private Type _ignoreCollisionWith;

    public event Action<Rocket> Eliminated;

    private void OnEnable()
    {
        _collisionHandler.Collided += OnCollision;
    }
    private void OnDisable()
    {
        _collisionHandler.Collided -= OnCollision;
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    public void ResetObject()
    {

    }

    public void Initialize(Type ignoreCollisionWith)
    {
        _ignoreCollisionWith = ignoreCollisionWith;
    }

    public void OnCollision(Collider2D collider)
    {
        if (collider.TryGetComponent(_ignoreCollisionWith, out _))
            return;

        Eliminated?.Invoke(this);
    }
}
