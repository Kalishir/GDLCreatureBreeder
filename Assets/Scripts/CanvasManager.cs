using UnityEngine;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour {

    [SerializeField] private List<CanvasGroup> canvases;

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
        if (canvases.Count == 0)
            throw new System.Exception("Why are you trying to manage 0 canvases you dolt");

        foreach (var canvas in canvases)
        {
            DisableCanvas(canvas);
        }

        if (currentlySelectedCanvas == null)
        {
            currentlySelectedCanvas = canvases[0];
        }

        TransitionScreen();
    }

    private void DisableCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    private void EnableCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

    public void TransitionScreen()
    {
        if (previouslySelectedCanvas != null)
        {
            DisableCanvas(previouslySelectedCanvas);
        }
        EnableCanvas(currentlySelectedCanvas);
    }
}
