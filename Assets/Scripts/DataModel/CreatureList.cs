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

    public CreatureList()
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
