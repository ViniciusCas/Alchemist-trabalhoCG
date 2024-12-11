using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Skeleton_Minion; // Reference to the Skeleton_Minion prefab
    public Vector2 spawnAreaX = new Vector2(1f, 40f); // X-axis spawn range
    public Vector2 spawnAreaZ = new Vector2(1f, 40f); // Z-axis spawn range
    public float initialSpawnInterval = 5f; // Starting interval between spawns
    public float minimumSpawnInterval = 1f; // Minimum time between spawns
    public float spawnIntervalDecrement = 0.1f; // Amount to reduce spawn interval over time
    public int maxSpawnCount = 10; // Maximum number of enemies to spawn at once

    private float currentSpawnInterval;
    private float nextSpawnTime;

    void Start()
    {
        // Initialize the spawn interval and set the first spawn time
        currentSpawnInterval = initialSpawnInterval;
        nextSpawnTime = Time.time + currentSpawnInterval;
        Skeleton_Minion = GameObject.Find("Skeleton_Minion");
    }

    void Update()
    {
        // Check if it's time to spawn
        if (Time.time >= nextSpawnTime)
        {
            // Spawn a random number of Skeleton_Minion prefabs
            int spawnCount = Random.Range(1, maxSpawnCount + 1);
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnSkeletonMinion();
            }

            // Schedule the next spawn
            currentSpawnInterval = Mathf.Max(minimumSpawnInterval, currentSpawnInterval - spawnIntervalDecrement);
            nextSpawnTime = Time.time + currentSpawnInterval;
        }
    }

    void SpawnSkeletonMinion()
    {
        // Generate a random position within the spawn area
        float x = Random.Range(spawnAreaX.x, spawnAreaX.y);
        float z = Random.Range(spawnAreaZ.x, spawnAreaZ.y);
        Vector3 spawnPosition = new Vector3(x, 1, z);

        // Instantiate the Skeleton_Minion prefab
        GameObject singleSkeleton = Instantiate(Skeleton_Minion, spawnPosition, Quaternion.identity);
        singleSkeleton.AddComponent<SkeletonMinion>();
        singleSkeleton.AddComponent<Rigidbody>();
    }
}
