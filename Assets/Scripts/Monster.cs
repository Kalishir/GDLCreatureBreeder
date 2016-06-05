using UnityEngine;

public class Monster : MonoBehaviour
{
    private MonsterData monsterData;

    public MonsterData.MonsterType Type
    {
        get { return monsterData.type; }
    }
    
    public string MonsterName {
        get { return monsterData.name; }
    }

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        private set
        {
            health = value;
            if (health > monsterData.maxHealth)
                health = monsterData.maxHealth;
        }
    }

    [SerializeField] private int libido;
    public int Libido
    {
        get { return libido; }
        private set { libido = value; }
    }

    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        gameObject.name = monsterData.name;
        health = monsterData.maxHealth;
        libido = 100; // Hardcoded default for now.
    }
}
