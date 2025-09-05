using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private RocketSpawner _rocketSpawner;
    [Space(10)]
    [SerializeField] private float _reloadTime = 1.5f;

    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void Initialize(RocketSpawner rocketSpawner)
    {
        _rocketSpawner = rocketSpawner;
    }

    private IEnumerator AttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_reloadTime);

        while (enabled)
        {
            yield return wait;
            Rocket rocket = _rocketSpawner.Spawn(transform.position, Quaternion.identity);
        }
    }
}
