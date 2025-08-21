using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : HorizontalMover
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Move()
    {
        _rigidbody2D.MovePosition(transform.right * Speed * Time.fixedDeltaTime + transform.position);
    }
}
