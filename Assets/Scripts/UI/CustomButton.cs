using PirateGame.Data.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PirateGame.UI
{
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Vector3 _defaultSize;

        [SerializeField] private CustomButtonData _customButtonData;

        private void Awake()
        {
            _defaultSize = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = _defaultSize * _customButtonData.ScaleMultiplierOnMouseEnter;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = _defaultSize;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            transform.localScale = _defaultSize;
        }
    }
}
