using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    public virtual void Move()
    {
        transform.Translate(transform.right * Speed * Time.deltaTime);
    }
}
