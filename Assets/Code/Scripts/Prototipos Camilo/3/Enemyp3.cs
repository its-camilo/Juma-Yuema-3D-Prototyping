using UnityEngine;

public class Enemyp3 : MonoBehaviour
{
    public float visionDistance = 5f;
    public LayerMask whatIsPlayer; // Capa del jugador o pájaro que se debe detectar

    void Update()
    {
        // Lanza el Raycast hacia la izquierda
        Vector2 direction = Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionDistance, whatIsPlayer);

        // Si el raycast impacta algo en la capa de lo que está buscando
        if (hit.collider != null)
        {
            Debug.Log("Pájaro detectado!");
            // Aquí puedes agregar más comportamiento si el enemigo ve al pájaro
        }
    }

    private void OnDrawGizmos()
    {
        // Dibuja el campo de visión en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * visionDistance);
    }
}