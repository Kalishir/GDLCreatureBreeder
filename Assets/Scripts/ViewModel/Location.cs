using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour
{
    [SerializeField] private LocationInfo locationInformation;
    [SerializeField] private CreatureList creatures;
    public CreatureList Creatures
    {
        get
        {
            return creatures;
        }
        private set
        {
            creatures = value;
        }
    }



	// Use this for initialization
	void Start ()
    {
        creatures = new CreatureList(locationInformation.CreatureCapacity);
    }

    void Update()
    {
        if (locationInformation.CreatureCapacity != 0)
        {
            while (creatures.Creatures.Count != creatures.Creatures.Capacity)
            {
                creatures.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
            }
        }
    }

    public void EndOfDay()
    {
        //TODO: Breeding
        foreach (var creature in Creatures.Creatures)
        {
            creature.Health += locationInformation.HealthGainedAtEndOfDay;
            creature.Horniness += locationInformation.HorninessGainedAtEndOfDay;

            //TODO: Increase Player Gold based on creature.Value and locationInformation.GoldGainedAtEndOfDay
        }
    }

    public void Upgrade()
    {
        //TODO: Check Player Cash
        locationInformation = locationInformation.UpgradesTo;
        creatures.Creatures.Capacity = locationInformation.CreatureCapacity;
    }

}
