using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class CreatureHold : CreatureHoldEffects
{

    [Header("Field itself")]
    //fieldType typeOfField;
    [SerializeField]private CreatureHold upgradeTo;
    [SerializeField]private int costOfUpgrading = 0;
    [Space(5)]
    [SerializeField]private int fieldSize = 1;
    [SerializeField]private int breedingChance = 0;

    [Header("Stat Increases per Creature")]
    [SerializeField]private int healthGain = 0;
    [SerializeField]private int horninessGain = 0;
    [SerializeField]private int cashGain = 0;

    private List<Creature> tempCreatures = new List<Creature>(); 


    public void DayHasEnded(GameObject go)
    {
        tempCreatures.Clear();


        var penGameObject = go.GetComponent<Pen>();
        var creatureCount = penGameObject.ListOfCreatures.Creatures;

        var howManyCreaturesToMake = 0;


        //make every creature in creaturelist gain health,horninessand make the player able to get money
        foreach (var creature in creatureCount)
        {
            creature.Health += healthGain;
            creature.Horniness += horninessGain;

            //Breeding
            var rolled = Random.Range(0f, 100f);
            if (rolled < breedingChance)
            {
                
                Debug.Log(rolled);
                //Breeding succesful
                //TODO create a new creature and add it to this field or something.

                //We create the creatures after we have gone through the loop because you don't want to modify it when looking through the loop
                tempCreatures.Add(creature);

            }

            //Give the player money
            PlayerMoney.Instance.AddMoney(cashGain);
        }

        for (int i = 0; i < tempCreatures.Count; i++)
        {
            penGameObject.ListOfCreatures.AddCreature(CreatureManager.Manager.GetCreatureOfType(tempCreatures[i].Type));
        }
    }

    public CreatureHold UpgradeField()
    {
        if(upgradeTo == null)
            return this;

        //Checks if we have enough money. if we do, it deducts money
        if (PlayerMoney.Instance.CheckIfWeCanPayForThisThenBuyIt(costOfUpgrading))
        {
            //TODO upgrade the field
            return upgradeTo;
        }
        return this;
    }
    /*
    [Header("Field itself")]
    fieldType typeOfField;
    [SerializeField]private int fieldSize = 1;
    [SerializeField]private int costOfUpgrading;
    [SerializeField]private int breedingChance;

    [Header("Stat Increases")]
    [SerializeField]private int healthGain;
    [SerializeField]private int horninessGain;
    [SerializeField]private int cashGain;

    [Space(10)]
    [SerializeField]
    private CreatureList listOfCreatures;


    void Start()
    {
        listOfCreatures.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            DayHasEnded();
        }
    }

    public void DayHasEnded()
    {
        //make every creature in creaturelist gain health,horninessand make the player able to get money
        foreach (var creature in listOfCreatures.Creatures)
        {
            creature.Health += healthGain;
            creature.Horniness += horninessGain;

            //Breeding
            if (Random.Range(0f, 100f) < breedingChance)
            {
                //Breeding succesful
                //TODO create a new creature and add it to this field or something.
            }

            //Give the player money
            PlayerMoney.Instance.AddMoney(cashGain);
        }
    }
    public void UpgradeField()
    {
        //Checks if we have enough money. if we do, it deducts money
        if (PlayerMoney.Instance.CheckIfWeCanPayForThisThenBuyIt(costOfUpgrading))
        {
            //TODO upgrade the field
        }
    }

    public void AddCreatureToList(Creature creature)
    {
        if(fieldSize> listOfCreatures.Creatures.Count)
            listOfCreatures.AddCreature(creature);
        else
        {
            //we don't have enough spots in this field for another creature. do stuff, i guess
        }
    }
    public enum fieldType
    {
        infiniteField,
        nurseryField
    }*/
}
