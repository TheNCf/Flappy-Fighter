using System;
using UnityEngine;

public class Rocket : MonoBehaviour, IPoolableObject, IEliminateable
{
    [SerializeField] private RocketMover _mover;

    public event Action<Rocket> Eliminated;

    private void FixedUpdate()
    {
        _mover.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IEliminateable eliminateable))
        {
            Eliminate();
            Debug.Log("ddf");
        }
    }

    public void ResetObject()
    {

    }

    public void Eliminate()
    {
        Eliminated?.Invoke(this);
    }
}
