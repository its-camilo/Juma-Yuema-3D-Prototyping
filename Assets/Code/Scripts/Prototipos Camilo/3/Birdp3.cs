using UnityEngine;

public class Birdp3 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask whatIsRope; // Capa de la cuerda
    private bool nearRope = false;
    private GameObject rope;

    void Update()
    {
        // Movimiento horizontal con A y D
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);

        // Interacción con la cuerda si está cerca y se presiona la tecla "E"
        if (nearRope && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Cortando la cuerda...");
            CutRope();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Detecta si está tocando la cuerda
        if (((1 << collision.gameObject.layer) & whatIsRope) != 0)
        {
            nearRope = true;
            rope = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // Se aleja de la cuerda
        if (((1 << collision.gameObject.layer) & whatIsRope) != 0)
        {
            nearRope = false;
            rope = null;
        }
    }

    void CutRope()
    {
        if (rope != null)
        {
            Destroy(rope); // Destruye la cuerda
        }
    }
}