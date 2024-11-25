using TMPro;
using UnityEngine;


public class PlayerVariables : MonoBehaviour
{
    
    [SerializeField] private bool enSalto = false;
    [SerializeField] private bool enSuelo = false;
    [SerializeField] private bool enAtaque = false;
    [SerializeField] private bool inmune = false;
    [SerializeField] private int vida;
    [SerializeField] private int maxVida;
    [SerializeField] private int daño;
    [SerializeField] private int oro;
    [SerializeField] private int score;
    [SerializeField] private int defesa=0;
    [SerializeField] private int tiempoImune=5;
    [SerializeField] private int tiempoFuerza = 10;
    [SerializeField] private Vector2 puntoPlayer;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI textOro;
    [SerializeField] TextMeshProUGUI textVida;
    [SerializeField] TextMeshProUGUI textMaxVida;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] TextMeshProUGUI textDaño;
    [SerializeField] GameObject groupInmune;
    [SerializeField] private InitialPlayerData initialPlayerData;
    public void Start()
    {
        if (PlayerPrefs.HasKey("playerMaxVida"))
        {
            LoadMaxVida();
        }
        else
        {
            setMaxVida((int)initialPlayerData.playerHealth);

        }
        if (PlayerPrefs.HasKey("playerVida"))
        {
            LoadVida();
        }
        else
        {
            setVida((int)initialPlayerData.playerHealth);

        }
        if (PlayerPrefs.HasKey("playerOro"))
        {
            LoadOro();
        }
        else
        {
            setOro((int)initialPlayerData.playerOro);

        }
        if (PlayerPrefs.HasKey("playerScore"))
        {
            LoadScore();
        }
        else
        {
            setScore((int)initialPlayerData.playerScore);

        }
        if (PlayerPrefs.HasKey("playerDaño"))
        {
            LoadDaño();
        }
        else
        {
            setDaño(daño);

        }

    }

    public void setEnSalto(bool valor)
    {
        enSalto = valor;
        animator.SetBool("inicioSalto", valor);
    }
    public bool getEnSalto()
    {
        return enSalto;
    }
    public void setDefensa(int valor)
    {
        defesa = valor;
    }
    public void setInmune(bool valor)
    {
        groupInmune.SetActive(valor);
    }

    public bool getInmune()
    {
        return inmune;
    }
    public int getDefensa()
    {
        return defesa;
    }
    public int getTiempoInmune()
    {
        return tiempoImune;
    }
    public int getTiempoFuerza()
    {
        return tiempoFuerza;
    }
    public void setPuntoPlayer(Vector2 valor)
    {
        puntoPlayer = valor;

    }
    public Vector2 getPuntoPlayer()
    {
        return puntoPlayer;
    }
    public void setEnSuelo(bool valor)
    {
        enSuelo = valor;
        animator.SetBool("enSuelo", valor);
    }
    public bool getEnSuelo()
    {
        return enSuelo;

    }
    public void setEnAtaque(bool valor)
    {
        enAtaque = valor;
        animator.SetBool("enAtaque", valor);
    }
    public bool getEnAtaque()
    {
        return enAtaque;

    }
    public void setMovimientoHorizontal(float valor)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(valor));
    }
    public float getMovimientoHorizontal()
    {
        return animator.GetFloat("Horizontal");
    }
    public void setVida(int valor)
    {
        if(valor <= maxVida)
        animator.SetInteger("Vida", valor);
        vida = valor;
        textVida.text = vida.ToString("00");
        PlayerPrefs.SetInt("PlayerVida", vida);
    }
    public int getVida()
    {
        return vida;
    }
    public void setMaxVida(int valor)
    {
        maxVida = valor;
        textMaxVida.text = maxVida.ToString("00");
        PlayerPrefs.SetInt("PlayerMaxVida", maxVida);
    }
    public int getMaxVida()
    {
        return maxVida;
    }
    public void setOro(int valor)
    {

        oro = valor;
        textOro.text = oro.ToString("0000");
        PlayerPrefs.SetInt("PlayerOro", oro);

    }
    public int getOro()
    {
        return oro;
    }
    public void setScore(int valor)
    {
        score = valor;
        textScore.text = score.ToString("0000");
        PlayerPrefs.SetInt("PlayerScore", score);
    }
    public int getScore()
    {
        return score;
    }
    public void setDaño(int valor)
    {
        daño = valor;
        textDaño.text = daño.ToString("0000");
        PlayerPrefs.SetInt("PlayerDaño", daño);
    }
    public int getDaño()
    {
        return daño;
    }
    private void LoadMaxVida()
    {
        maxVida = PlayerPrefs.GetInt("playerMaxVida");

    }
    private void LoadVida()
    {
        vida = PlayerPrefs.GetInt("playerVida");

    }

    private void LoadOro()
    {
        oro = PlayerPrefs.GetInt("playerOro");

    }
    private void LoadScore()
    {
        score = PlayerPrefs.GetInt("playerScore");

    }
    private void LoadDaño()
    {
        daño = PlayerPrefs.GetInt("playerDaño");

    }



}
