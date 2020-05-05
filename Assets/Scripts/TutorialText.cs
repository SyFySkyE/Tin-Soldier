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
    Energy
}

public class TutorialText : MonoBehaviour
{
    [SerializeField] private string moveText = "You can walk using WASD";
    [SerializeField] private string interactText = "You can interact with certain objects by targeting them and pressing \"E\"";
    [SerializeField] private string readText = "Press \"E\" again to stop reading";
    [SerializeField] private string inventoryText = "Access your internal inventory by pressing \"Tab\" or \"I\"";
    [SerializeField] private string exitInventoryText = "Exit by pressing \"Tab\" or \"I\" again";
    [SerializeField] private string sprintText = "Hold down \"Left Shift\" to sprint";
    [SerializeField] private string lockedText = "You need to find a badge with elevated privileges to open this door.";
    [SerializeField] private string jetpackText = "You've equipped a jetpack. Press Space to jump, and hold space while jumping to ascend.";
    [SerializeField] private string energyUsageText = "Your jetpack energy is represented by a meter. If it empties, you will fall. It recharges when not in use.";

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
                tutorialText.text = interactText;
                break;
            case Tutorials.Inventory:
                tutorialText.text = inventoryText;
                break;
            case Tutorials.Read:
                tutorialText.text = readText;
                break;
            case Tutorials.ExitInventory:
                tutorialText.text = exitInventoryText;
                break;
            case Tutorials.Sprint:
                tutorialText.text = sprintText;
                break;
            case Tutorials.Jetpack:
                tutorialText.text = jetpackText;
                break;
            case Tutorials.LockedDoor:
                tutorialText.text = lockedText;
                break;
            case Tutorials.Move:
                tutorialText.text = moveText;
                break;
            case Tutorials.Energy:
                tutorialText.text = energyUsageText;
                break;
        }
        textAnim.SetTrigger("Tutorial");
    }
}
