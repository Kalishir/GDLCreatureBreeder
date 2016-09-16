using UnityEngine;
using System.Collections;
using System;

public class CreaturePanelFactory : MonoBehaviour
{
    [SerializeField] Location locationToManage;
    [SerializeField] RectTransform prefabParent;
    [SerializeField] GameObject creaturePrefab;

	// Use this for initialization
	void Start ()
    {
        if (locationToManage != null)
        {
            locationToManage.Creatures.CreatureAdded += GenerateNewPrefab;
            //locationToManage.Creatures.CreatureRemoved += RemovePrefab;
        }
	}
    
    private void GenerateNewPrefab(Creature creature)
    {
        GameObject newPanel = Instantiate(creaturePrefab);
        newPanel.transform.SetParent(prefabParent, false);
        var init = newPanel.GetComponent<CreaturePrefabInitalizer>();
        init.Initialize(creature);
        locationToManage.Creatures.CreatureRemoved += init.CreatureRemovedHandler;
    }

    private void RemovePrefab(Creature creature)
    {
        throw new NotImplementedException();
    }
}
