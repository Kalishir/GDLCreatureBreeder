using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResizeByChildren : MonoBehaviour {

    [SerializeField] private int heightOfChildObject;
    private GridLayoutGroup layoutGroup;
    private int lastChildCount = 0;

	// Use this for initialization
	void Start ()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
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
        int newHeight = ( Mathf.CeilToInt(transform.childCount/4f) * heightOfChildObject) + (Mathf.CeilToInt(transform.childCount/4f) + 1) * Mathf.RoundToInt(layoutGroup.spacing.y);
        newHeight += layoutGroup.padding.top + layoutGroup.padding.bottom;
        var parent = transform.parent as RectTransform;
        newHeight -= Mathf.RoundToInt(parent.rect.height);
        newSize.sizeDelta = new Vector2(newSize.sizeDelta.x, newHeight);
        lastChildCount = transform.childCount;
    }
}
