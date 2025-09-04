using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RocketCollisionHandler : MonoBehaviour
{
    public event Action<Collider2D> Collided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collided?.Invoke(collision);
    }
}
