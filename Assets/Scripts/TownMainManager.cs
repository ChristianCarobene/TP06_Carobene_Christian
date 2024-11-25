using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TownMainManager : MonoBehaviour
{
    [Header("GUI Buttons")]
    [SerializeField] private Button exitButton;
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    [Header("Canvas Manager")]
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject settingsPanel;
    private bool isPaused = false;
    [Header("Scene Manager")]
    [SerializeField] private string exitScene;
    [SerializeField] private SceneManagers sceneManagers;


    private void Awake()
    {
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

    private void OnDestroy()
    {
        exitButton.onClick.RemoveAllListeners();
    }
    private void OnExitButtonClicked()
    {
        sceneManagers.SceneNext(exitScene);
    }


}

