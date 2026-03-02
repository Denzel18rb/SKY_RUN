using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject floorPrefab;
    public float spawnDistance = 20f;
    public float spawnRate = 4f;

    private float nextSpawnX = 0;

    void Start()
    {
        InvokeRepeating("SpawnFloor", 0f, spawnRate);
    }

    void SpawnFloor()
    {
        Instantiate(floorPrefab, new Vector3(nextSpawnX, 0, 0), Quaternion.identity);
        nextSpawnX += spawnDistance;
    }
}