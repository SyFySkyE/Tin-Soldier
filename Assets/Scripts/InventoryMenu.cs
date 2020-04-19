using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenuItemTogglePrefab;
    [SerializeField] private Transform inventoryContentTransform;
    [Header("UI Text Display")]
    [SerializeField] private TMPro.TextMeshProUGUI itemNameText;
    [SerializeField] private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField] private string defaultObjectNameText = "Viewfinder v2.1a";
    [SerializeField] private string defaultObjectDescription = "Collected objects will appear on the left. Select one to examine closely.";
    private AudioSource canvasInventoryAudioSource;
    private CanvasGroup canvasGroup;
    private FirstPersonController player;
    private Animator inventoryAnim;    
    private static InventoryMenu instance;
    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("Scene is missing an inventory menu!");
            }
            return instance;
        }
        private set { instance = value; }
    }
    private bool isMenuOpen = false;

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += InventoryMenuItemToggle_InventoryMenuItemSelected;
    }

    private void Awake()
    {        
        if (instance == null)
            instance = this;
        else
        {
            this.enabled = false;
            Debug.LogError($"More than one inventory menu is in the scene. Disabling: {this.gameObject.name}");
        }

        canvasGroup = GetComponent<CanvasGroup>();        
        inventoryAnim = GetComponent<Animator>();
        player = FindObjectOfType<FirstPersonController>();
        canvasInventoryAudioSource = GetComponent<AudioSource>();        
    }

    private void InventoryMenuItemToggle_InventoryMenuItemSelected(InventoryObject selectedInventoryObject)
    {
        itemNameText.text = selectedInventoryObject.ObjectText;
        descriptionText.text = selectedInventoryObject.Description;
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void ToggleMenu()
    {
        canvasInventoryAudioSource.Play();
        isMenuOpen = !isMenuOpen;
        player.enabled = !player.enabled;
        Cursor.visible = !Cursor.visible;
        this.descriptionText.text = defaultObjectDescription;
        this.itemNameText.text = defaultObjectNameText;
        ToggleMouse();
        inventoryAnim.SetBool("MenuOpen", isMenuOpen);
    }

    private void ExitMenu()
    {
        if (isMenuOpen)
        {
            player.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isMenuOpen = false;
            inventoryAnim.SetBool("MenuOpen", isMenuOpen);
            canvasInventoryAudioSource.Play();
        }
    }

    private void ToggleMouse()
    {
        switch (isMenuOpen)
        {
            case true:
                Cursor.lockState = CursorLockMode.None;
                break;
            case false:
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("OpenInventory"))
        {
            ToggleMenu();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            ExitMenu();
        }
    }

    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject menuItem = Instantiate(inventoryMenuItemTogglePrefab, inventoryContentTransform);
        InventoryMenuItemToggle toggle = menuItem.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;        
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= InventoryMenuItemToggle_InventoryMenuItemSelected;
    }
}
