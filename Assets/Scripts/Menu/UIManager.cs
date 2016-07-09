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

    private UpdateInt healthObject;

    private UpdateInt horninessObject;

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

    private void ItemSelected(Image theImage)
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

    public void ChangeScreens(GameObject newScreen)
    {
        UnsubscribeEvents();
        ClearSelection();

        healthObject = newScreen.transform.Find("Content/DisplayPane/CreatureWindow/Health").GetComponent<UpdateInt>();
        horninessObject = newScreen.transform.Find("Content/DisplayPane/CreatureWindow/Horniness").GetComponent<UpdateInt>();
    }

    public void UpdateSelectedItem(CreaturePrefabManager creaturePrefabManager)
    {
        ItemSelected(creaturePrefabManager.CreatureBackground);
        ShowCreatureOnDisplay(creaturePrefabManager.CreatureImage.sprite);

        UnsubscribeEvents();
        CurrentSelectedItem = creaturePrefabManager;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        if (currentSelectedItem == null)
            return;
        if (healthObject == null)
            return;
        if (horninessObject == null)
            return;


        Creature currentCreature = GetCreatureByGUID(CurrentSelectedItem.UniqueID);
        healthObject.UpdateValue(currentCreature.Health);
        horninessObject.UpdateValue(currentCreature.Horniness);
        currentCreature.HealthChanged += healthObject.UpdateValue;
        currentCreature.HorninessChanged += horninessObject.UpdateValue;
    }

    private void UnsubscribeEvents()
    {
        if (currentSelectedItem == null)
            return;
        if (healthObject == null)
            return;
        if (horninessObject == null)
            return;

        Creature currentCreature = GetCreatureByGUID(CurrentSelectedItem.UniqueID);
        currentCreature.HealthChanged -= healthObject.UpdateValue;
        currentCreature.HorninessChanged -= horninessObject.UpdateValue;
    }

    private Creature GetCreatureByGUID(string guid)
    {
        Creature creature = null;

        creature = PlayerInventory.Instance.GetCreatureByUniqueID(guid);
        if (creature == null)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("StoreManager");
            foreach (var go in gos)
            {
                creature = go.GetComponent<StoreManager>().GetCreatureByUniqueID(guid);
                if (creature != null)
                    break;
            }
        }
        return creature;
    }

    private void ShowCreatureOnDisplay(Sprite creatureSprite)
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