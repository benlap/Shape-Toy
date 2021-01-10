using System.Collections.Generic;
using UnityEngine;

namespace ShapeToy
{
    public class ShapeStore : MonoBehaviour
    {
        [SerializeField]
        private List<ShapeData> shapeData = null;

        [SerializeField]
        private Dictionary<Shape, GameObject> shapePrefabs = null;

        public GameObject GetShapePrefab(Shape shape)
        {
            return shapePrefabs[shape];
        }

        public List<ShapeData> GetShapeData() 
        { 
            return shapeData; 
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            shapePrefabs = new Dictionary<Shape, GameObject>();

            foreach (var data in shapeData)
                shapePrefabs.Add(data.shape, data.prefab);
        }
    }
}