using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CreatureList
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

    /// <summary>
    /// Creates a new CreatureList object. Initializes the internal list.
    /// </summary>
    public CreatureList()
    {
        creatures = new List<Creature>();
    }

    /// <summary>
    /// Generates a new Creature object from a CreatureData object and adds it to the internal list.
    /// </summary>
    public void AddCreature(CreatureData creatureData)
    {
        Creature newCreature = new Creature(creatureData);
        creatures.Add(newCreature);
    }

    /// <summary>
    /// Adds an existing Creature object to the internal list.
    /// </summary>
    public void AddCreature(Creature creature)
    {
        creatures.Add(creature);
    }

    /// <summary>
    /// Removes an existing Creature object from the internal list.
    /// </summary>
    public void RemoveCreature(Creature creature)
    {
        //TODO: RemoveCreature by GUID.
        creatures.Remove(creature);
    }

}
