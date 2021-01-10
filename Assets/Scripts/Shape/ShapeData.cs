using UnityEngine;

namespace ShapeToy
{
    [CreateAssetMenu(menuName = "Shape Data")]
    public class ShapeData : ScriptableObject
    {
        public string displayName = null;
        public Shape shape;
        public GameObject prefab = null;
    }
}