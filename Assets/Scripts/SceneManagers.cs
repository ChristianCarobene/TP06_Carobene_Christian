using UnityEngine;

public class SceneManagers : MonoBehaviour
{
        
    public void SceneNext(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
