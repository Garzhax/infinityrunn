using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de la "cinta transportadora"
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mueve el piso hacia el jugador (eje Z negativo)
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Opcional: Reposiciona el piso cuando se aleje demasiado
        if (transform.position.z < playerTransform.position.z - 20f)
        {
            RepositionFloor();
        }
    }

    void RepositionFloor()
    {
        // Coloca el piso nuevamente delante del jugador
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            playerTransform.position.z + 30f // Ajusta según necesidad
        );
    }
    // En MovingFloor.cs
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 0.1f, 100));
    }
}