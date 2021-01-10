using UnityEngine;
using DG.Tweening;

namespace ShapeToy
{
    public class ShapePresenter : MonoBehaviour
    {
        [SerializeField]
        private RandomColorStore colorStore;

        [SerializeField]
        private Transform centeredTransformTarget = null;
        [SerializeField]
        private Transform asideTransformTarget = null;
        [SerializeField]
        private float animationDuration = .5f;

        public void MoveShapeToCenter()
        {
            transform.DOMove(centeredTransformTarget.position, animationDuration);
        }

        public void MoveShapeToAside()
        {
            transform.DOMove(asideTransformTarget.position, animationDuration);
        }

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            GetComponentInChildren<IDoubleClickListener>().AddListener(RandomizeShapeColor);
        }

        public void ShowShape(Shape shape)
        {
            //Get shape prefab from store

            //Initialize prefab
        }

        private void RandomizeShapeColor()
        {
            var color = colorStore.GetNextColor();
            GetComponentInChildren<ShapeController>().SetColor(color);
        }


    }
}