using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonSelectionHandler : MonoBehaviour {

    bool selected = false;
    [SerializeField] private float positionModifier;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color selectedColour;
    [SerializeField] private Color backgroundColour;

    void Start()
    {
        if (backgroundImage == null)
            backgroundImage = transform.Find("Background").GetComponent<Image>();

        if(backgroundImage != null)
            backgroundImage.color = backgroundColour;
    }


    public void OnSelected()
    {
        float newX = transform.position.x;
        selected = !selected;

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
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
