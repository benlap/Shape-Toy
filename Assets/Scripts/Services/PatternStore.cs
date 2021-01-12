using System.Collections.Generic;
using UnityEngine;

namespace ShapeToy
{
    public class PatternStore : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> patterns = null;
        private int currentPatternIndex = 0;
        public Sprite GetNextPattern()
        {
            currentPatternIndex++;
            if (currentPatternIndex >= patterns.Count)
                currentPatternIndex = 0;

            var nextPattern = patterns[currentPatternIndex];

            return nextPattern;
        }

        public Sprite GetCurrentPattern()
        {
            return patterns[currentPatternIndex];
        }
    }
}