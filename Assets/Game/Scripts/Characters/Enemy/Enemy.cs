using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAttacker _attacker;

    private void Update()
    {
        _mover.Move();
    }
}
