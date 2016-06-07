using System.Collections;
using System.Collections.Generic;

using UnityEngine;


/// <summary>
/// The canvas manager.
/// </summary>
public class CanvasManager : MonoBehaviour
{
    /// <summary>
    /// List of the different menu panels or canvases
    /// </summary>
    [SerializeField]
    private List<CanvasGroup> canvases;

    /// <summary>
    /// The previously selected canvas.
    /// </summary>
    private CanvasGroup previousSelectedCanvas;

    private CanvasGroup currentSelectedCanvas;

    public CanvasGroup CurrentSelectedCanvas
    {
        get
        {
            return currentSelectedCanvas;
        }
        set
        {
            if (value == currentSelectedCanvas) return;

            previousSelectedCanvas = currentSelectedCanvas;
            currentSelectedCanvas = value;
            Transition();
        }
    }

    /// <summary>
    /// The start.
    /// </summary>
    void Start()
    {
        if (canvases.Count == 0)
        {
            throw new System.Exception("Why are you trying to manage 0 canvases you dolt");
        }

        foreach (var canvas in canvases)
        {
            DisableCanvas(canvas);
        }

        if (currentSelectedCanvas == null)
        {
            CurrentSelectedCanvas = canvases[0];
        }

        Transition();
    }

    /// <summary>
    /// Disables the passed canvas
    /// </summary>
    /// <param name="canvas">
    /// The canvas.
    /// </param>
    private void DisableCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    /// <summary>
    /// Enables the passed canvas
    /// </summary>
    /// <param name="canvas">
    /// The canvas.
    /// </param>
    private void EnableCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

    /// <summary>
    /// Sets the transition animations for both previous and current selected canvases
    /// </summary>
    private void Transition()
    {
        if (previousSelectedCanvas != null)
        {
            //DisableCanvas(previousSelectedCanvas);
            StartCoroutine(FadeCanvas(previousSelectedCanvas, 0f, 0.2f, 0, true));
        }
        //EnableCanvas(currentSelectedCanvas);
        StartCoroutine(FadeCanvas(currentSelectedCanvas, 1f, 0.2f, 0.2f, false));
    }

    /// <summary>
    /// The fade.
    /// </summary>
    /// <param name="canvas">
    /// The canvas.
    /// </param>
    /// <param name="endValue">
    /// The value that the transition fades to
    /// </param>
    /// <param name="duration">
    /// The duration of the transition
    /// </param>
    /// <param name="waitTime">
    /// Set the time to wait before the transition starts
    /// </param>
    /// <param name="disable">
    /// Is this canvas going to be disabled or enabled?
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerator"/>.
    /// </returns>
    private IEnumerator FadeCanvas(CanvasGroup canvas, float endValue, float duration, float waitTime, bool disable)
    {
        yield return new WaitForSeconds(waitTime);
        float percent = 0;
        float fadeSpeed = 1 / duration;

        while (percent < 1)
        {
            percent += Time.deltaTime * fadeSpeed;

            canvas.alpha = Mathf.Lerp(canvas.alpha, endValue, percent);
            yield return null;
        }

        if (disable)
        {
            DisableCanvas(canvas);
        }
        else
        {
            EnableCanvas(canvas);
        }
    }
}

