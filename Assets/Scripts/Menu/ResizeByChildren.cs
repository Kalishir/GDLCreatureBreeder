using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResizeByChildren : MonoBehaviour {

    [SerializeField] private int heightOfChildObject;
    private VerticalLayoutGroup layoutGroup;
    private int lastChildCount;

	// Use this for initialization
	void Start ()
    {
        layoutGroup = GetComponent<VerticalLayoutGroup>();
        UpdateSizing();
	}

    void Update()
    {
        if (transform.childCount != lastChildCount)
        {
            UpdateSizing();
            lastChildCount = transform.childCount;
        }
    }

    public void UpdateSizing()
    {
        RectTransform newSize = transform as RectTransform;
        int newHeight = (transform.childCount * heightOfChildObject) + (transform.childCount - 1) * layoutGroup.padding.vertical;
        newSize.sizeDelta = new Vector2(newSize.sizeDelta.x, newHeight);
        lastChildCount = transform.childCount;
    }
}
