using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAttacker _attacker;

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
}
