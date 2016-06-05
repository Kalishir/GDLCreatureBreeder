using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    private void Start()
    {
        // TODO: Remove test.
        GameObject creatureGameObject = Instantiate(creaturePrefab);
        var creatureData = JsonUtility.FromJson<CreatureData>(Resources.Load<TextAsset>("creaturetest").text);
        creatureGameObject.GetComponent<Creature>().SetCreatureData(creatureData);

        Debug.Log("Created a " + creatureData.type);
    }
}
