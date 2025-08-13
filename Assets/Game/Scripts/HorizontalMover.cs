using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public virtual void Move()
    {
        transform.Translate(_speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
