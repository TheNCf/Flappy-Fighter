using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour, IPoolableObject
{
    [SerializeField] private RocketMover _mover;

    private void Update()
    {
        _mover.Move();
    }

    public void ResetObject()
    {
        
    }
}
