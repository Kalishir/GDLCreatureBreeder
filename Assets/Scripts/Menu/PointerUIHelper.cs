using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PointerUIHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler, IPointerClickHandler
{

    [SerializeField] private UnityEvent onPointerEnter = new UnityEvent();
    [SerializeField] private UnityEvent onPointerExit = new UnityEvent();
    [SerializeField] private UnityEvent onPointerDown = new UnityEvent();
    [SerializeField] private UnityEvent onPointerUp = new UnityEvent();
    [SerializeField] private UnityEvent onPointerClick = new UnityEvent();


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
