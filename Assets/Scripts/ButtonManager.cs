
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnButtonPointer()
    {
        audioManager.PlayGUI(audioManager.hover);

    }
    public void OnButtonClick()
    {
        audioManager.PlayGUI(audioManager.clic);

    }


}
