

public struct MonsterData
{
    public enum MonsterType {
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

    public MonsterType type;
    public string name;
    public int maxHealth;
}