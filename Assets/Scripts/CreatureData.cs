
/// <summary>
/// Contains data of a single creature type.
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
}