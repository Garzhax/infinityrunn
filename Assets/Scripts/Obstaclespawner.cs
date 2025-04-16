using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    public float minX = -3f, maxX = 3f;

    private Transform playerTransform;
    private float nextSpawnTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomObstacle();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(
            randomX,
            0.5f,
            playerTransform.position.z + spawnDistance
        );

        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}