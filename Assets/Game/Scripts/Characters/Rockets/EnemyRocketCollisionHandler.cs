using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketCollisionHandler : CollisionHandler, IInteractable
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyRocketCollisionHandler _))
            return;
        
        if (collision.TryGetComponent(out EnemyCollisionHandler _))
            return;

        base.OnTriggerEnter2D(collision);
    }
}
