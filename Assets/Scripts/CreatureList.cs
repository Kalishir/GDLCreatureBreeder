using UnityEngine;
using System.Generics.Collections;

public class CreatureList : MonoBehaviour
{
    [SerializeField] private List<Creature> creatureList;
    // TODO: Refactor so that creatures cannot be added directly to the list;
    public List<Creature> CreatureList
    {
        get { return creatureList; }
        private set { creatureList = value; }
    }

    void Start()
    {
        creatureList = new List<Creature>();
    }

    public void AddCreature(CreatureData creatureData)
    {
        Creature newCreature = new Creature(creatureData);
        creatureList.Add(newCreature);
    }

    public void RemoveCreature(Creature creature)
    {
        List.Remove(creature);
    }

}
