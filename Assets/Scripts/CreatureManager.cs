using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    private void Start()
    {
        // TODO: Remove test.
        Creature creature = SpawnCreature("creaturetest");
        Debug.Log("Created a " + creature.Type);
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
}
