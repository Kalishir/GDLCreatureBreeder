using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PointerUIHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler, IPointerClickHandler
{

    //These need to be public so we can add listeners to them.
    [SerializeField] public UnityEvent onPointerEnter = new UnityEvent();
    [SerializeField] public UnityEvent onPointerExit = new UnityEvent();
    [SerializeField] public UnityEvent onPointerDown = new UnityEvent();
    [SerializeField] public UnityEvent onPointerUp = new UnityEvent();
    [SerializeField] public UnityEvent onPointerClick = new UnityEvent();


    public void OnPointerEnter(PointerEventData eventData)
    {
        var selectable = GetComponent<Selectable>();
        if ((selectable != null && selectable.IsInteractable()) || selectable == null)
            onPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var selectable = GetComponent<Selectable>();
        if ((selectable != null && selectable.IsInteractable()) || selectable == null)
            onPointerExit.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var selectable = GetComponent<Selectable>();
        if ((selectable != null && selectable.IsInteractable()) || selectable == null)
            onPointerDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var selectable = GetComponent<Selectable>();
        if ((selectable != null && selectable.IsInteractable()) || selectable == null)
            onPointerUp.Invoke();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        var selectable = GetComponent<Selectable>();
        if ((selectable != null && selectable.IsInteractable()) || selectable == null)
            onPointerClick.Invoke();
    }
}
