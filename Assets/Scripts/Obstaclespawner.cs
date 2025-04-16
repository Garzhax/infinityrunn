using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("CONFIGURAR EN INSPECTOR")]
    [Tooltip("Arrastra aquí TODOS los prefabs de obstáculos")]
    public GameObject[] obstaclePrefabs;

    [Space(10)]
    [Tooltip("Distancia frente al jugador donde aparecerán")]
    public float spawnDistance = 15f;

    [Tooltip("Rango horizontal (izq/der)")]
    public Vector2 xRange = new Vector2(-4f, 4f);

    [Tooltip("Altura sobre el piso")]
    public float yHeight = 0.5f;

    [Tooltip("Tiempo entre apariciones")]
    public float spawnInterval = 2f;

    private Transform player;
    private bool initializationFailed = false;

    void Start()
    {
        Debug.Log("=== SISTEMA DE SPAWN INICIADO ===");

        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if (player == null)
            {
                Debug.LogError("❌ No se encontró objeto con tag 'Player'");
                initializationFailed = true;
                return;
            }

            if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
            {
                Debug.LogError("❌ El array de prefabs está vacío");
                initializationFailed = true;
                return;
            }

            Debug.Log($"✅ Configuración correcta. Jugador: {player.name}, Prefabs: {obstaclePrefabs.Length}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"🔥 Error crítico: {e.Message}");
            initializationFailed = true;
        }
    }

    void Update()
    {
        if (initializationFailed) return;

        if (Time.time >= spawnInterval)
        {
            SpawnObstacle();
            spawnInterval = Time.time + spawnInterval;

            Debug.Log($"🔄 Obstáculo generado en {Time.time}");
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(xRange.x, xRange.y),
            yHeight,
            player.position.z + spawnDistance
        );

        GameObject newObstacle = Instantiate(
            obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
            spawnPos,
            Quaternion.identity
        );

        Debug.Log($"📦 Nuevo obstáculo: {newObstacle.name} en {spawnPos}");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        if (player != null)
        {
            Vector3 center = new Vector3(
                (xRange.x + xRange.y) / 2,
                yHeight,
                player.position.z + spawnDistance
            );
            Gizmos.DrawWireCube(center, new Vector3(xRange.y - xRange.x, 1, 1));
        }
    }
}