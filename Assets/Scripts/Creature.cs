using UnityEngine;

public class Creature
{
    public enum CreatureType
    {
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

    public CreatureType Type { get; private set; }
    public int Health { get; private set; }
    public int Libido { get; private set; }
}
