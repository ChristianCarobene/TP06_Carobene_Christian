using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoControl : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Animator animator;
    [SerializeField] private bool enTrueno;
    [SerializeField] private float tiempoTrueno;
    [SerializeField] private float tiempoTotal = 0;
    [SerializeField] private float tiempoAnimTotal;
    [SerializeField] private string rayo;
    void Start()
    {
        tiempoTrueno = Random.Range(15, 45);
        enTrueno = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoTotal > tiempoTrueno && !enTrueno)
        {
            InicioTrueno();
        }
        else if (!enTrueno)
        {
            tiempoTotal += Time.deltaTime;
        }
    }
    private void InicioTrueno()
    {
        if (Random.Range(1, 3) == 1)
        {
            audioManager.PlaySFX(audioManager.thunder1);
            rayo = "1";
        }
        else
        {
            audioManager.PlaySFX(audioManager.thunder2);
            rayo = "2";
        }
        animator.SetTrigger("activaRayo");
        enTrueno = true;
        StartCoroutine(AfterAnim());
    }
    private IEnumerator AfterAnim()
    {
        yield return new WaitForSeconds(tiempoAnimTotal);
        enTrueno = false;
        tiempoTotal = 0;
        tiempoTrueno = Random.Range(15, 45);
    }

}
