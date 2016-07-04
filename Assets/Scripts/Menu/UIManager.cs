using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Manages the highlighted creature and displays them.
/// </summary>
public class UIManager : MonoBehaviour
{

    [SerializeField]private GameObject breedingWindow;

    [SerializeField]private GameObject breedingContent;

    [SerializeField]private GameObject managmentContent;

    private GameObject[] displayObjects;

    [SerializeField] private StoreManager storeManager;

    private List<Image> images = new List<Image>(10);

    private Color originalColor;
    
    [SerializeField] private Color selectedItemColor = Color.blue;

    [SerializeField]private Sprite uiMask;

    private Image[] creatureDisplays;

    [SerializeField] private CreaturePrefabManager currentSelectedItem;

    public CreaturePrefabManager CurrentSelectedItem 
    {
        get { return currentSelectedItem; }
        private set
        {
            currentSelectedItem = value;
        }
    }

    private bool breedingWindowIsOpen = false;
    public bool BreedingWindowIsOpen
    {
        get { return breedingWindowIsOpen; }
    }

    public void ShowBreedingWindow()
    {
        ShowBreedingWindow(!breedingWindowIsOpen);
    }

    public void ShowBreedingWindow(bool state)
    {
        breedingWindowIsOpen = state;
        breedingWindow.SetActive(breedingWindowIsOpen);
    }

    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
        breedingWindow.SetActive(breedingWindowIsOpen);
    }


    void Start()
    {
        displayObjects = GameObject.FindGameObjectsWithTag("CreatureWindow");
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
        if (theImage != null)
        {
            CurrentSelectedItem = theImage.transform.parent.parent.GetComponent<CreaturePrefabManager>();
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
        ShowBreedingWindow(false);
    }


    private void SetTheColor(Image theImage)
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i] == null)
            {
                images.RemoveAt(i);
            }
            if (i <images.Count)
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


    public void CanIMoveCreatureToBreeding(GameObject theCreature)
    {
        //Get creature and the breeding script
        var creature = PlayerInventory.Instance.GetCreatureByUniqueID(theCreature.GetComponent<CreaturePrefabManager>().UniqueID);
        var breeding = breedingContent.GetComponent<Breeding>();

        //stores a backend reference in breeding
        var shouldIMoveCreature = breeding.AddCreatureToBreedingHold(creature);
        if (shouldIMoveCreature)
            theCreature.transform.SetParent(breedingContent.transform);
    }

    public void MoveBreedingContentToManagment()
    {
        //Get all children in breedingcontent Gameobject and move them to managment
        foreach (var child in breedingContent.transform.GetComponentsInChildren<CreaturePrefabManager>())
        {
            child.transform.SetParent(managmentContent.transform);
        }
    }
}