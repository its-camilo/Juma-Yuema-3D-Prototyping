using UnityEngine;

public class Enemyp1 : MonoBehaviour
{
    public float detectionDistance = 5f;  // Distancia de detección del raycast
    private bool isFacingLeft = true;  // Indica si el enemigo está mirando a la izquierda

    void Start()
    {
        // Asegurarse de que el enemigo mire inicialmente a la izquierda
        transform.localScale = new Vector3(-1, 1, 1);  // Invierte la escala en el eje X para mirar a la izquierda
    }

    void Update()
    {
        // Realiza múltiples raycasts en un cono para simular el campo de visión
        Vector3 direction = isFacingLeft ? Vector3.left : Vector3.right;
        float coneAngle = 45f;  // Ángulo del cono de visión horizontal
        float verticalConeAngle = 30f;  // Ángulo del cono de visión vertical
        int rayCount = 5;  // Número de rayos en el cono horizontal
        int verticalRayCount = 3;  // Número de rayos en el cono vertical

        for (int j = 0; j < verticalRayCount; j++)
        {
            float verticalAngle = Mathf.Lerp(-verticalConeAngle / 2, verticalConeAngle / 2, j / (float)(verticalRayCount - 1));
            for (int i = 0; i < rayCount; i++)
            {
                float horizontalAngle = Mathf.Lerp(-coneAngle / 2, coneAngle / 2, i / (float)(rayCount - 1));
                Vector3 rayDirection = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * direction;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, rayDirection, out hit, detectionDistance))
                {
                    Debug.DrawRay(transform.position, rayDirection * detectionDistance, Color.red);
                    // Aquí puedes agregar lógica si el enemigo "ve" algo
                }
                else
                {
                    Debug.DrawRay(transform.position, rayDirection * detectionDistance, Color.green);
                }
            }
        }
    }

    public void ReactToWhistle(Vector3 birdPosition)
    {
        // Si el pájaro está a la derecha del enemigo, voltear
        if (birdPosition.x > transform.position.x && isFacingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Cambiar la dirección del enemigo
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector3(isFacingLeft ? -1 : 1, 1, 1);
    }
}