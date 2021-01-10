using UnityEngine;

namespace ShapeToy
{
    public class ShapeController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer fill;

        public void SetColor(Color newColor)
        {
            fill.color = newColor;
        }
    }
}