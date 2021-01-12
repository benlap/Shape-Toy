using UnityEngine.Events;

namespace ShapeToy
{
    public interface ISwipeAnyDirectionListener
    {
        void AddListener(UnityAction action);
    }
}