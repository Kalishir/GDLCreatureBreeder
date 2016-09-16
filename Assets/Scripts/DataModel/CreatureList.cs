using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class CreatureList
{
    public event UnityAction<Creature> CreatureAdded;
    public event UnityAction<Creature> CreatureRemoved;

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

    /// <summary>
    /// Creates a new CreatureList object. Initializes the internal list.
    /// </summary>
    public CreatureList(int capacity = 0)
    {
        if (capacity == 0)
        {
            creatures = new List<Creature>(500);
        }
        else
        {
            creatures = new List<Creature>(capacity);
        }
    }

    /// <summary>
    /// Generates a new Creature object from a CreatureData object and adds it to the internal list.
    /// </summary>
    public void AddCreature(CreatureData creatureData)
    {
        Creature newCreature = new Creature(creatureData);
        AddCreature(newCreature);
        
    }

    /// <summary>
    /// Adds an existing Creature object to the internal list.
    /// </summary>
    public void AddCreature(Creature creature)
    {
        if (Creatures.Count < Creatures.Capacity)
        {
            creatures.Add(creature);
            if (CreatureAdded != null)
            {
                Debug.Log("CreatureAdded");
                CreatureAdded(creature);
            }
        }
    }

    /// <summary>
    /// Removes an existing Creature object from the internal list.
    /// </summary>
    public void RemoveCreature(Creature creature)
    {
        creatures.RemoveAll((x) => { return x.ID == creature.ID; });
        if (CreatureRemoved != null)
            CreatureRemoved(creature);
    }

}
