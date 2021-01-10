using UnityEngine;

namespace ShapeToy
{
    public class ShapePresenter : MonoBehaviour
    {
        [SerializeField]
        private RandomColorStore colorStore;

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