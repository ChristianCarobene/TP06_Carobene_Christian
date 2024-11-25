using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExitManager : MonoBehaviour
{
    [SerializeField] private UIGameManager uIGameManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        uIGameManager.sceneManagers.SceneNext(uIGameManager.gameovertScene);
    }
}
