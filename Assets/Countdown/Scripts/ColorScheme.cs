using UnityEngine;

namespace Countdown
{
    public class ColorScheme : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorSchemeScriptable lightMode = null;
        [SerializeField] private ColorSchemeScriptable darkMode = null;

        // [Header("Max Color References")]
        // [Header("Mid Color References")]
        // [Header("Min Color References")]
        // [Header("Special Color References")]

        public static Color maxColor, modColor, midColor, minColor, specialColor;

        public enum Scheme
        {
            LightMode,
            DarkMode
        }

        private void Start()
        {
            // Loads last used color scheme
            Scheme scheme = (Scheme)PlayerPrefs.GetInt("ColorScheme", 0);
            SetColorScheme(scheme);
        }

        public void SetColorScheme(Scheme scheme)
        {
            // Saves color scheme for reload
            PlayerPrefs.SetInt("ColorScheme", (int)scheme);

            switch (scheme)
            {
                case Scheme.LightMode:
                    SetColor(lightMode);
                    break;
                case Scheme.DarkMode:
                    SetColor(darkMode);
                    break;
            }
        }

        private void SetColor(ColorSchemeScriptable scheme)
        {
            SetMaxColor(scheme.maxColor);
            SetModColor(scheme.modColor);
            SetMidColor(scheme.midColor);
            SetMinColor(scheme.minColor);
            SetSpecialColor(scheme.specialColor);
        }

        private void SetMaxColor(Color color)
        {
            maxColor = color;
        }

        private void SetModColor(Color color)
        {
            modColor = color;
        }

        private void SetMidColor(Color color)
        {
            midColor = color;
        }

        private void SetMinColor(Color color)
        {
            minColor = color;
        }

        private void SetSpecialColor(Color color)
        {
            specialColor = color;
        }
    }
}
