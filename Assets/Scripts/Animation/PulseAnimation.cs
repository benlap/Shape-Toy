using DG.Tweening;
using UnityEngine;

namespace ShapeToy
{
    public class PulseAnimation : MonoBehaviour
    {
        [SerializeField]
        private float animationDuration = 1;
        private Sequence currentAnimation;

        void Start()
        {
            StartPulseAnimation();
        }

        private void StartPulseAnimation()
        {
            currentAnimation = DOTween.Sequence();
            currentAnimation.Append(transform.DOScale(Vector3.one * 1.2f, animationDuration));
            currentAnimation.SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            currentAnimation.Kill();
        }
    }
}