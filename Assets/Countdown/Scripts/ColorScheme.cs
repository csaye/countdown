using UnityEngine;

namespace Countdown
{
    public class ColorScheme : MonoBehaviour
    {
        // [Header("Max Color References")]
        // [Header("Mid Color References")]
        // [Header("Min Color References")]
        // [Header("Special Color References")]

        public static Color maxColor, midColor, minColor, specialColor;

        public enum Scheme
        {
            LightMode,
            DarkMode
        }

        public void SetColorScheme(Scheme scheme, Color _maxColor, Color _midColor, Color _minColor, Color _specialColor)
        {
            PlayerPrefs.SetInt("ColorScheme", (int)scheme);
            UpdateColorScheme();
        }

        private void UpdateColorScheme()
        {

        }
    }
}
