using UnityEngine;

public class Creature : MonoBehaviour
{
    public enum CreatureType {
        Slime,
        Dragon,
        Griffon,
        Nymph,
        Equine,
        Demon,
        Beast,
        Golem,
        Bug,
        Avian
    }

    [SerializeField] private CreatureType type;
    public CreatureType Type
    {
        get { return type; }
        private set { type = value; }
    }

    [SerializeField] private string name;
    public string Name {
        get { return name; }
        set {
            name = value;
            gameObject.name = name; // Set gameobject name to match creature name.
        }
    }

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        private set { health = value; }
    }

    [SerializeField] private int libido;
    public int Libido
    {
        get { return libido; }
        private set { libido = value; }
    }
}
