using UnityEngine;

namespace Countdown
{
    [CreateAssetMenu(fileName = "Color Scheme", menuName = "Scriptables/Color Scheme")]
    public class ColorSchemeScriptable : ScriptableObject
    {
        public Color maxColor, modColor, midColor, minColor;
    }
}
