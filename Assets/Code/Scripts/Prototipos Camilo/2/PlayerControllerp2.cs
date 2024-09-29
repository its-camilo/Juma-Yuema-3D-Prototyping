using UnityEngine;

public class PlayerControllerp2 : MonoBehaviour
{
    public float speed = 5f;
    public float hiddenZPosition = -1f; // Coordenada Z cuando está oculto
    public float visibleZPosition = 0f; // Coordenada Z cuando no está oculto
    public bool isHidden = false; // Indica si el player está oculto

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move * speed * Time.deltaTime, 0f, 0f);
        
        // Si está oculto, puede moverse en el hueco
        if (isHidden)
        {
            transform.Translate(movement);
            if (Input.GetKeyDown(KeyCode.S)) // Sale del hueco
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, visibleZPosition);
                isHidden = false;
            }
        }
        else
        {
            rb.MovePosition(transform.position + movement);
        }
    }

    // Maneja la interacción con el trigger collider para ocultarse
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Sombra"))
        {
            if (Input.GetKeyDown(KeyCode.W) && !isHidden)
            {
                // El player entra al hueco y se oculta
                transform.position = new Vector3(transform.position.x, transform.position.y, hiddenZPosition);
                isHidden = true;
            }
        }
    }
}