using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 8f; // Velocidad hacia el jugador
    public float rotationSpeed = 30f; // Rotación visual

    private Transform player;
    private bool isPlayerValid = true;

    void Start()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Jugador no encontrado. Destruyendo obstáculo.");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (player == null) return;

        // Movimiento hacia el jugador (eje Z negativo en un juego 3D)
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Rotación opcional para efecto visual
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}