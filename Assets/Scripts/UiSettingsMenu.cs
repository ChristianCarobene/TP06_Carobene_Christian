using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UiSettingsMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject referencePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider GUISlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        if(PlayerPrefs.HasKey("masterVolume"))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
            
        }
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();

        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();

        }
        if (PlayerPrefs.HasKey("GUIVolume"))
        {
            LoadGUIVolume();
        }
        else
        {
            SetGUIVolume();

        }

    }
    private void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        masterSlider.onValueChanged.AddListener(OnMasterSliderChange);
        musicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        SFXSlider.onValueChanged.AddListener(OnSFXSliderChange);
        GUISlider.onValueChanged.AddListener(OnGUISliderChange);
    }
    private void OnDestroy()
    {
        backButton.onClick.RemoveAllListeners();
        masterSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.RemoveAllListeners();
        GUISlider.onValueChanged.RemoveAllListeners();
    }


    private void OnBackButtonClicked()
    {
        referencePanel.SetActive(false);
        pausePanel.SetActive(true);

        
    }
    private void OnMasterSliderChange(float newValue)
    {
        SetMasterVolume();
        SetMusicVolume(masterSlider.value);
        SetSFXVolume(masterSlider.value);
        SetGUIVolume(masterSlider.value);
    }
    private void OnMusicSliderChange(float newValue)
    {
        SetMusicVolume();
    }
    private void OnSFXSliderChange(float newValue)
    {
        SetSFXVolume();
    }
    private void OnGUISliderChange(float newValue)
    {
        SetGUIVolume();
    }


    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);

    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicSlider.value= volume ;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXSlider.value = volume;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetGUIVolume()
    {
        float volume = GUISlider.value;
        audioMixer.SetFloat("GUI", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("GUIVolume", volume);
    }
    public void SetGUIVolume(float volume)
    {
        GUISlider.value = volume;
        audioMixer.SetFloat("GUI", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("GUIVolume", volume);
    }
    private void LoadMasterVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
      
    }
    private void LoadMusicVolume()
    {
                musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        
    }
    private void LoadSFXVolume()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
    }
    private void LoadGUIVolume()
    {
        GUISlider.value = PlayerPrefs.GetFloat("GUIVolume");
    }
}