using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocketCollisionHandler : CollisionHandler, IInteractable
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerRocketCollisionHandler _))
            return;

        if (collision.TryGetComponent(out PlayerCollisionHandler _))
            return;

        base.OnTriggerEnter2D(collision);
    }
}
