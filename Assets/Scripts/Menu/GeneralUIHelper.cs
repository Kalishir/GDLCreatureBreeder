using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GeneralUIHelper : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// The start method
    /// </summary>
    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Quick and simple SFX Player for UI elements
    /// </summary>
    /// <param name="clip">
    /// The clip.
    /// </param>
    public void PlaySound(AudioClip clip)
    {
        this.audioSource.clip = clip;
        this.audioSource.Play();
    }

    public void ScaleUp(Graphic graphic)
    {
        StartCoroutine(ScaleAnimation(graphic, 1.1f, 0.2f, 0f));
    }

    public void ScaleBack(Graphic graphic)
    {
        StartCoroutine(ScaleAnimation(graphic, 1f, 0.2f, 0f));
    }

    private IEnumerator ScaleAnimation(Graphic graphic, float endValue, float duration, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        float percent = 0;
        float fadeSpeed = 1 / duration;

        while (percent < 1)
        {
            percent += Time.deltaTime * fadeSpeed;

            graphic.rectTransform.localScale = Vector3.Lerp(graphic.rectTransform.localScale, Vector3.one * endValue, percent);
            yield return null;
        }

    }


}
