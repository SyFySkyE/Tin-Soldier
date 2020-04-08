using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseController : MonoBehaviour
{
    private FirstPersonController player;
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

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

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
