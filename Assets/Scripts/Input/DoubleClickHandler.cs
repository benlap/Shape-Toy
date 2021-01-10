using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoubleClickHandler : MonoBehaviour,IPointerDownHandler, IDoubleClickListener
{
    private float clickCount = 0;
    private float clickTime = 0;
    private float clickDelay = 0.5f;

    private bool secondClickCameInTime { get { return clickCount > 1 && Time.time - clickTime < clickDelay; } }

    [SerializeField]
    private UnityEvent onDoubleClick = null;

    public void OnPointerDown(PointerEventData data)
    {
        clickCount++;

        if (clickCount == 1)
        {
            clickTime = Time.time;
        }

        if (secondClickCameInTime)
        {
            clickCount = 0;
            clickTime = 0;
            Debug.Log("Double click on " + name);
            onDoubleClick.Invoke();
        }
        else if (clickCount > 2 || Time.time - clickTime > 1)
        {
            clickCount = 0;
        }
    }

    void IDoubleClickListener.AddListener(UnityAction action)
    {
        onDoubleClick.AddListener(action);
    }
}