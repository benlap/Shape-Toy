using UnityEngine;

namespace ShapeToy
{
    public class SoundEffects : MonoBehaviour
    {
        [SerializeField]
        private AudioSource changeShape = null;

        [SerializeField]
        private AudioSource changeColor = null;

        [SerializeField]
        private AudioSource changePattern = null;

        public void PlayChangeColor()
        {
            changeColor.Play();
        }

        public void PlayChangePattern()
        {
            changePattern.Play();
        }

        public void PlayChangeShape()
        {
            changeShape.Play();
        }
    }
}
