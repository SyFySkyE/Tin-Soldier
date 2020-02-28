using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneHopper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG

        if (Input.GetKeyDown(KeyCode.N))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(currentSceneIndex);
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            if (currentSceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning("Debug Scene Hopper attempted to load a scene index greater than the ones avaliable. Reloading first scene...");
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Loading Next Scene...");
                SceneManager.LoadScene(currentSceneIndex + 1);
            }            
        }
#endif
    }
}
