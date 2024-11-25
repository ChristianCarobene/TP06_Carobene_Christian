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
    [SerializeField] private float esperaDa�o;
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


    public void TomarDa�o(int da�o, Vector2 posicion)
    {
        if (vida > 0 && !onHit)
        {

            vida -= da�o;
            if (vida < 0) vida = 0;
            onHit = true;
            animator.SetBool("onHit", true);
            playerMovement.seMueve = false;
            StartCoroutine(Da�oAfterAnim());
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

    private IEnumerator Da�oAfterAnim()
    {
        
        yield return new WaitForSeconds(esperaDa�o);
        onHit = false;
        playerMovement.seMueve = true;
        animator.SetBool("onHit", false);
        playerMovement.rb.totalForce = new Vector2(0, 0);


    }
}

