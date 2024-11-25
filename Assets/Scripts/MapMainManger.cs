using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapMainManger : MonoBehaviour
{
    [Header("GUI Buttons")]
    [SerializeField] private Button caveButton;
    [SerializeField] private Button townButton;
    [SerializeField] private Button forestButton;
    [SerializeField] private Button exitButton;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    [Header("Canvas Manager")]
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject settingsPanel;
    private bool isPaused = false;
    [Header("Scene Manager")]
    [SerializeField] private string caveScene;
    [SerializeField] private string townScene;
    [SerializeField] private string forestScene;
    [SerializeField] private string exitScene;
    [SerializeField] private SceneManagers sceneManagers;


    private void Awake()
    {
        caveButton.onClick.AddListener(OnCaveButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        townButton.onClick.AddListener(OnTownButtonClicked);
        forestButton.onClick.AddListener(OnForestButtonClicked);


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
         {
             canvasPanel.SetActive(!canvasPanel.activeSelf);
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            if (!isPaused)
            {
                audioManager.PlayGUI(audioManager.pause);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                audioManager.PlayGUI(audioManager.unpause);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element. " + eventData);
    }


    private void OnDestroy()
    {
        caveButton.onClick.RemoveAllListeners();
        townButton.onClick.RemoveAllListeners();
        forestButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    private void OnCaveButtonClicked()
    {
        sceneManagers.SceneNext(caveScene);
    }

    private void OnForestButtonClicked()
    {
        sceneManagers.SceneNext(forestScene);
    }
    private void OnTownButtonClicked()
    {
        sceneManagers.SceneNext(townScene);
    }


    private void OnExitButtonClicked()
    {
        sceneManagers.SceneNext(exitScene);
    }


}

