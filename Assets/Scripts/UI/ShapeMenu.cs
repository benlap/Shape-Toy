using UnityEngine;
using DG.Tweening;

public class ShapeMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform hideTransformTarget = null;
    [SerializeField]
    private RectTransform showTransformTarget = null;
    [SerializeField]
    private float animationDuration = .5f;


    void Start()
    {
        
    }

    public void Show()
    {
        transform.DOMove(showTransformTarget.position, animationDuration);
    }

    public void Hide()
    {
        transform.DOMove(hideTransformTarget.position, animationDuration);
    }

}
