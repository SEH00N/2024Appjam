using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnDistance = 10f;
	[SerializeField] List<UnitController> units;

    [SerializeField] Transform playerTrm;

    private float lastSpawnTime = 0f;

    private void Update()
    {
        if(Time.time > lastSpawnTime + spawnDelay)
        {
            SpawnUnit();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnUnit()
    {
        Vector3 randOffset = Random.insideUnitSphere * spawnDistance;
        Vector3 position = playerTrm.position + randOffset;

        int randIndex = Random.Range(0, units.Count);
        Instantiate(units[randIndex], position, Quaternion.identity).Target = playerTrm;
    }
}
