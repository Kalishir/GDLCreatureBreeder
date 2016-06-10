using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResizeByChildren : MonoBehaviour {

    [SerializeField] private int heightOfChildObject;
    private VerticalLayoutGroup layoutGroup;

	// Use this for initialization
	void Start ()
    {
        layoutGroup = GetComponent<VerticalLayoutGroup>();
        RectTransform newSize = transform as RectTransform;
        int newHeight = (transform.childCount * heightOfChildObject) + (transform.childCount - 1) * layoutGroup.padding.vertical;
        newSize.sizeDelta = new Vector2(newSize.sizeDelta.x, newHeight);
	}

}
