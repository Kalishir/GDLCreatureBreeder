using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class CreatureManager : MonoBehaviour, System.IDisposable
{

    /* 
    ISSUE: Dictionaries are not serializable in the Unity Editor.
    TODO: 
        Either
        1) Ham this with some basic code that grabs two lists for Keys and Values in the manager
        2) Create a script that allows for full serialization of a Dictionary (which would be kind of the same, but a bit more work).
        
        Third party options:
        There are a few open source versions available once the legal stuff is sorted such as Vexe's Framework (VXF)
        There are also purchased assets available that do the same such as Advanced Inspector.
    */
    private Dictionary<CreatureType, List<CreatureData>> creaturesDictionary;

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
    
    private bool disposed;

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
        SetupDictionary(creaturesDictionary);

        //Load Creatures from JSON
        LoadCreatureLibrary(creaturesDictionary);
    }

    private void SetupDictionary(Dictionary<CreatureType, List<CreatureData>> dictionary)
    {
        dictionary = new Dictionary<CreatureType, List<CreatureData>>();
        var creatureTypes = System.Enum.GetValues(typeof(CreatureType)) as CreatureType[];
        foreach (var creatureType in creatureTypes)
        {
            dictionary.Add( creatureType, new List<CreatureData>() );
        }
        creaturesDictionary = dictionary;
    }

    private void LoadCreatureLibrary(Dictionary<CreatureType, List<CreatureData>> dictionary)
    {
        if (dictionary == null)
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
                dictionary[creature.Type].Add(creature);
            }

        }

        creaturesDictionary = dictionary;
    }

    /// <summary>
    /// Gets a random creature's data loaded from JSON.
    /// </summary>
    /// <returns>A CreatureData object of a random type</returns>
    public CreatureData GetRandomCreature()
    {
        //selects which type the resultant creature will be
        var values = System.Enum.GetValues(typeof(CreatureType));
        CreatureType creatureType = (CreatureType)values.GetValue(Random.Range(1, values.Length));
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
        if(disposed)
        {
            return;
        }
        
        if(disposing)
        {
            // Nothing managed needs to be disposed.
        }
        
        foreach(var kvp in creaturesDictionary)
        {
            kvp.Value.Clear();
        }
        creaturesDictionary.Clear();
        creaturesDictionary = null;
        Manager = null;
        
        disposed = true;
    }
}
