using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private int creatureCount;
    [SerializeField] private GameObject StoreListFrame;
    [SerializeField] private CreatureList creatureList;
    
    

    // Use this for initialization
    void Start()
    {
        creatureList = new CreatureList();
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
            GameObject newCreaturePanel = CreateCreatureObject(creature);
            newCreaturePanel.transform.SetParent(StoreListFrame.transform, false);
        }
    }

    private GameObject CreateCreatureObject(Creature creature)
    {
        if (creaturePrefab == null) return null;

        GameObject newCreature = GameObject.Instantiate(creaturePrefab);
        newCreature.name = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>().text = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>().text = creature.CurrentValue.ToString();
        //TODO: Add creature Icon to prefab;
        //TODO: Add event handling to prefab;

        return newCreature;
    }


}
