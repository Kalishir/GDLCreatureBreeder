using UnityEngine;

public enum CreatureType
{
    Arachnid,
    Avian,
    Canine,
    Demon,
    Dragon,
    Equine,
    Feline,
    Golem,
    Griffon,
    Insect,
    Nymph,
    Slime,
    Ursine
}

/// <summary>
/// Represents the creatures data as loaded from JSON files
/// </summary>
[System.Serializable]
public struct CreatureData
{
    [SerializeField] private CreatureType type;
    public CreatureType Type
    {
        get
        {
            return type;
        }
        private set
        {
            type = value;
        }
    }

    [SerializeField] private string name;
    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            name = value;
        }
    }

    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        private set
        {
            maxHealth = value;
        }
    }

    [SerializeField] private int baseValue;
    public int BaseValue
    {
        get
        {
            return baseValue;
        }
        private set
        {
            baseValue = value;
        }
    }

    [SerializeField] private int maxHorniness;
    public int MaxHorniness
    {
        get
        {
            return maxHorniness;
        }
        private set
        {
            maxHorniness = value;
        }
    }

    [SerializeField] private int libido;
    public int Libido
    {
        get
        {
            return libido;
        }
        private set
        {
            libido = value;
        }
    }

    public override string ToString()
    {
        return "Type : " + Type.ToString() +
                ", Name : " + name +
                ", Max Health : " + maxHealth.ToString() +
                ", Max Horniness : " + maxHorniness.ToString() +
                ", Libido : " + libido.ToString() +
                ", Base Value : " + baseValue.ToString() + "\r\n";
    }
}