using System.Collections.Generic;
using UnityEngine;

public class CreatureList : MonoBehaviour
{
    [SerializeField] private List<Creature> creatures;
    // TODO: Refactor so that creatures cannot be added directly to the list;


    /// <summary>
    /// Gets the creature list.
    /// </summary>
    public List<Creature> Creatures
    {
        get { return creatures; }
        private set { creatures = value; }
    }

    void Start()
    {
        creatures = new List<Creature>();
    }

    public void AddCreature(CreatureData creatureData)
    {
        Creature newCreature = new Creature(creatureData);
        creatures.Add(newCreature);
    }

    public void RemoveCreature(Creature creature)
    {
        creatures.Remove(creature);
    }

}
