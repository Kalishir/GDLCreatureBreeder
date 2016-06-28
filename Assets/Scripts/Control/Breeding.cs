using UnityEngine;
using System.Collections;

public class Breeding : MonoBehaviour
{
    private Creature firstCreature;
    private Creature secondCreature;
    /// <summary>
    /// Breeds Two Creatures of Matching Types
    /// </summary>
    /// <param name="creature1">A Creature object representing the first parent</param>
    /// <param name="creature2">A Creature object representing the second parent</param>
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

    /// <summary>
    /// Determines if a Creature is ready to breed.
    /// <param name ="creature">A Creature object to be tested.</param>
    /// <returns>
    /// True if Health and Horniness are maxed.
    /// False if not.
    /// </returns>
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

    //Stores first and 2nd creature of breeding
    public bool AddCreatureToBreedingHold(Creature creature)
    {
        if (firstCreature == null && ReadyToBreed(creature))
        {
            firstCreature = creature;
            return true;
        }
        else if(firstCreature != null && ReadyToBreed(creature) && creature.Type == firstCreature.Type)
        {
            secondCreature = creature;
            return true;
        }
        return false;
    }

    public void StartBreeding()
    {
        if (firstCreature != null && secondCreature != null)
        {
            //Create and add creature to inventory
            var creature = BreedCreature(firstCreature, secondCreature);
            PlayerInventory.Instance.AddCreatureToInventory(creature);

            //Move the creatures visually back into inventory
            //Set creatures to null
            firstCreature = null;
            secondCreature = null;

            //Move FrontEnd stuff to managmentscreen 
            UIManager.Instance.MoveBreedingContentToManagment();
            UIManager.Instance.ClearSelection();

        }
    }
}
