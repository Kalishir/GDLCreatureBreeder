using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonSelectionHandler : MonoBehaviour {

    [SerializeField] private float positionModifier;
    [SerializeField] private Color selectedColour;
    [SerializeField] private Color backgroundColour;
    [SerializeField] private GameObject currentlySelectedButton;

    public GameObject CurrentlySelectedButton
    {
        get
        {
            return currentlySelectedButton;
        }
        set
        {
            if (currentlySelectedButton != null)
            {
                OnSelected(currentlySelectedButton, false);
            }
            currentlySelectedButton = value;
            OnSelected(currentlySelectedButton, true);
        }
    }

    public void OnSelected(GameObject button, bool selected)
    {
        float newX = button.transform.position.x;

        var backgroundImage = button.transform.Find("Background").GetComponent<Image>();

        if (selected)
        {
            newX += positionModifier;
            if (backgroundImage != null)
                backgroundImage.color = selectedColour;
        }
        else
        {
            newX -= positionModifier;
            if (backgroundImage != null)
                backgroundImage.color = backgroundColour;
        }
        button.transform.position = new Vector3(newX, button.transform.position.y, button.transform.position.z);
    }
}
