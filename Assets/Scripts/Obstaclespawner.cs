using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array de prefabs (asignados en el Inspector)
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
        // 1. Elige un prefab aleatorio del array
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[randomIndex];

        // 2. Calcula posición aleatoria
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(
            randomX,
            0.5f,
            playerTransform.position.z + spawnDistance
        );

        // 3. Instancia el prefab correcto
        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}