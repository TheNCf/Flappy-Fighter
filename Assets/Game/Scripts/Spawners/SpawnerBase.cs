using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBase<T> : MonoBehaviour where T : UnityEngine.Object, IPoolableObject
{
    [SerializeField] protected T PrefabToSpawn;
    [SerializeField] protected int PoolSizeAtStart = 100;

    protected ObjectPool<T> ObjectPool;

    protected List<T> ActiveObjects = new List<T>();

    public int InsatncesInPool => ObjectPool.CountAll;
    public int ActiveInPool => ObjectPool.CountActive;

    protected virtual void Awake()
    {
        ObjectPool = new ObjectPool<T>(Create, OnGet, OnRelease, OnClear, PoolSizeAtStart);
    }

    public void ReleaseAll()
    {
        for (int i = ActiveObjects.Count - 1; i >= 0; i--)
            ObjectPool.Release(ActiveObjects[i]);
    }

    protected abstract T Create();

    protected abstract void OnGet(T obj);

    protected abstract void OnRelease(T obj);

    protected abstract void OnClear(T obj);
}
