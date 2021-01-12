using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ShapeToy
{
    public class SwipeGestureHandler : MonoBehaviour, IPointerDownHandler, ISwipeAnyDirectionListener
    {
        [SerializeField]
        private float swipeThreshold = 50f;
        [SerializeField]
        private float timeThreshold = 0.3f;

        [SerializeField]
        private UnityEvent OnSwipeLeft = null;
        [SerializeField]
        private UnityEvent OnSwipeRight = null;
        [SerializeField]
        private UnityEvent OnSwipeUp = null;
        [SerializeField]
        private UnityEvent OnSwipeDown = null;
        [SerializeField]
        private UnityEvent OnSwipeAnyDirection = null;

        private Vector2 fingerDown;
        private DateTime fingerDownTime;
        private Vector2 fingerUp;
        private DateTime fingerUpTime;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fingerDown = Input.mousePosition;
                fingerUp = Input.mousePosition;
                fingerDownTime = DateTime.Now;
            }

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerDown = touch.position;
                    fingerUp = touch.position;
                    fingerDownTime = DateTime.Now;
                }
            }
        }

        private void Update()
        {
            MouseUpUpdateStep();
            TouchUpdateStep();
        }

        private void MouseUpUpdateStep()
        {
            if (Input.GetMouseButtonUp(0))
            {
                fingerDown = Input.mousePosition;
                fingerUpTime = DateTime.Now;
                CheckSwipeDirection();
            }
        }

        private void TouchUpdateStep()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    fingerUpTime = DateTime.Now;
                    CheckSwipeDirection();
                }
            }
        }

        private void CheckSwipeDirection()
        {
            float duration = (float)fingerUpTime.Subtract(fingerDownTime).TotalSeconds;
            if (duration > timeThreshold) return;

            float deltaX = fingerDown.x - fingerUp.x;
            if (Mathf.Abs(deltaX) > swipeThreshold)
            {
                if (deltaX > 0)
                {
                    OnSwipeRight.Invoke();
                }
                else if (deltaX < 0)
                {
                    OnSwipeLeft.Invoke();
                }

                OnSwipeAnyDirection.Invoke();
            }

            float deltaY = fingerDown.y - fingerUp.y;
            if (Mathf.Abs(deltaY) > swipeThreshold)
            {
                if (deltaY > 0)
                {
                    OnSwipeUp.Invoke();
                }
                else if (deltaY < 0)
                {
                    OnSwipeDown.Invoke();
                }

                OnSwipeAnyDirection.Invoke();
            }

            fingerUp = fingerDown;
        }

        void ISwipeAnyDirectionListener.AddListener(UnityAction action)
        {
            OnSwipeAnyDirection.AddListener(action);
        }
    }
}