using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
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
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
        Debug.Log("Leading Main Menu");
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
