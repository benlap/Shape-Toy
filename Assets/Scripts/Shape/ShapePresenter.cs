using UnityEngine;
using DG.Tweening;

namespace ShapeToy
{
    public class ShapePresenter : MonoBehaviour
    {
        [SerializeField]
        private RandomColorStore colorStore = null;
        [SerializeField]
        private ShapeStore shapeStore = null;

        [SerializeField]
        private Transform centeredTransformTarget = null;
        [SerializeField]
        private Transform asideTransformTarget = null;
        [SerializeField]
        private float animationDuration = .5f;

        [SerializeField]
        private ShapeController currentShape = null;

        public void MoveShapeToCenter()
        {
            transform.DOMove(centeredTransformTarget.position, animationDuration);
        }

        public void MoveShapeToAside()
        {
            transform.DOMove(asideTransformTarget.position, animationDuration);
        }

        private void Start()
        {
            Initialize();

        }

        private void Initialize()
        {
            GetComponentInChildren<IDoubleClickListener>().AddListener(RandomizeShapeColor);
            currentShape = GetComponentInChildren<ShapeController>();

            StartSwayAnimation();
        }

        private void StartSwayAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(0, 0, 90f), 8f, RotateMode.LocalAxisAdd));
            sequence.SetLoops(-1, LoopType.Yoyo);
        }

        public void ShowShape(Shape shape)
        {
            //var newShape = shapeStore.GetShapePrefab()

            //Get shape prefab from store
            MoveShapeToCenter();
            //Initialize prefab

        }

        private void RandomizeShapeColor()
        {
            var color = colorStore.GetNextColor();
            currentShape.SetColor(color);
        }


    }
}