using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private GameObject inventoryList;
    [SerializeField] private CreatureList creatureList;

    private static PlayerInventory instance;
    static public PlayerInventory Instance
    {
        get
        {
            return instance;
        }
    }



    // Use this for initialization
    void Start()
    {
        instance = this;
        creatureList = new CreatureList();
        PopulatePlayerInventory(creatureList);
    }


    private void PopulatePlayerInventory(CreatureList list)
    {
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));

        foreach (var creature in creatureList.Creatures)
        {
            GameObject newCreaturePanel = CreateCreatureObject(creature);
            newCreaturePanel.transform.SetParent(inventoryList.transform, false);

        }
    }

    private GameObject CreateCreatureObject(Creature creature)
    {
        if (creaturePrefab == null)
            return null;

        GameObject newCreature = GameObject.Instantiate(creaturePrefab);
        newCreature.name = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>().text = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>().text = creature.CurrentValue.ToString();
        //TODO: Add creature Icon to prefab;
        //TODO: Add event handling to prefab;

        return newCreature;
    }

    //Called by store when we purchase a creature
    public void AddCreatureToInventory(Creature creature)
    {
        Debug.Log("MEOW");
        GameObject newCreaturePanel = CreateCreatureObject(creature);
        newCreaturePanel.transform.SetParent(inventoryList.transform, false);
    }

    public Creature GetCreatureByUniqueID(string id)
    {
        var theCreature = GetCreature(id);
        return theCreature;
    }

    public void DeleteCreatureByUniqueID(string id)
    {
        var theCreature = GetCreature(id);
        if(theCreature != null)
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
