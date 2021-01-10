using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

namespace ShapeToy.UI
{
    public class ShapeMenu : MonoBehaviour
    {
        //Services
        [SerializeField]
        private ShapePresenter shapePresenter = null;
        [SerializeField]
        private ShapeStore shapeStore = null;

        //Animation
        [SerializeField]
        private RectTransform hideTransformTarget = null;
        [SerializeField]
        private RectTransform showTransformTarget = null;
        [SerializeField]
        private float animationDuration = .5f;
        
        //Button Setup
        [SerializeField]
        private RectTransform selectionsParent = null;
        [SerializeField]
        private GameObject selectionButtonPrefab = null;

        public void Show()
        {
            transform.DOMove(showTransformTarget.position, animationDuration);
        }

        public void Hide()
        {
            transform.DOMove(hideTransformTarget.position, animationDuration);
        }

        void Start()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            foreach (var data in shapeStore.GetShapeData())
            {
                var button = CreateButton(data);
                button.transform.SetParent(selectionsParent);
                button.transform.localScale = Vector3.one;
            }
        }

        private GameObject CreateButton(ShapeData data)
        {
            var go = Instantiate(selectionButtonPrefab);

            var button = go.GetComponent<Button>();
            button.onClick.AddListener(() => shapePresenter.ShowShape(data.shape));

            var text = go.GetComponentInChildren<TMP_Text>();
            text.text = data.displayName;
            
            return go;
        }
    }
}