using UnityEngine;

public class Creature : MonoBehaviour
{
    private CreatureData creatureData;

    public CreatureData.CreatureType Type
    {
        get { return creatureData.type; }
    }
    
    public string CreatureName {
        get { return creatureData.name; }
    }

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        private set
        {
            health = value;
            if (health > creatureData.maxHealth)
                health = creatureData.maxHealth;
        }
    }

    [SerializeField] private int libido;
    public int Libido
    {
        get { return libido; }
        private set { libido = value; }
    }

    public void SetCreatureData(CreatureData data)
    {
        creatureData = data;
        gameObject.name = creatureData.name;
        health = creatureData.maxHealth;
        libido = 100; // Hardcoded default for now.
    }
}
