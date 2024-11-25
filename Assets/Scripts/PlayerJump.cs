using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Sistema de Salto")]
    [SerializeField] int fuerzaSalto;
    [SerializeField] float tiempoSalto;
    [SerializeField] float multiplicadorCaida;
    [SerializeField] float multiplicadorSalto;
    [SerializeField] float multiplicadorSaltoArriba;
    [SerializeField] float detectoSueloH;
    [SerializeField] float detectoSueloW;
    [SerializeField] PlayerVariables playerVariables;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    public Transform verSuelo;
    public LayerMask groundLayer;
    Vector2 vecGravity;
    float contadorSalto;
    float t;
    float saltoMActual;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        isGrounded();
        if (Input.GetButtonDown("Jump") && playerVariables.getEnSuelo())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            playerVariables.setEnSalto(true);
            audioManager.PlaySFX(audioManager.playerAttack);

            contadorSalto = 0;
        }

        if (rb.velocity.y > 0 && playerVariables.getEnSalto())
        {
            contadorSalto += Time.deltaTime;
            if (contadorSalto > tiempoSalto) playerVariables.setEnSalto(false);
            t = contadorSalto / tiempoSalto;
            saltoMActual = multiplicadorSalto * (1 - t);


            rb.velocity += vecGravity * saltoMActual * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            playerVariables.setEnSalto(false);
            contadorSalto = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * multiplicadorSaltoArriba);
            }

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += vecGravity * multiplicadorCaida * Time.deltaTime;
        }
    }

    void isGrounded()
    {
        playerVariables.setEnSuelo(Physics2D.OverlapCapsule(verSuelo.position, new Vector2(detectoSueloW, detectoSueloH), CapsuleDirection2D.Horizontal, 0, groundLayer));

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(verSuelo.position, new Vector2(detectoSueloW, detectoSueloH));
    }
}
