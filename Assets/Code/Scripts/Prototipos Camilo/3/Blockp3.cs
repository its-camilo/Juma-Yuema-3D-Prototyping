using UnityEngine;

public class Blockp3 : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject rope; // Referencia a la cuerda

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // El bloque no se moverá hasta que la cuerda se corte
    }

    void Update()
    {
        // Si la cuerda ha sido destruida
        if (rope == null)
        {
            rb.isKinematic = false; // Activa la gravedad
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el bloque choca con el enemigo, lo destruye
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("¡Enemigo eliminado!");
        }
    }
}