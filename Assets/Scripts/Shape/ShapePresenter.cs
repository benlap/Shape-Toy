using UnityEngine;
using DG.Tweening;

namespace ShapeToy
{
    public class ShapePresenter : MonoBehaviour
    {
        //Services
        [SerializeField]
        private RandomColorStore colorStore = null;
        [SerializeField]
        private ShapeStore shapeStore = null;
        [SerializeField]
        private SoundEffects sfx = null;
        
        //Animation
        [SerializeField]
        private Transform centeredTransformTarget = null;
        [SerializeField]
        private Transform asideTransformTarget = null;
        [SerializeField]
        private float animationDuration = .5f;

        //Cache
        [SerializeField]
        private ShapeController currentShape = null;

        public void ShowShape(Shape shape)
        {
            DestroyCurrentShape();

            sfx.PlayChangeShape();

            var newShape = shapeStore.GetShapePrefab(shape);

            var go = Instantiate(newShape, transform);
            go.transform.localPosition = Vector3.zero;

            go.GetComponentInChildren<IDoubleClickListener>().AddListener(RandomizeShapeColor);
            currentShape = go.GetComponent<ShapeController>();
        }

        private void DestroyCurrentShape()
        {
            if (currentShape != null)
            {
                currentShape.Destroy();
                currentShape = null;
            }
        }

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

        private void RandomizeShapeColor()
        {
            sfx.PlayChangeColor();
            var color = colorStore.GetNextColor();
            currentShape.SetColor(color);
        }


    }
}