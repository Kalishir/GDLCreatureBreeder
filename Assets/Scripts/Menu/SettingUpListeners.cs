﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

/// <summary>
/// Sets up listeners for the store buttons of creatures
/// </summary>

public class SettingUpListeners : MonoBehaviour
{

    public HolderOfThings holder;

    private PointerUIHelper uiHelper;

	void Start ()
	{
	    uiHelper = GetComponent<PointerUIHelper>();
	    UIManager theManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();


        //Sets up the button to make the button selected when clicked
	    uiHelper.onPointerClick.AddListener(() => theManager.ItemSelected(holder.creatureBackground));
        //sets up the button to show the creature on the big display when clicked
        uiHelper.onPointerClick.AddListener(() => theManager.ShowCreatureOnDisplay(holder.creatureImage.sprite));
    }
}
