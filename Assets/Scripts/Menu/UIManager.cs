﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Manages the highlighted creature and displays them.
/// </summary>
public class UIManager : MonoBehaviour {

    private List<Image> images = new List<Image>(10);

    private Color originalColor;
    [SerializeField]
    private Color selectedItemColor = Color.blue;

    [SerializeField]
    private Sprite uiMask;

    private Image[] creatureDisplays;

    void Start()
    {
        var displayObjects = GameObject.FindGameObjectsWithTag("CreatureWindow");
        creatureDisplays = new Image[displayObjects.Length];
        for (int i = 0; i < displayObjects.Length; i++)
        {
            creatureDisplays[i] = displayObjects[i].GetComponent<Image>();
        }
    }

    public void ItemSelected(Image theImage)
    {
        //First check if an image like the one we got. actually exists
        bool exists = false;
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i] == theImage)
            {
                exists = true;
            }
        }
        if (exists == false)
        {
            images.Add(theImage);
            originalColor = theImage.color;
        }

        SetTheColor(theImage);
    }

    public void ShowCreatureOnDisplay(Sprite creatureSprite)
    {
        for (int i = 0; i < creatureDisplays.Length; i++)
        {
            if (creatureSprite == null)
                creatureDisplays[i].sprite = null;
            creatureDisplays[i].sprite = creatureSprite;
        }
        
    }

    public void ClearSelection()
    {
        ShowCreatureOnDisplay(uiMask);
        SetTheColor(null);
    }


    private void SetTheColor(Image theImage)
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i] == theImage)
                theImage.color = selectedItemColor;
            else
            {
                images[i].color = originalColor;
            }
        }
    }
}