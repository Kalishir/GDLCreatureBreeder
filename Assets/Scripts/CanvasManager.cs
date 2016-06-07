using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour {

    [SerializeField] private List<CanvasGroup> canvases;
    //[SerializeField] private GameObject storeCanvas;
    //[SerializeField] private GameObject managementCanvas;

    private CanvasGroup previouslySelectedCanvas;
    private CanvasGroup currentlySelectedCanvas;

    public CanvasGroup CurrentlySelectedCanvas
    {
        get
        {
            return currentlySelectedCanvas;
        }
        set
        {
            if (value == currentlySelectedCanvas)
                return;

            previouslySelectedCanvas = currentlySelectedCanvas;
            currentlySelectedCanvas = value;
            TransitionScreen();
        }
    }
    
    void Start()
    {
        foreach (var canvas in canvases)
        {
            canvas.alpha = 0;
        }
        if (currentlySelectedCanvas == null)
        {
            currentlySelectedCanvas = canvases[0];
        }
        TransitionScreen();
    }

    public void TransitionScreen()
    {
        if (previouslySelectedCanvas != null)
        {
            previouslySelectedCanvas.alpha = 0;
        }
        currentlySelectedCanvas.alpha = 1;
    }
}
