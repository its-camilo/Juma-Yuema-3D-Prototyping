using UnityEngine;

public class EnemyControllerp2 : MonoBehaviour
{
    public float speed = 3f;
    public Transform pointA;
    public Transform pointB;

    public float visionRange = 5f; // Alcance de la visión
    public LayerMask playerLayer; // Capa del jugador

    private bool movingToB = true;

    void Update()
    {
        Patrol();
        DetectPlayer();
    }

    // Patrullaje del enemigo entre dos puntos
    void Patrol()
    {
        if (movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingToB = true;
            }
        }
    }

    // Detección del jugador usando raycasts
    void DetectPlayer()
    {
        RaycastHit hit;

        // Raycast hacia la derecha
        if (Physics.Raycast(transform.position, Vector3.right, out hit, visionRange, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Jugador detectado");
                ResetGame();
            }
        }

        // Raycast hacia la izquierda
        if (Physics.Raycast(transform.position, Vector3.left, out hit, visionRange, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Jugador detectado");
                ResetGame();
            }
        }
    }

    // Reiniciar el nivel o escena cuando el jugador es detectado
    void ResetGame()
    {
        // Reiniciar la escena o cualquier otra lógica que prefieras
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Dibujar las líneas de los raycasts en la escena para visualización
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * visionRange);
    }
}
