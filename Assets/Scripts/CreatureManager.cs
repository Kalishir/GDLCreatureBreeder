using UnityEngine;
using UnityEngine.Assertions;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    // Values used for breeding.
    private const int lowerCreatureHealth = 50;
    private const int lowerCreatureLibido = 50;
    private const int breedingValueDeviation = 30; // How much the randomized value of the bred creature can be different from its base value.

    private void Start()
    {
        // TODO: Remove test.
        Creature creature = SpawnCreature("Dragon");
        Creature creature2 = SpawnCreature("Dragon");
        Creature babyCreature = Breed(creature, creature2);
        Assert.IsNotNull(babyCreature, "Breeding failed!");
    }

    /// <summary>
    /// Spawns a creature into the scene.
    /// </summary>
    /// <param name="fileName">The json filename of the creature without extension.</param>
    private Creature SpawnCreature(string fileName)
    {
        GameObject creatureGameObject = Instantiate(creaturePrefab);
        var creatureData = JsonUtility.FromJson<CreatureData>(Resources.Load<TextAsset>(fileName).text);
        var creature = creatureGameObject.GetComponent<Creature>();
        creature.SetCreatureData(creatureData);

        return creature;
    }

    /// <summary>
    /// Breeds two creatures and creates a new one.
    /// </summary>
    /// <returns>The newly created creature. Returns null if creature types do not match.</returns>
    public Creature Breed(Creature creature1, Creature creature2)
    {
        Creature retVal = null;
        if (creature1.Type == creature2.Type)
        {
            creature1.Health -= lowerCreatureHealth; // Creatures lose health and libido on breeding.
            creature1.Libido -= lowerCreatureLibido;
            creature2.Health -= lowerCreatureHealth;
            creature2.Libido -= lowerCreatureLibido;

            retVal = SpawnCreature(creature1.Type.ToString());
            int baseValue = retVal.Value;
            retVal.Value = Random.Range(baseValue - breedingValueDeviation, baseValue + breedingValueDeviation);
        }
        return retVal;
    }
}
