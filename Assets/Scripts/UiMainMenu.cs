using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("GUI Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    [Header("Canvas Manager")]
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [Header("Scene Manager")]
    [SerializeField] private string playScene;
    [SerializeField] private SceneManagers sceneManagers;


    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);


    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Escape))
         {
             canvasPanel.SetActive(!canvasPanel.activeSelf);


         }*/

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element. " + eventData);
    }


    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }


    private void OnPlayButtonClicked()
    {
        sceneManagers.SceneNext(playScene);
    }

    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }
    private void OnCreditsButtonClicked()
    {
        creditsPanel.SetActive(true);
        buttonsPanel.SetActive(false);

    }


    private void OnExitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    

}

