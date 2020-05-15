using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Tutorials
{
    Interact,
    Read,
    Inventory,
    ExitInventory,
    Sprint,
    LockedDoor,
    Jetpack,
    Move,
    Energy,
    Bed
}

public class TutorialText : MonoBehaviour
{
    [Header("What the UI Tutorial Text Will Show")]
    [Tooltip("Since we have to \"fill in\" the buttons used via script/project settings, some strings are broken up")]
    [SerializeField] private string moveText = "You can walk using ";
    [SerializeField] private string interactText = "You can interact with certain objects by targeting them and pressing ";
    [SerializeField] private string readText = "Press ";
    [SerializeField] private string readTextTwo = " again to stop reading";
    [SerializeField] private string inventoryText = "Access your internal inventory by pressing ";
    [SerializeField] private string exitInventoryText = "Exit by pressing ";
    [SerializeField] private string exitInventoryTextTwo = " again";
    [SerializeField] private string sprintText = "Hold down ";
    [SerializeField] private string sprintTextTwo = " to sprint";
    [SerializeField] private string lockedText = "You need to find a badge with elevated privileges to open this door.";
    [SerializeField] private string jetpackText = "You've equipped a jetpack. Press ";
    [SerializeField] private string jetpackTextTwo = " to jump, and hold ";
    [SerializeField] private string jetpackTextThree = " while jumping to ascend.";
    [SerializeField] private string energyUsageText = "Your jetpack energy is represented by a meter. If it empties, you will fall. It recharges when not in use.";
    [SerializeField] private string bedText = "Go back to bed";

    [SerializeField] private bool showInventoryTutorial;
    private TextMeshProUGUI tutorialText;
    private Animator textAnim;
    private bool hasOpenedInventory;    

    public static TutorialText Instance
    {
        get
        {
            return instance;
        }
    }
    private static TutorialText instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
        hasOpenedInventory = false;
        InventoryMenu.OnUseInventory += InventoryMenu_OnUseInventory;
        textAnim = GetComponent<Animator>();
        tutorialText = GetComponent<TextMeshProUGUI>();
    }

    private void InventoryMenu_OnUseInventory()
    {
        if (!hasOpenedInventory)
        {
            hasOpenedInventory = true;
            PlayTutorialText(Tutorials.ExitInventory);
        }
    }

    public void PlayTutorialText(Tutorials tutorialToPlay)
    {
        switch (tutorialToPlay)
        {
            case Tutorials.Interact:
                tutorialText.text = interactText + "<color=orange>E</color>";
                break;
            case Tutorials.Inventory:
                tutorialText.text = inventoryText + "<color=orange>Tab</color> or <color=orange>I</color>";
                break;
            case Tutorials.Read:
                tutorialText.text = readText + "<color=orange>E</color>" + readTextTwo;
                break;
            case Tutorials.ExitInventory:
                tutorialText.text = exitInventoryText + "<color=orange>Tab</color> or <color=orange>I</color>" + exitInventoryTextTwo;
                break;
            case Tutorials.Sprint:
                tutorialText.text = sprintText + "<color=orange>Shift</color>" + sprintTextTwo;
                break;
            case Tutorials.Jetpack:
                tutorialText.text = jetpackText + "<color=orange>Space</color>" + jetpackTextTwo + "<color=orange>Space</color>" + jetpackTextThree;
                break;
            case Tutorials.LockedDoor:
                tutorialText.text = lockedText;
                break;
            case Tutorials.Move:
                tutorialText.text = moveText + "<color=orange>WASD</color>";
                break;
            case Tutorials.Energy:
                tutorialText.text = energyUsageText;
                break;
            case Tutorials.Bed:
                tutorialText.text = bedText;
                break;
        }
        if (textAnim != null)
            textAnim.SetTrigger("Tutorial");
    }
}
