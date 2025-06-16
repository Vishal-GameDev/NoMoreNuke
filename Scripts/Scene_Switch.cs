using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Transition Settings")]
    public int nextSceneIndex = 1; // Scene to load
    public float sceneChangeDelay = 5f; // Delay before scene change

    private bool sceneLoaded = false; // Prevents multiple triggers

    void Start()
    {
        // Start the coroutine to load scene after a delay
        Invoke("LoadNextScene", sceneChangeDelay);
    }

    public void OnTimelineEnd()
    {
        if (!sceneLoaded)
        {
            sceneLoaded = true;
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (!sceneLoaded && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            sceneLoaded = true;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Scene index out of range or scene already loaded.");
        }
    }
}
