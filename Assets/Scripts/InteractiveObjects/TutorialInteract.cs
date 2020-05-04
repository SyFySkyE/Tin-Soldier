using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : InteractiveObject
{
    [SerializeField] private Tutorials tutorialToShow;

    public override void Interact()
    {
        TutorialText.Instance.PlayTutorialText(tutorialToShow);
    }
}
