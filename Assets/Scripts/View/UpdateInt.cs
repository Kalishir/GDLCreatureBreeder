using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateInt : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
    }

    public void UpdateValue(int newValue)
    {
        if (text != null)
            text.text = newValue.ToString();
    }
}
