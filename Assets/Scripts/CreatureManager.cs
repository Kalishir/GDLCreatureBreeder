using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private Dictionary<CreatureType, List<CreatureData>> creaturesDictionary;

    // Singleton Enforcement
    static private CreatureManager manager;
    static public CreatureManager Manager
    {
        get
        {
            return manager;
        }
        private set
        {
            manager = value;
        }
    }

    public void Awake()
    {
        if (manager == null)
        {
            Manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(this);
        }
    }


    public void Start()
    {
        SetupDictionary();

        //Load Creatures from JSON
        LoadCreatureLibrary();
    }

    private void SetupDictionary()
    {
        creaturesDictionary = new Dictionary<CreatureType, List<CreatureData>>();
        var creatureTypes = System.Enum.GetValues(typeof(CreatureType)) as CreatureType[];
        foreach (var creatureType in creatureTypes)
        {
            creaturesDictionary.Add( creatureType, new List<CreatureData>() );
        }
    }

    private void LoadCreatureLibrary()
    {
        if (creaturesDictionary == null)
            return;

        string path = "CreatureData/";
        var info = new DirectoryInfo("Assets/Resources/" + path);
        var folders = info.GetDirectories();
        foreach (var folder in folders)
        {
            string subFolderPath = path + folder.Name;
            var subFolderInfo = new DirectoryInfo("Assets/Resources/" + subFolderPath);
            var files = subFolderInfo.GetFiles("*.JSON");
            foreach (var file in files)
            {
                string fileName = "/" + file.Name.Split('.')[0];
                CreatureData creature = JsonUtility.FromJson<CreatureData>(Resources.Load<TextAsset>(subFolderPath + fileName).text);
                creaturesDictionary[creature.Type].Add(creature);
            }

        }
    }

    /// <summary>
    /// Gets a random creature's data loaded from JSON.
    /// </summary>
    /// <returns>A CreatureData object of a random type</returns>
    public CreatureData GetCreature()
    {
        //selects which type the resultant creature will be
        var values = System.Enum.GetValues(typeof(CreatureType));
        CreatureType creatureType = (CreatureType)values.GetValue(Random.Range(0, values.Length));
        return GetCreatureOfType(creatureType);
    }

    /// <summary>
    /// Gets a random Creature's data loaded from JSON on start matching the type supplied as a parameter.
    /// </summary>
    /// <param name="creatureType">The Type of the creature to find</param>
    /// <returns>A CreatureData object with a type matching that requested</returns>
    public CreatureData GetCreatureOfType(CreatureType creatureType)
    {
        //selects the specific creature from the type list
        int creatureLocation = Random.Range(0, creaturesDictionary[creatureType].Count);
        return creaturesDictionary[creatureType][creatureLocation];
    }

    /// <summary>
    /// Gets a specific creature's data from the JSON loaded on start
    /// </summary>
    /// <param name="type">The type of the creature to find</param>
    /// <param name="name">The name of the creature to find, not case sensitive</param>
    /// <returns>The Specific Creature if it exists. Throws an Exception if the creature is not in the dictionary</returns>
    public CreatureData GetSpecificCreature(CreatureType type, string name)
    {
        foreach (var creature in creaturesDictionary[type])
        {
            if (creature.Name.ToLower() == name.ToLower())
                return creature;
        }

        throw new System.Exception("Creature Not In Dictionary");
    }
}
