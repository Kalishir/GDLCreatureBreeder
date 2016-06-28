using System;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Creature
{
    // The data of the creature loaded in from JSON.
    [SerializeField] private CreatureData creatureData;
    
    public event System.EventHandler ValueChanged;

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

    public int MaxHealth
    {
        get
        {
            return creatureData.MaxHealth;
        }
    }

    public int MaxHorniness
    {
        get
        {
            return creatureData.MaxHorniness;
        }
    }

    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, creatureData.MaxHealth);
            RecalculateValue();
        }
    }

    [SerializeField] private int horniness;
    public int Horniness
    {
        get
        {
            return horniness;
        }
        set
        {
            horniness = value;
            horniness = Mathf.Clamp(horniness, 0, creatureData.MaxHorniness);
            RecalculateValue();
        }
    }

    [SerializeField] private int currentValue;
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

    [SerializeField] private string spritePath;
    public string SpritePath
    {
        get { return spritePath; }
        private set { spritePath = value; }
    }

    [SerializeField] private string iconPath;
    public string IconPath
    {
        get { return iconPath; }
        private set { iconPath = value; }
    }

    private Guid guid;
    public string ID
    {
        get { return guid.ToString(); }
    }

    /// <summary>
    /// Creates a new Creature from the CreatureData Object.
    /// Throws an exception if the CreatureData.Type is Invalid
    /// </summary>
    /// <param name="data">A CreatureData struct to generate the creature from</param>
    public Creature(CreatureData data)
    {
        if (data.Type == CreatureType.Invalid)
            throw new System.Exception("Invalid Creature Type Exception");
        creatureData = data;
        ResetHealth();
        ResetHorniness();
        RecalculateValue();

        spritePath = "/Resources/Sprites/Creatures/" + System.Enum.GetName(Type.GetType(), Type) + "/" + CreatureName;
        iconPath = "/Resources/Icon/Creatures/" + System.Enum.GetName(Type.GetType(), Type) + "/" + CreatureName;

        guid = Guid.NewGuid();
    }

    /// <summary>
    /// Resets the creatures health to a random number between 1 and (MaxHealth/2) + 1
    /// </summary>
    public void ResetHealth()
    {
        Health = Random.Range(1, (creatureData.MaxHealth / 2) + 1);
    }

    /// <summary>
    /// Resets the creatures horniness to a random number between 1 and (MaxHorniness/2) + 1
    /// </summary>
    public void ResetHorniness()
    {
        Horniness = Random.Range(1, (creatureData.MaxHorniness / 2) + 1);
    }


    private void RecalculateValue()
    {
        CurrentValue = (int)(( Health / (float)MaxHealth ) * ( Horniness / (float)MaxHorniness) * creatureData.BaseValue);
        if(ValueChanged != null)
            ValueChanged(this, EventArgs.Empty);
    }

    public override string ToString()
    {
        return creatureData.ToString() +
                ", Current Health: " + health +
                ", Current Horniness: " + horniness +
                ", Current Value: " + currentValue;
    }
}
