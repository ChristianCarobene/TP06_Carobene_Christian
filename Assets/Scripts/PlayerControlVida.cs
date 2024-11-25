using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlVida : MonoBehaviour
{
    public bool onHit;
    [SerializeField] private PlayerBarraDeVida barraDeVida;
    [SerializeField] private PlayerVariables playerVariables;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private int vida;
    [SerializeField] private int maxVida;
    [SerializeField] private float esperaMuerte;
    [SerializeField] private float esperaDaño;
    [SerializeField] private Animator animator;


    private void Start()
    {
        onHit = false;

    }
    private void Awake()
    {
        vida = playerVariables.getVida();
        maxVida = playerVariables.getMaxVida();
        barraDeVida.InicializarBarraDeVida(maxVida);
    }


    public void TomarDaño(int daño, Vector2 posicion)
    {
        if (vida > 0 && !onHit)
        {

            vida -= daño;
            if (vida < 0) vida = 0;
            onHit = true;
            animator.SetBool("onHit", true);
            playerMovement.seMueve = false;
            StartCoroutine(DañoAfterAnim());
            playerVariables.setVida(vida);
            barraDeVida.CambiarVida(vida);
            playerMovement.Rebote(posicion);
        }
        if (vida == 0)
        {
            Muerte();

        }
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        StartCoroutine(DeathAfterAnim());
        playerMovement.seMueve = false;
        playerMovement.rb.velocity = new Vector2(0, 0);
        playerMovement.rb.totalForce = new Vector2(0, 0); 
    }
    private IEnumerator DeathAfterAnim()
    {
        yield return new WaitForSeconds(esperaMuerte);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private IEnumerator DañoAfterAnim()
    {
        
        yield return new WaitForSeconds(esperaDaño);
        onHit = false;
        playerMovement.seMueve = true;
        animator.SetBool("onHit", false);
        playerMovement.rb.totalForce = new Vector2(0, 0);


    }
}

