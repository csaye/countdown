using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Countdown
{
    public class ColorScheme : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorSchemeScriptable lightMode = null;
        [SerializeField] private ColorSchemeScriptable darkMode = null;
        [SerializeField] private ColorSchemeScriptable blueMode = null;

        [Header("References")]
        [SerializeField] private SubmitButton submitButton = null;

        [Header("Color References")]
        [SerializeField] private List<Image> maxColorImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> maxColorTexts = new List<TextMeshProUGUI>();
        [SerializeField] private List<Image> modColorImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> modColorTexts = new List<TextMeshProUGUI>();
        [SerializeField] private List<Image> midColorImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> midColorTexts = new List<TextMeshProUGUI>();
        [SerializeField] private List<Image> minColorImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> minColorTexts = new List<TextMeshProUGUI>();

        public static Color maxColor, modColor, midColor, minColor;

        public enum Scheme
        {
            LightMode,
            DarkMode,
            BlueMode
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
                case Scheme.BlueMode:
                    SetColor(blueMode);
                    break;
            }

            submitButton.UpdateActive();
        }

        private void SetColor(ColorSchemeScriptable scheme)
        {
            SetMaxColor(scheme.maxColor);
            SetModColor(scheme.modColor);
            SetMidColor(scheme.midColor);
            SetMinColor(scheme.minColor);
        }

        private void SetMaxColor(Color color)
        {
            maxColor = color;
            foreach (Image image in maxColorImages) image.color = color;
            foreach (TextMeshProUGUI text in maxColorTexts) text.color = color;
        }

        private void SetModColor(Color color)
        {
            modColor = color;
            foreach (Image image in modColorImages) image.color = color;
            foreach (TextMeshProUGUI text in modColorTexts) text.color = color;
        }

        private void SetMidColor(Color color)
        {
            midColor = color;
            foreach (Image image in midColorImages) image.color = color;
            foreach (TextMeshProUGUI text in midColorTexts) text.color = color;
        }

        private void SetMinColor(Color color)
        {
            minColor = color;
            foreach (Image image in minColorImages) image.color = color;
            foreach (TextMeshProUGUI text in minColorTexts) text.color = color;
        }
    }
}
