using System.Collections.Generic;
using UnityEngine;

namespace ShapeToy
{
    public class RandomColorStore : MonoBehaviour
    {
        [SerializeField]
        private List<Color> colors;

        private int currentColorIndex = 0;

        public Color GetNextColor()
        {
            if (currentColorIndex >= colors.Count)
                currentColorIndex = 0;

            var nextColor = colors[currentColorIndex];
            currentColorIndex++;

            return nextColor;
        }

    }
}