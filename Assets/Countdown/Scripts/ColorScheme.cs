using UnityEngine;

namespace Countdown
{
    public class ColorScheme : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorSchemeScriptable lightMode, darkMode;

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

        private void Start()
        {
            Scheme scheme = (Scheme)PlayerPrefs.GetInt("ColorScheme", 0);
            SetColorScheme(scheme);
        }

        public void SetColorScheme(Scheme scheme)
        {
            PlayerPrefs.SetInt("ColorScheme", (int)scheme);

            switch (scheme)
            {
                case Scheme.LightMode:
                    SetColor(lightMode);
                case Scheme.DarkMode:
                    SetColor(darkMode);
            }

            UpdateColorScheme();
        }

        private void SetColor(ColorSchemeScriptable scheme)
        {
            SetMaxColor(scheme.maxColor);
            SetMidColor(scheme.midColor);
            SetMinColor(scheme.minColor);
            SetSpecialColor(scheme.specialColor);
        }

        private void UpdateColorScheme()
        {

        }
    }
}
