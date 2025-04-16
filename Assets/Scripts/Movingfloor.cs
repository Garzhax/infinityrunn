using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float moveSpeed = 5f;
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
            isPlayerValid = true;
        }
        else
        {
            Debug.LogWarning("Jugador no encontrado. Reintentando...");
            isPlayerValid = false;
            Invoke("FindPlayer", 1f); // Reintenta cada segundo
        }
    }

    void Update()
    {
        if (!isPlayerValid || player == null) return;

        try
        {
            // Movimiento seguro con verificación
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            // Reposicionamiento cuando se aleja
            if (transform.position.z < player.position.z - 20f)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    player.position.z + 30f
                );
            }
        }
        catch (System.NullReferenceException)
        {
            isPlayerValid = false;
            FindPlayer(); // Vuelve a buscar al jugador
        }
    }
}