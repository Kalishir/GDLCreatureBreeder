using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour
{
    [SerializeField] private int basePayRate;
    [SerializeField] private Location fieldLocation;
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
                creatures.AddCreature(CreatureManager.Manager.GetRandomCreature());
            }
        }
    }

    public void EndOfDay()
    {
        var tiredCreatures = new CreatureList();

        //TODO: Breeding


        foreach (var creature in Creatures.Creatures)
        {
            creature.Health += locationInformation.HealthGainedAtEndOfDay;
            creature.Horniness += locationInformation.HorninessGainedAtEndOfDay;
            if (creature.Health == 0 || creature.Horniness == 0)
            {
                fieldLocation.Creatures.AddCreature(creature);
                tiredCreatures.AddCreature(creature);
                continue;
            }

            int cashToAward = Mathf.RoundToInt(locationInformation.GoldGainedAtEndOfDay * creature.CurrentValue * basePayRate);
            if(cashToAward != 0)
                PlayerMoney.Instance.Money += cashToAward;
        }

        foreach (var creature in tiredCreatures.Creatures)
        {
            Creatures.RemoveCreature(creature);
        }
    }

    public void Upgrade()
    {
        if (locationInformation.CanUpgrade && PlayerMoney.Instance.Money >= locationInformation.CostToUpgrade)
        {
            PlayerMoney.Instance.Money -= locationInformation.CostToUpgrade;
            locationInformation = locationInformation.UpgradesTo;
            creatures.Creatures.Capacity = locationInformation.CreatureCapacity;
        }
        else
        {
            //TODO: Change to show a dialogue
            Debug.Log("Cannot Upgrade");
        }
    }

}
