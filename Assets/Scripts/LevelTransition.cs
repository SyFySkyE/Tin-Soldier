using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private bool loadPreviousLevel;
    private GameSceneManager sceneManager;
    private Animator levelAnim;

    public static event System.Action OnLevelEnd;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<GameSceneManager>();
        levelAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLevelEnd?.Invoke();
            if (loadPreviousLevel)
            {
                levelAnim.SetTrigger("PreviousLevel");
            }
            else
            {
                levelAnim.SetTrigger("EndLevel");
            }            
        }
    }

    public void LoadNextLevel() // To be used by anim
    {
        sceneManager.LoadNextScene();
    }

    public void LoadPreviousLevel() // To be used by anim
    {
        sceneManager.LoadPreviousScene();
    }
}
