using UnityEngine;

namespace PirateGame.Data.UI
{
    [CreateAssetMenu(fileName = "Custom Button Data", menuName = "UI/new Custom Button Data")]
    public class CustomButtonData : ScriptableObject
    {
        [SerializeField] private float _scaleMultiplierOnMouseEnter = 1.1f;

        public float ScaleMultiplierOnMouseEnter { get { return _scaleMultiplierOnMouseEnter; } }
    }
}

