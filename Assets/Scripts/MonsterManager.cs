using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;

    private void Start()
    {
        // TODO: Remove test.
        GameObject monsterGameObject = Instantiate(monsterPrefab);
        var monsterData = JsonUtility.FromJson<MonsterData>(Resources.Load<TextAsset>("monstertest").text);
        monsterGameObject.GetComponent<Monster>().SetMonsterData(monsterData);

        Debug.Log("Created a " + monsterData.type);
    }
}
