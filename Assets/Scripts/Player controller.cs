using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Awake()
    {
        // Opcional: Para evitar que se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    // Elimina cualquier Update() con movimiento
    // O deja el método vacío si necesitas otras funcionalidades
    void Update()
    {
        // Sin código de movimiento aquí
    }
}