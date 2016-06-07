using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

    [SerializeField] private GameObject generalCanvas;
    [SerializeField] private GameObject storeCanvas;
    [SerializeField] private GameObject managementCanvas;
    
    void Start()
    {
        if (generalCanvas == null)
        {
            generalCanvas = GameObject.Find("GeneralMenuCanvas") as GameObject;
        }
        if (storeCanvas == null)
        {
            storeCanvas = GameObject.Find("StoreCanvas") as GameObject;
        }
        if (managementCanvas == null)
        {
            managementCanvas = GameObject.Find("ManagementCanvas") as GameObject;
        }

        ShowGeneralMenuScreen();
    }

    public void ShowGeneralMenuScreen()
    {
        generalCanvas.SetActive(true);
        storeCanvas.SetActive(false);
        managementCanvas.SetActive(false);
    }

    public void ShowStoreScreen()
    {
        generalCanvas.SetActive(false);
        storeCanvas.SetActive(true);
        managementCanvas.SetActive(false);
    }

    public void ShowManagementScreen()
    {
        generalCanvas.SetActive(false);
        storeCanvas.SetActive(false);
        managementCanvas.SetActive(true);
    }
}
