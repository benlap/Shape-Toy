using System.Collections.Generic;
using UnityEngine;

namespace ShapeToy
{
    public class RandomColorStore : MonoBehaviour
    {
        [SerializeField]
        private List<Color> colors = null;

        private int currentColorIndex = 0;

        public Color GetNextColor()
        {
            currentColorIndex++;
            if (currentColorIndex >= colors.Count)
                currentColorIndex = 0;

            var nextColor = colors[currentColorIndex];

            return nextColor;
        }

        public Color GetCurrentColor()
        {
            return colors[currentColorIndex];
        }
    }
}