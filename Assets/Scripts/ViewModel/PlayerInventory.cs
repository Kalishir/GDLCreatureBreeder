using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CreatureList))]
public class PlayerInventory : MonoBehaviour , System.IDisposable
{
    [SerializeField] private GameObject creaturePrefab;

    private CreatureList creatureList;

    // Singleton Enforcement
    static private PlayerInventory inventory;
    static public PlayerInventory Inventory
    {
        get
        {
            return inventory;
        }
        private set
        {
            inventory = value;
        }
    }

    private bool disposed;

    public void Awake()
    {
        if (inventory == null)
        {
            Inventory = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (inventory != this)
        {
            Destroy(this);
        }
    }


    // Use this for initialization
    void Start()
    {
        creatureList = GetComponent<CreatureList>();
        PopulatePlayerInventory(creatureList);
    }


    private void PopulatePlayerInventory(CreatureList list)
    {
        list.AddCreature(CreatureManager.Manager.GetRandomCreature());
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
    }

    private GameObject CreateCreatureObject(Creature creature)
    {
        if (creaturePrefab == null)
            return null;

        GameObject newCreature = GameObject.Instantiate(creaturePrefab);
        newCreature.name = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>().text = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>().text = creature.CurrentValue.ToString();
        //TODO: Add creature Icon to prefab;
        //TODO: Add event handling to prefab;

        return newCreature;
    }


    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    void OnDestroy()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            // Nothing managed needs to be disposed.
        }

        creatureList = null;
        Inventory = null;

        disposed = true;
    }

}
