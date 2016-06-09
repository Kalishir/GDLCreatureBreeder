using UnityEngine;

public class Creature
{
    // The data of the creature loaded in from JSON.
    private CreatureData creatureData;

    public CreatureType Type
    {
        get
        {
            return creatureData.Type;
        }
    }

    public string CreatureName
    {
        get
        {
            return creatureData.Name;
        }
    }

    public int Libido
    {
        get
        {
            return creatureData.Libido;
        }
    }

    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health > creatureData.MaxHealth)
            {
                health = creatureData.MaxHealth;
            }
            if (health < 0)
            {
                health = 0;
            }
            RecalculateValue();
        }
    }

    private int horniness;
    public int Horniness
    {
        get
        {
            return horniness;
        }
        set
        {
            horniness = value;
            if (horniness > creatureData.MaxHorniness)
            {
                horniness = creatureData.MaxHorniness;
            }
            if (horniness < 0)
            {
                horniness = 0;
            }
            RecalculateValue();
        }
    }

    private int currentValue;
    public int CurrentValue
    {
        get
        {
            return currentValue;
        }
        private set
        {
            currentValue = value;
            if (currentValue < 1)
            {
                currentValue = 1;
            }
        }
    }

    public Creature(CreatureData data)
    {
        creatureData = data;
        ResetHealth();
        ResetHorniness();
        RecalculateValue();
    }

    public void ResetHealth()
    {
        Health = Random.Range(1, (creatureData.MaxHealth / 2) + 1);
    }

    public void ResetHorniness()
    {
        Horniness = Random.Range(1, (creatureData.MaxHorniness / 2) + 1);
    }


    private void RecalculateValue()
    {
        CurrentValue = Health * Horniness * creatureData.BaseValue;
    }
}
