﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRead : MonoBehaviour
{
    [Header("Where the article picture will fill")]
    [SerializeField] private UnityEngine.UI.Image articleImageToFill;

    private ReadInteractive[] readableObjectsInScene;

    private UnityEngine.UI.Image sprite;

    // Start is called before the first frame update
    void Start()
    {
        readableObjectsInScene = FindObjectsOfType<ReadInteractive>();
        articleImageToFill.gameObject.SetActive(false);
        sprite = GetComponent<UnityEngine.UI.Image>();
        foreach (var item in readableObjectsInScene)
        {
            item.OnImageRead += Item_OnImageRead;
            item.OnCancelRead += Item_OnCancelRead;
        }
    }

    private void Item_OnCancelRead()
    {
        this.sprite.enabled = false;
        articleImageToFill.gameObject.SetActive(false);        
    }

    private void Item_OnImageRead(Sprite obj)
    {
        this.sprite.enabled = true;
        articleImageToFill.gameObject.SetActive(true);
        articleImageToFill.sprite = obj;        
    }
}
