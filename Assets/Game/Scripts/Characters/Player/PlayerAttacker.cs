using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private RocketSpawner _rocketSpawner;
    [SerializeField] private float _reloadTime = 1.0f;

    private bool _canAttack = true;

    public void Attack()
    {
        if (_canAttack == false)
            return;

        StartCoroutine(AttackCoroutine());
        _rocketSpawner.Spawn(transform.position, transform.rotation);
    }

    private IEnumerator AttackCoroutine()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_reloadTime);
        _canAttack = true;
    }
}
