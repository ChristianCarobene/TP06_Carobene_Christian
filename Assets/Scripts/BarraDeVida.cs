using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image barraImagen;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateBarraDeVida(float maxVida, float vida)
    {
        barraImagen.fillAmount = vida/maxVida;

    }
}
