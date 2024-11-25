using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 move;
    [Header("Variables Publicas")]
    public float speed = 0.01f;
    public bool isPause = false;
    public bool seMueve = true;
    [SerializeField] PlayerVariables playerVariables;
    [SerializeField] Vector2 velocidadRebote;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // playerVariables = GetComponent<PlayerVariables>();
    }

    void Update()
    {
        if (seMueve)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            flip();
        }
    }

    void FixedUpdate()
    {
        if (playerVariables.getEnSuelo() && !playerVariables.getEnAtaque()&& seMueve)
        {
            rb.AddForce(move * speed, ForceMode2D.Impulse);
            playerVariables.setMovimientoHorizontal(rb.velocity.x);
        }
        
    }
    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(0, 0);
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
    void flip()
    {
        if (move.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
