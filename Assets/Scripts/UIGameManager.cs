using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    [Header("Audio Manager")]
    [SerializeField] private AudioManager audioManager;
    [Header("Canvas Manager")]
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject settingsPanel;
    private bool isPaused = false;
    [Header("Scene Manager")]
    [SerializeField] public string gameovertScene; 
    [SerializeField] public string winScene;
    [SerializeField] public SceneManagers sceneManagers;

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

   


}

