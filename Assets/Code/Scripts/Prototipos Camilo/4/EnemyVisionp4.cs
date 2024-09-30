using System.Collections;
using UnityEngine;

public class EnemyVisionp4 : MonoBehaviour
{
    // Rango de visión
    public float visionRange = 10f;
    // Cantidad de rayos en el campo de visión
    public int rayCount = 5;
    // Ángulo de apertura del campo de visión
    public float angleSpread = 30f;

    // Indica si el enemigo puede ver
    private bool canSee = true;

    // Update es llamado una vez por frame
    void Update()
    {
        // Si el enemigo tiene campo de visión
        if (canSee)
        {
            CastVision();
        }
    }

    // Método para generar los raycasts del campo de visión
    void CastVision()
    {
        // Generamos los raycasts distribuidos en un ángulo
        for (int i = 0; i < rayCount; i++)
        {
            float angle = -angleSpread / 2 + (angleSpread / (rayCount - 1)) * i;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.right;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange);
            
            // Dibujar los rayos en la escena para depuración
            Debug.DrawRay(transform.position, direction * visionRange, Color.red);
            
            // Si golpea al jugador
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Debug.Log("Jugador en el campo de visión del enemigo");
                // Aquí podrías agregar código para que el enemigo actúe ante el jugador
            }
        }
    }

    // Método que desactiva el campo de visión cuando la luz es destruida
    public void DisableVision()
    {
        canSee = false;
        // También puedes hacer que el enemigo reaccione de alguna manera cuando pierda la visión
        Debug.Log("El enemigo ha perdido su campo de visión");
    }
}