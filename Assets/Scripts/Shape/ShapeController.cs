using UnityEngine;

namespace ShapeToy
{
    public class ShapeController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer fill = null;

        public void SetColor(Color newColor)
        {
            fill.color = newColor;
        }

        public void Destroy()
        {
            Destroy(gameObject);    
        }
    }
}