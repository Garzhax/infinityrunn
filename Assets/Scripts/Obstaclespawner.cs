using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] obstaclePrefabs;
    public float spawnDistance = 10f;
    public Vector2 xRange = new Vector2(-5f, 5f);
    public float spawnHeight = 0.5f;
    public float spawnInterval = 2f;

    private Transform player;
    private float nextSpawnTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0 || player == null) return;

        Vector3 spawnPos = new Vector3(
            Random.Range(xRange.x, xRange.y),
            spawnHeight,
            player.position.z + spawnDistance
        );

        Instantiate(
            obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
            spawnPos,
            Quaternion.identity
        );
    }
}