using UnityEngine;

namespace Countdown
{
    public class ColorSchemeButton : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorScheme.Scheme scheme = new ColorScheme.Scheme();

        [Header("References")]
        [SerializeField] private ColorScheme colorScheme = null;

        public void OnClick()
        {
            colorScheme.SetColorScheme(scheme);
        }
    }
}
