using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private string interactText = "You can interact with certain objects by targeting them and pressing \"E\"";
    [SerializeField] private string lockedText = "This door requires a key card to enter";

    private TextMeshProUGUI tutorialText;
    private Animator textAnim;

    // Start is called before the first frame update
    void Start()
    {
        textAnim = GetComponent<Animator>();
        tutorialText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
