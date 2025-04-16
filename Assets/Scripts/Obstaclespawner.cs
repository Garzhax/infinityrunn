using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform movingFloor; // Referencia al piso móvil
    public float spawnInterval = 2f;
    public float minX = -3f, maxX = 3f;

    private float nextSpawnTime;

    void Start()
    {
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
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            0.5f, // Altura sobre el piso
            movingFloor.position.z // Spawnea en la posición Z actual del piso
        );

        Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity, movingFloor);
    }
}