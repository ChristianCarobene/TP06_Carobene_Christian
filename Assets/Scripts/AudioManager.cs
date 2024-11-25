using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource GUISource;

    [Header("Audio Clip Music")]
    public AudioClip background;
    [Header("Audio Clip SFX")]
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip playerDamage;
    public AudioClip playerBufVida;
    public AudioClip playerBufDaño;
    public AudioClip playerBufDefensa;
    public AudioClip playerBufMaxVida;
    public AudioClip playerDefBuf;
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip snailHit;
    public AudioClip snailDie;
    public AudioClip thunder1;
    public AudioClip thunder2;
    [Header("Audio Clip GUI")]
    public AudioClip clic;
    public AudioClip hover;
    public AudioClip pause;
    public AudioClip unpause;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

    }
    public void PlayGUI(AudioClip clip)
    {
        GUISource.PlayOneShot(clip);

    }
}