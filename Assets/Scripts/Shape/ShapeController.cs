using UnityEngine;

namespace ShapeToy
{
    public class ShapeController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer fill = null;
        [SerializeField]
        private SpriteRenderer pattern = null;

        public void SetPattern(Sprite newPattern)
        {
            pattern.sprite = newPattern;
        }

        public void SetColor(Color newColor)
        {
            fill.color = newColor;
        }

        public void Destroy()
        {
            Destroy(pattern); //cleanup the object that uses Dotween to animate

            Destroy(gameObject);    
        }
    }
}