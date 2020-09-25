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
        [SerializeField] private List<Image> specialColorImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> specialColorTexts = new List<TextMeshProUGUI>();

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

            submitButton.UpdateActive();
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

        private void SetSpecialColor(Color color)
        {
            specialColor = color;
            foreach (Image image in specialColorImages) image.color = color;
            foreach (TextMeshProUGUI text in specialColorTexts) text.color = color;
        }
    }
}
