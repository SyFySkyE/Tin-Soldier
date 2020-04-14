using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    private GameSceneManager sceneManagement;
    private Animator menuAnimator;
    [Header("SFX to play on each button click")]
    [SerializeField] private AudioClip sfxClick;
    [SerializeField] private float sfxVolume = 0.7f;
    private AudioSource menuAudioSource;

    private void Start()
    {
        menuAudioSource = GetComponent<AudioSource>();
        sceneManagement = FindObjectOfType<GameSceneManager>();
        menuAnimator = GetComponent<Animator>();
    }

    private void PlayButtonSfx()
    {
        menuAudioSource.PlayOneShot(sfxClick, sfxVolume); 
    }

    public void OnCreditsPressed()
    {
        PlayButtonSfx();
        menuAnimator.SetBool("Credits", true);
    }

    public void OnCreditsBack()
    {
        PlayButtonSfx();
        menuAnimator.SetBool("Credits", false);
    }

    public void OnPlayPress()
    {
        PlayButtonSfx();
        menuAnimator.SetTrigger("Play");
    }

    public void OnQuitPressed()
    {
        PlayButtonSfx();
        menuAnimator.SetTrigger("Quit");
    }

    public void Quit() // Activated via animation event
    {
        sceneManagement.Quit();
    }

    public void StartGame() // Activated via animation event
    {
        sceneManagement.LoadNextScene();
    }
}
