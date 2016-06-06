using UnityEngine;

public class Creature : MonoBehaviour
{
    // The data of the creature.
    // For example CreatureData holds info about what a Pikachu is.
    // Creature class (this) holds info about a Pikachu instance.
    private CreatureData creatureData;

    public CreatureData.CreatureType Type
    {
        get { return creatureData.type; }
    }
    
    public string CreatureName {
        get { return creatureData.name; }
    }

    [SerializeField] private int value;
    public int Value {
        get { return value; }
        set { this.value = value; }
    }

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health > creatureData.maxHealth)
                health = creatureData.maxHealth;
            if (health < 0)
                health = 0;
        }
    }

    [SerializeField] private int libido;
    public int Libido
    {
        get { return libido; }
        set
        {
            libido = value;
            if (libido < 0)
                libido = 0;
        }
    }

    public void SetCreatureData(CreatureData data)
    {
        creatureData = data;
        gameObject.name = creatureData.name;
        health = creatureData.maxHealth;
        value = data.value;
        libido = 100; // Hardcoded default for now.
    }
}
