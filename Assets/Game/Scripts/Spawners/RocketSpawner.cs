using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : SpawnerBase<Rocket>
{
    public void Spawn(Vector3 position)
    {
        Rocket rocket = ObjectPool.Get();
        rocket.transform.position = position;
    }

    protected override Rocket Create()
    {
        Rocket rocket = Instantiate(PrefabToSpawn);
        rocket.gameObject.SetActive(false);
        return rocket;
    }

    protected override void OnClear(Rocket obj)
    {
        Destroy(obj.gameObject);
    }

    protected override void OnGet(Rocket obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected override void OnRelease(Rocket obj)
    {
        obj.gameObject.SetActive(false);
    }
}
