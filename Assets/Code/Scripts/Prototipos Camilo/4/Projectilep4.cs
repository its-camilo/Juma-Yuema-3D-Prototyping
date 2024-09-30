using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilep4 : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Si golpea la luz, el proyectil se destruye (la luz se destruye en su propio script)
        if (collision.CompareTag("Light"))
        {
            Destroy(this.gameObject);  // Destruimos el proyectil al impactar la luz
        }
    }
}