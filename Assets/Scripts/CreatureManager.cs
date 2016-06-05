using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    private void Start()
    {
        // TODO: Remove test.
        GameObject creatureGameObject = Instantiate(creaturePrefab);
        JsonUtility.FromJsonOverwrite(Resources.Load<TextAsset>("creaturetest").text, creatureGameObject.GetComponent<Creature>());
    }
}
