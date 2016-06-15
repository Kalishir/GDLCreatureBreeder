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

    // Use this for initialization
    void Start()
    {
        creatureList = new CreatureList();
        UIPanelDictionary = new Dictionary<Creature, GameObject>();
        PopulateStore(creatureList);        
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
        newCreature.name = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>().text = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>().text = creature.CurrentValue.ToString();
        newCreature.GetComponent<HolderOfThings>().UniqueID = creature.ID;
        //TODO: Add creature Icon to prefab;
        //TODO: Add event handling to prefab;

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

    //TODO get the creature from the creatureList
    public Creature GetCreatureByUniqueID(string id)
    {
        var theCreature = GetCreature(id);
        return theCreature;
    }

    //TODO Delete the creature from the creatureList
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

}
