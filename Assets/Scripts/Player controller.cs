using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Awake()
    {
        // Opcional: Para evitar que se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    // Elimina cualquier Update() con movimiento
    // O deja el m�todo vac�o si necesitas otras funcionalidades
    void Update()
    {
        // Sin c�digo de movimiento aqu�
    }
}