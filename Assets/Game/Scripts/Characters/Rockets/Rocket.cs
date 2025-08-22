using System;
using UnityEngine;

public class Rocket : MonoBehaviour, IPoolableObject, IEliminatable
{
    [SerializeField] private RocketMover _mover;

    public event Action<Rocket> Eliminated;

    private void FixedUpdate()
    {
        _mover.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IEliminatable eliminatable))
            Eliminate();
    }

    public void ResetObject()
    {

    }

    public void Eliminate()
    {
        Eliminated?.Invoke(this);
    }
}
