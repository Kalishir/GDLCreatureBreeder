using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
using UnityEngine.UI;

public class CreatureWindow : MonoBehaviour
{
    [SerializeField]
    private Image creatureImage;

    private Image currentSelectedImage;
    private Image previousSelectedImage;

    public Image CurrentSelectedImage
    {
        get
        {
            return currentSelectedImage;
        }
        set
        {
            if (value == currentSelectedImage) return;
            Debug.Log("This worked");
            previousSelectedImage = currentSelectedImage;
            currentSelectedImage = value;
            creatureImage.sprite = currentSelectedImage.sprite;
        }
    }

    private void Start()
    {
        currentSelectedImage = creatureImage;
    }



}
