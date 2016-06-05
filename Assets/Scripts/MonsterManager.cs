using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;

    private void Start()
    {
        // TODO: Remove test.
        GameObject monsterGameObject = Instantiate(monsterPrefab);
        JsonUtility.FromJsonOverwrite(Resources.Load<TextAsset>("monstertest").text, monsterGameObject.GetComponent<Monster>());
    }
}
