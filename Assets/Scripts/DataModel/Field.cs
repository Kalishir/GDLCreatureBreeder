using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour
{

    [Header("Field itself")]
    fieldType typeOfField;
    [SerializeField]private int amountOfCreaturesICanHold = 1;
    [SerializeField]private int costOfUpgrading;
    [SerializeField]private int chanceOfBreeding;

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
            if (Random.Range(0f, 100f) < chanceOfBreeding)
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
        if(amountOfCreaturesICanHold> listOfCreatures.Creatures.Count)
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
    }
}
