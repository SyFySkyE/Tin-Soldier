using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseController : MonoBehaviour
{
    private static PauseController instance;
    public static PauseController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PauseController>();
            }
            return instance;
        }
    }

    private static bool isPaused = false;

    public static event System.Action<bool> OnPause;

    public static void Pause()
    {
        isPaused = !isPaused;
        OnPause(isPaused);
        if (isPaused)
        {             
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }    
}
