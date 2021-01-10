using UnityEngine;

namespace ShapeToy
{
    [CreateAssetMenu(menuName = "Shape Data")]
    public class ShapeData : ScriptableObject
    {
        [SerializeField]
        private string displayName = null;
        [SerializeField]
        private Shape shape;
        [SerializeField]
        private GameObject prefab = null;
    }
}