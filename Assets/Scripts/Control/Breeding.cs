using UnityEngine;
using System.Collections;

public class Breeding : MonoBehaviour
{
    /// <summary>
    /// Breeds Two Creatures of Matching Types
    /// </summary>
    /// <param name="creature1">A CreatureObject representing the first parent</param>
    /// <param name="creature2">A CreatureObject representing the second parent</param>
    /// <returns>
    /// A CreatureData object. 
    /// Empty and Type == CreatureType.Invalid if breeding failed.
    /// Complete and Type == creature1.Type if successful
    /// </returns>
    public CreatureData BreedCreature(Creature creature1, Creature creature2)
    {
        CreatureData newCreature = new CreatureData();

        if (creature1.Type == creature2.Type)
        {
            newCreature = CreatureManager.Manager.GetCreatureOfType(creature1.Type);
        }

        return newCreature;
    }

    public bool ReadyToBreed(Creature creature)
    {
        bool isReady = true;
        if (creature.Health != creature.MaxHealth)
        {
            isReady = false;
        }
        if (creature.Horniness != creature.MaxHorniness)
        {
            isReady = false;
        }
        return isReady;
    }
}
