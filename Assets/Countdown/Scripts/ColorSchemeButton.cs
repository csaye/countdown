using UnityEngine;

namespace Countdown
{
    public class ColorSchemeButton : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorScheme.Scheme scheme = new ColorScheme.Scheme();
        [SerializeField] private Color mainColor = new Color(), midColor = new Color(), minColor = new Color(), specialColor = new Color();

        [Header("References")]
        [SerializeField] private ColorScheme colorScheme = null;

        private void Start()
        {
            if (PlayerPrefs.GetInt("ColorScheme", 0) == (int)scheme)
            {
                colorScheme.SetColorScheme(scheme, mainColor, midColor, minColor, specialColor);
            }
        }

        public void OnClick()
        {
            colorScheme.SetColorScheme(scheme, mainColor, midColor, minColor, specialColor);
        }
    }
}
