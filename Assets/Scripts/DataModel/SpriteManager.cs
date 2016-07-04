using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour, System.IDisposable
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
    private Dictionary<string, Sprite> spritesDictionary;

    // Singleton Enforcement
    static private SpriteManager manager;
    static public SpriteManager Manager
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

    [SerializeField] string defaultImageName = "default";

    private bool disposed;

    public void Awake()
    {
        if (manager == null)
        {
            Manager = this;
            DontDestroyOnLoad(gameObject);

            SetupDictionary(spritesDictionary);
            //Load Creatures from JSON
            LoadCreatureLibrary(spritesDictionary);
        }
        else if (manager != this)
        {
            Destroy(this);
        }
    }


    public void Start()
    {
    }

    private void SetupDictionary(Dictionary<string, Sprite> dictionary)
    {
        dictionary = new Dictionary<string, Sprite>();
        spritesDictionary = dictionary;
    }

    private void LoadCreatureLibrary(Dictionary<string, Sprite> dictionary)
    {
        if (dictionary == null)
            return;

        dictionary.Add(defaultImageName, Resources.Load<Sprite>("Sprites/default") as Sprite);

        string path = "Sprites/";
        var info = new DirectoryInfo("Assets/Resources/" + path);
        var folders = info.GetDirectories();
        foreach (var folder in folders)
        {
            string subFolderPath = path + folder.Name + "/";
            var subFolderInfo = new DirectoryInfo("Assets/Resources/" + subFolderPath);
            var files = subFolderInfo.GetFiles("*.png");
            foreach (var file in files)
            {
                string fileName = subFolderPath + file.Name.Split('.')[0];
                Sprite sprite = Resources.Load<Sprite>(fileName) as Sprite;
                if (sprite == null) Debug.Log("No Sprite");
                dictionary.Add(fileName.ToLower(), sprite);
            }

        }

        spritesDictionary = dictionary;
    }

    public Sprite GetCreatureSprite(CreatureType type, string name)
    {
        string path = "Assets/Resources/" + type.ToString() + "/" + name;
        path = path.ToLower();
        if (spritesDictionary.ContainsKey(path))
        {
            Debug.Log(path);
            return spritesDictionary[path];
        }

        return spritesDictionary[defaultImageName];
    }

    public Sprite GetCreatureSprite(CreatureData data)
    {
        string path = "Assets/Resources/" + data.Type.ToString() + "/" + data.Name;
        path = path.ToLower();
        if (spritesDictionary.ContainsKey(path))
            return spritesDictionary[path];

        return spritesDictionary[defaultImageName];
    }

    public Sprite GetCreatureSprite(Creature creature)
    {
        string path = creature.SpritePath;
        path = path.ToLower();
        if (spritesDictionary.ContainsKey(path))
            return spritesDictionary[path];

        return spritesDictionary[defaultImageName];
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

        spritesDictionary.Clear();
        spritesDictionary = null;
        Manager = null;

        disposed = true;
    }
}