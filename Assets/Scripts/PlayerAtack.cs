using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] private Animator animator;
    [SerializeField] PlayerVariables playerVariables;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    private void Start()
    {
        dañoGolpe = playerVariables.getDaño();
    }
    private void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
            if (playerVariables.getEnAtaque())
            {
                playerVariables.setEnAtaque(false);
            }
        }

        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0 && playerVariables.getEnSuelo() )
        {
            playerVariables.setEnAtaque(true);
            audioManager.PlaySFX(audioManager.playerAttack);
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe()
    {
        
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<EnemigoVida>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
