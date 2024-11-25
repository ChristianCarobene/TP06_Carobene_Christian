using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] PlayerVariables playerVariables;
    [SerializeField] PlayerControlVida playerControlVida;
    Rigidbody2D rb;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // playerVariables = GetComponent<PlayerVariables>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.tag);


        if (collision.gameObject.CompareTag("Enemigo"))
        {
            int tempDaño = 0;
            EnemigoVida enemigo = collision.gameObject.GetComponent<EnemigoVida>();
            tempDaño = enemigo.GetDaño() - playerVariables.getDefensa();
            if (tempDaño > 0)
            {
                playerControlVida.TomarDaño(tempDaño, gameObject.transform.position);
            }
        }
        if (collision.gameObject.CompareTag("FinMapa"))
        {
            EnemigoVida enemigo = collision.gameObject.GetComponent<EnemigoVida>();
            playerControlVida.TomarDaño(99999, gameObject.transform.position);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinManager coinManager = collision.gameObject.GetComponent<CoinManager>();
            playerVariables.setOro(playerVariables.getOro() + coinManager.getOro());
            audioManager.PlaySFX(audioManager.checkpoint);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PUInmune"))
        {
            playerVariables.setDefensa(99999);
            playerVariables.setInmune(true);
            audioManager.PlaySFX(audioManager.playerBufDefensa);
            Destroy(collision.gameObject);
            StartCoroutine(CountTimeInmune());
        }
        if (collision.gameObject.CompareTag("PUVida"))
        {
            playerVariables.setVida(playerVariables.getVida() + 1);
            audioManager.PlaySFX(audioManager.playerBufVida);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PUMaxVida"))
        {

            playerVariables.setMaxVida(playerVariables.getMaxVida() + 1);
            audioManager.PlaySFX(audioManager.playerBufMaxVida);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PUFuerza"))
        {
            playerVariables.setDaño(playerVariables.getDaño() + 5);
            audioManager.PlaySFX(audioManager.playerBufDaño);
            Destroy(collision.gameObject);
            StartCoroutine(CountTimeFuerza());
        }

    }
    private IEnumerator CountTimeInmune()
    {

        yield return new WaitForSeconds(playerVariables.getTiempoInmune());
        playerVariables.setDefensa(0);
        playerVariables.setInmune(false);
        audioManager.PlaySFX(audioManager.playerDefBuf);

    }
    private IEnumerator CountTimeFuerza()
    {

        yield return new WaitForSeconds(playerVariables.getTiempoFuerza());
        playerVariables.setDaño(playerVariables.getDaño() - 5);
        audioManager.PlaySFX(audioManager.playerDefBuf);
    }
}
