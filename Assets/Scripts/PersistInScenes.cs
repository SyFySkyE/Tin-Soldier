using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistInScenes : MonoBehaviour
{
    [Header("Scene indexes to persist in")]
    [SerializeField] private int[] sceneIndexesToPersist;
    private GameSceneManager sceneManage;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        sceneManage = FindObjectOfType<GameSceneManager>();
        GameSceneManager.OnSceneLoad += GameSceneManager_OnSceneLoad;
    }

    private void GameSceneManager_OnSceneLoad(int sceneIndex)
    {
        foreach (int index in sceneIndexesToPersist)
        {
            if (index == sceneIndex)
            {
                return;
            }
        }
        Destroy(this.gameObject); // If we get this far, we're not supposed to be here
    }

    private void OnDisable()
    {
        GameSceneManager.OnSceneLoad -= GameSceneManager_OnSceneLoad;
    }
}
