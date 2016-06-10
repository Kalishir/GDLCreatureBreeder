using UnityEngine;

[RequireComponent(typeof(CreatureList))]
public class StoreManager : MonoBehaviour
{
    private CreatureList creatureList;
    [SerializeField] private int creatureCount;

    // Use this for initialization
    void Start()
    {
        creatureList = GetComponent<CreatureList>();

        if (creatureList.Creatures.Count < creatureCount)
        {
            //Fill the list with random creatures of the type we want
            for (int i = 0; i < creatureCount; i++)
            {
                creatureList.AddCreature(CreatureManager.Manager.GetRandomCreature());
                Debug.Log(creatureList.Creatures.Count);
                Debug.Log(creatureList);
            }
        }
    }


}
