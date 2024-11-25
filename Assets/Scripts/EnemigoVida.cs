using System.Collections;
using System.Drawing;
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    public bool onHit;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private int vida;
    [SerializeField] private int maxVida;
    [SerializeField] private float esperaMuerte;
    [SerializeField] private float esperaDa�o;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float limeteDistance;
    [SerializeField] private int da�o;
    [SerializeField] private InitialEnemyData enemyData;
    [SerializeField] private PlayerVariables playerVariables;

    [SerializeField] private Animator animator;
    private bool movIzq;
    private float limiteDerecho;
    private float limiteIzquierdo;
    private BoxCollider2D boxCollider2d;

    private void Start()
    {
        animator.SetInteger("Vida", vida);
        onHit = false;
        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
  
    }
    private void Awake()
    {
        maxVida = (int)enemyData.enemyHealth;
        da�o = (int)enemyData.enemyDamage;
        vida = maxVida;
        limiteIzquierdo = transform.position.x - limeteDistance;
        limiteDerecho = transform.position.x + limeteDistance;
        barraDeVida.UpdateBarraDeVida(maxVida, vida);
    }
    private void Update()
    {
        if (vida>0)
        {
            if (movIzq)
            {
                if (transform.position.x > limiteIzquierdo)
                {
                    transform.position = new Vector3(transform.position.x - MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    transform.localScale = Vector3.one;
                }
                else
                {
                    movIzq = false;
                }
            }
            else
            {
                if (transform.position.x < limiteDerecho)
                {
                    transform.position = new Vector3(transform.position.x + MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    movIzq = true;
                }
            }
        }
    }

    public void TomarDa�o(int da�o)
    {
        if (vida > 0 && !onHit)
        {

            vida -= da�o;
            onHit = true;
            animator.SetBool("onHit", true);
            StartCoroutine(Da�oAfterAnim());
            barraDeVida.UpdateBarraDeVida(maxVida, vida);
            audioManager.PlaySFX(audioManager.snailHit);

        }
        if (vida == 0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        boxCollider2d.enabled=false;
        
        audioManager.PlaySFX(audioManager.snailDie);
        StartCoroutine(DeathAfterAnim());
    }
    private IEnumerator DeathAfterAnim()
    {
        yield return new WaitForSeconds(esperaMuerte);
        playerVariables.setScore(playerVariables.getScore() + 1);
        Destroy(gameObject);
    }

    private IEnumerator Da�oAfterAnim()
    {
        yield return new WaitForSeconds(esperaDa�o);
        onHit = false;
        animator.SetBool("onHit", false);

    }

    public int GetDa�o()
    {
        return da�o;
    }


}