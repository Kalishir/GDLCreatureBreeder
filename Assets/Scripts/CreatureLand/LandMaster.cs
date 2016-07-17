using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Singleton for all the land,fields/pens
/// </summary>

public class LandMaster : MonoBehaviour
{
    private List<Pen> myCreatureFields = new List<Pen>();

    public List<Pen> MyCreatureFields
    {
        get { return myCreatureFields; }
        set { myCreatureFields = value; }
        
    }

    private static LandMaster instance;
    public static LandMaster Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }


    public void EndOfDay()
    {
        foreach (var theFields in myCreatureFields)
        {
            theFields.CreatureField.DayHasEnded(theFields.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndOfDay();
        }
    }
   
}