using DG.Tweening;
using UnityEngine;

public class PulseAnimation : MonoBehaviour
{
    [SerializeField]
    private float animationDuration = 1;

    void Start()
    {
        StartPulseAnimation();
    }

    private void StartPulseAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one * 1.2f, animationDuration));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
