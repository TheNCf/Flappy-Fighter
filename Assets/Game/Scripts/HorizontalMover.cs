using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public virtual void Move()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }
}
