using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static event System.Action<int> OnSceneLoad; // Gotta send an int over due to GetSceneIndex returning the old index

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Game Scene Manager attempted to load a scene index greater than the ones avaliable. Reloading first scene...");
            SceneManager.LoadScene(0);
        }
        else
        {
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);            
            OnSceneLoad?.Invoke(currentSceneIndex);
        }
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex - 1 < 0)
        {
            Debug.LogWarning("Game Scene Manager attempted to load a scene index greater than the ones avaliable. Reloading first scene...");
            SceneManager.LoadScene(0);
        }
        else
        {
            currentSceneIndex--;
            SceneManager.LoadScene(currentSceneIndex);
            OnSceneLoad?.Invoke(currentSceneIndex);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(0); // TODO spice up?
#endif
    }
}
