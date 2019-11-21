using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;

    internal int CurrentSceneIndex 
    {
        get => currentSceneIndex;
        private set 
        {
            if (value <= -1)
            {
                value = 0;
            }
            currentSceneIndex = value; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
