using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    [Header("What tutorial to show on trigger")]
    [SerializeField] private Tutorials tutorialToShow;
    [SerializeField] private bool showAgain;
    [SerializeField] private bool firstTutorial;
    [SerializeField] private float secondsBeforeShowNextTutorial;

    private void Start()
    {
        if (firstTutorial)
        {
            SendTutorial();
            StartCoroutine(StartInteractTutorial());
        }
    }

    private IEnumerator StartInteractTutorial()
    {
        yield return new WaitForSeconds(secondsBeforeShowNextTutorial);
        this.tutorialToShow = Tutorials.Interact;
        SendTutorial();
    }

    private void SendTutorial()
    {
        TutorialText.Instance.PlayTutorialText(tutorialToShow);
        if (!showAgain && !firstTutorial)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SendTutorial();
        }
    }
}
