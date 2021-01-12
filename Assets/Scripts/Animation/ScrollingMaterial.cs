using UnityEngine;

namespace ShapeToy
{
    public class ScrollingMaterial : MonoBehaviour
    {
        [SerializeField]
        private Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
        [SerializeField]
        private new Renderer renderer = null;

        private int materialIndex = 0;
        private string textureName = "_MainTex";
        private Vector2 uvOffset = Vector2.zero;

        void LateUpdate()
        {
            uvOffset += (uvAnimationRate * Time.deltaTime);
            if (renderer.enabled)
            {
                renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
            }
        }
    }
}