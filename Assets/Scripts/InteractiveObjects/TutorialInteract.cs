using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : MonoBehaviour 
{
    [SerializeField] private Tutorials tutorialToShow;
    private InteractiveObject interactiveObjToListen;

    private void Start()
    {
        interactiveObjToListen = GetComponent<InteractiveObject>();
        interactiveObjToListen.OnInteract += InteractiveObjToListen_OnInteract;
    }

    private void InteractiveObjToListen_OnInteract()
    {
        TutorialText.Instance.PlayTutorialText(tutorialToShow);
    }
}
