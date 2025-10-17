using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : SpawnerBase<Rocket>
{
    public Rocket Spawn(Vector3 position, Quaternion rotation)
    {
        Rocket rocket = ObjectPool.Get();
        rocket.transform.position = position;
        rocket.transform.rotation = rotation;

        return rocket;
    }

    protected override Rocket Create()
    {
        Rocket rocket = Instantiate(PrefabToSpawn);
        rocket.gameObject.SetActive(false);
        return rocket;
    }

    protected override void OnClear(Rocket obj)
    {
        obj.Eliminated -= OnEliminated;
        Destroy(obj.gameObject);
    }

    protected override void OnGet(Rocket obj)
    {
        obj.Eliminated += OnEliminated;
        obj.gameObject.SetActive(true);
        ActiveObjects.Add(obj);
    }

    protected override void OnRelease(Rocket obj)
    {
        obj.Eliminated -= OnEliminated;
        obj.gameObject.SetActive(false);
        ActiveObjects.Remove(obj);
    }

    private void OnEliminated(Rocket rocket)
    {
        ObjectPool.Release(rocket);
    }
}
