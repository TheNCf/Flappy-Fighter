using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnerBase<Enemy>
{
    [SerializeField] private RocketSpawner _enemyRocketSpawner;
    [SerializeField, Min(0.001f)] private float _maxDelay = 2.0f;
    [SerializeField, Min(0.001f)] private float _minDelay = 1.0f;
    [SerializeField] private float _maxHeight = 1.0f;
    [SerializeField] private float _minHeight = -1.0f;

    private void OnValidate()
    {
        if (_minHeight > _maxHeight)
            _minHeight = _maxHeight;

        if (_minDelay > _maxDelay)
            _minDelay = _maxDelay;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up * _minHeight, transform.position + Vector3.up * _maxHeight);
    }

    private void Spawn()
    {
        Enemy enemy = ObjectPool.Get();
        float height = Random.Range(_minHeight, _maxHeight);
        enemy.transform.position = transform.position + Vector3.up * height;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            float delay = Random.Range(_minDelay, _maxDelay);
            yield return new WaitForSeconds(delay);
            Spawn();
        }
    }

    protected override Enemy Create()
    {
        Enemy enemy = Instantiate(PrefabToSpawn);
        enemy.Initialize(_enemyRocketSpawner);
        enemy.gameObject.SetActive(false);
        return enemy;
    }

    protected override void OnClear(Enemy obj)
    {
        obj.Eliminated -= OnEliminated;
        Destroy(obj.gameObject);
    }

    protected override void OnGet(Enemy obj)
    {
        obj.Eliminated += OnEliminated;
        obj.gameObject.SetActive(true);
        ActiveObjects.Add(obj);
    }

    protected override void OnRelease(Enemy obj)
    {
        obj.Eliminated -= OnEliminated;
        obj.gameObject.SetActive(false);
        ActiveObjects.Remove(obj);
    }

    private void OnEliminated(Enemy enemy)
    {
        ObjectPool.Release(enemy);
    }
}
