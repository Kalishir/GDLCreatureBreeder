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
            Mathf.Clamp(health, 0, creatureData.MaxHealth);
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
            Mathf.Clamp(horniness, 0, creatureData.MaxHorniness);
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
    
    private string spritePath;
    public string SpritePath
    {
        get { return spritePath; }
        private set { spritePath = value; }
    }
    
    private string iconPath;
    public string IconPath
    {
        get { return iconPath; }
        private set { iconPath = value; }
    }

    public Creature(CreatureData data)
    {
        creatureData = data;
        ResetHealth();
        ResetHorniness();
        RecalculateValue();

        // TODO: Not sure if this is correct, but just wanted to fix up the errors. This used to just get the Type which didn't correspond to a method.
        spritePath = "/Resources/Sprites/Creatures/" + System.Enum.GetName(Type.GetType(), creatureData) + "/" + CreatureName;
        iconPath = "/Resources/Icon/Creatures/" + System.Enum.GetName(Type.GetType(), creatureData) + "/" + CreatureName;
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
