using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRead : MonoBehaviour
{
    [Header("Where the article picture will fill")]
    [SerializeField] private UnityEngine.UI.Image articleImageToFill;

    private ReadInteractive[] readableObjectsInScene;

    private UnityEngine.UI.Image sprite;
    private bool isReading = false;

    // Start is called before the first frame update
    void Start()
    {
        readableObjectsInScene = FindObjectsOfType<ReadInteractive>();
        articleImageToFill.gameObject.SetActive(false);
        sprite = GetComponent<UnityEngine.UI.Image>();
        foreach (var item in readableObjectsInScene)
        {
            item.OnImageRead += Item_OnImageRead;
        }
    }

    private void Item_OnImageRead(Sprite obj)
    {
        this.sprite.enabled = true;
        articleImageToFill.gameObject.SetActive(true);
        articleImageToFill.sprite = obj;
        isReading = true;
        PauseController.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReading)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                this.sprite.enabled = false;
                articleImageToFill.gameObject.SetActive(false);
                isReading = false;
            }
            else if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Interact")) // TODO When player tries to press Interact again, since the player is usually looking at the object, they end up reading it again
            {
                PauseController.Pause();
                this.sprite.enabled = false;
                articleImageToFill.gameObject.SetActive(false);                
                isReading = false;
            }
        }
    }    
}
