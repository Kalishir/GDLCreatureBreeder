using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The instances of fields. manages the currentcreatures
/// </summary>

public class Pen : MonoBehaviour
{
    [SerializeField]private CreatureHold creatureField;
    [SerializeField]private CreatureList listOfCreatures;

    public CreatureHold CreatureField
    {
        get { return creatureField; }
    }

    public CreatureList ListOfCreatures
    {
        get { return listOfCreatures; }
    }


	// Use this for initialization
	void Start () 
    {
	    listOfCreatures = new CreatureList();
        listOfCreatures.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));

        //Add to the land master
        LandMaster.Instance.MyCreatureFields.Add(this);
    }
	
	// Update is called once per frame
	void Update () 
    {
        //Debug tests
        DebugTests();
	}

    void DebugTests()
    {
        //Upgrade field
        if (Input.GetKeyDown(KeyCode.U))
        {
            creatureField = creatureField.UpgradeField();
        }
    }

    public void UpgradePen(Image upgradeImage)
    {
        var tempPen = creatureField;
        creatureField = creatureField.UpgradeField();

        //TODO make upgradebutton flash if the upgrade does not go through
        //Update did not go through

        if (tempPen == creatureField)
        {
            upgradeImage.color = Color.red;
            Debug.Log("its the same");
        }
        else
        {
            upgradeImage.color = Color.green;
            Debug.Log("its not the same");
        }
    }
}
