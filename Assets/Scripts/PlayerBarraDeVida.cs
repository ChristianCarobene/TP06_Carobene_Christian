using UnityEngine;
using UnityEngine.UI;

public class PlayerBarraDeVida : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
       
    }

    public void CambiarVidaMaxima(float maxVida)
    {
        slider.maxValue = maxVida;
    }
    public void CambiarVida(float vida)
    {
        slider.value = vida;
    }
    public void InicializarBarraDeVida(float vida)
    {
        CambiarVidaMaxima(vida);    
        CambiarVida(vida);    
    }
}
