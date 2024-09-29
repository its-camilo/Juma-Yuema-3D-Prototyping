using UnityEngine;

public class Birdp1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public bool isWhistling = false;  // Si el pájaro está silbando
    public float whistleRadius = 5f;  // Rango del silbido

    void Update()
    {
        // Control de movimiento usando las teclas A (izquierda) y D (derecha)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Silbido al presionar la tecla "W"
        if (Input.GetKeyDown(KeyCode.W))
        {
            Whistle();
        }
    }

    void Whistle()
    {
        isWhistling = true;
        // Opcional: agregar sonido o animación del silbido aquí

        // Crear una esfera para representar el área en la que el silbido afecta al enemigo
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, whistleRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                // Llamar al enemigo para que reaccione al silbido
                hitCollider.GetComponent<Enemyp1>().ReactToWhistle(transform.position);
            }
        }
    }
}