using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{

    private UIManager uiManager;
    private Breeding creatureBreeding;
    private Tend creatureTending;

    void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        creatureTending = gameObject.GetComponent<Tend>();
        creatureBreeding = gameObject.GetComponent<Breeding>();
    }

    public void TendToCreature()
    {
        var theCreature =  PlayerInventory.Instance.GetCreatureByUniqueID(uiManager.CurrentSelectedItem.UniqueID);

        creatureTending.TendCreature(theCreature);
    }

    public void Selling()
    {
        var theCreature = PlayerInventory.Instance.GetCreatureByUniqueID(uiManager.CurrentSelectedItem.UniqueID);

        PlayerMoney.Instance.AddMoney(theCreature.CurrentValue);
        uiManager.ClearSelection();

        //Delete object
        PlayerInventory.Instance.DeleteCreatureByUniqueID(uiManager.CurrentSelectedItem.UniqueID);
        Destroy(uiManager.CurrentSelectedItem.gameObject);
    }

    //TODO do breeding stuff



    


}
