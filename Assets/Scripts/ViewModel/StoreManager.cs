using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private int creatureCount;
    [SerializeField] private GameObject StoreListFrame;
    [SerializeField] private CreatureList creatureList;
    //[SerializeField] private GameObject selectedFrame;

    private Dictionary<Creature, GameObject> UIPanelDictionary;

    private UIManager uiManager;

    // Use this for initialization
    void Start()
    {
        creatureList = new CreatureList();
        UIPanelDictionary = new Dictionary<Creature, GameObject>();
        PopulateStore(creatureList);
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        while (creatureList.Creatures.Count < creatureCount)
        {
            CreatureData newCreature = CreatureManager.Manager.GetRandomCreature();
            Creature creature = new Creature(newCreature);
            creatureList.AddCreature(creature);
            GameObject newCreaturePanel = GetCreaturePanel(creature);
            newCreaturePanel.transform.SetParent(StoreListFrame.transform, false);
        }
    }


    private void PopulateStore(CreatureList list)
    {
        if (list.Creatures.Count < creatureCount)
        {
            //Fill the list with random creatures of the type we want
            for (int i = 0; i < creatureCount; i++)
            {
                list.AddCreature(CreatureManager.Manager.GetRandomCreature());
            }
            
        }

        foreach (var creature in creatureList.Creatures)
        {
            GameObject newCreaturePanel = GetCreaturePanel(creature);
            newCreaturePanel.transform.SetParent(StoreListFrame.transform, false);
        }
    }

    private GameObject CreateCreaturePanel(Creature creature)
    {
        if (creaturePrefab == null)
            return null;

        GameObject newCreature = GameObject.Instantiate(creaturePrefab);
        var prefabManager = newCreature.GetComponent<CreaturePrefabManager>();
        prefabManager.Initialize(creature);

        UIPanelDictionary.Add(creature, newCreature);
        return newCreature;
    }

    public GameObject GetCreaturePanel(Creature creature)
    {
        if (UIPanelDictionary.ContainsKey(creature))
        {
            return UIPanelDictionary[creature];
        }
        else
        {
            return CreateCreaturePanel(creature);
        }
    }

    public Creature GetCreatureByUniqueID(string id)
    {
        var theCreature = GetCreature(id);
        return theCreature;
    }

    public void DeleteCreatureByUniqueID(string id)
    {
        var theCreature = GetCreature(id);
        if (theCreature != null)
            creatureList.RemoveCreature(theCreature);
    }

    private Creature GetCreature(string id)
    {
        //Go Through the creature list and if it finds a match. return it
        for (int i = 0; i < creatureList.Creatures.Count; i++)
        {
            if (creatureList.Creatures[i].ID == id)
            {
                return creatureList.Creatures[i];
            }
        }
        return null;
    }

    public void BuySelectedCreature()
    {
        if (uiManager.CurrentSelectedItem != null)
        {
            var theCreature = GetCreatureByUniqueID(uiManager.CurrentSelectedItem.UniqueID);

            //Checks if we can afford this creature. takes away the money if we can.
            if (PlayerMoney.Instance.CheckIfWeCanPayForThisCreatureIfSoBuyIt(theCreature.CurrentValue))
            {
                PlayerInventory.Instance.AddCreatureToInventory(theCreature);

                creatureList.RemoveCreature(theCreature);
                uiManager.ClearSelection();
                //Destroys the gameobjects inside the store content
                Destroy(uiManager.CurrentSelectedItem.gameObject);
            }
        }
    }
}