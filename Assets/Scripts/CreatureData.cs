
/// <summary>
/// Contains the data of a creature type.
/// </summary>
public struct CreatureData
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

    public CreatureType type;
    public string name;
    public int maxHealth;
    public int value;
}