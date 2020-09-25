using UnityEngine;

namespace Countdown
{
    public class ColorSchemeButton : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private ColorScheme.Scheme scheme = new ColorScheme.Scheme();

        [Header("References")]
        [SerializeField] private ColorScheme colorScheme = null;
        [SerializeField] private RectTransform arrowTransform = null;

        public void OnClick()
        {
            if (PlayerPrefs.GetInt("ColorScheme", 0) == (int)scheme) return;
            colorScheme.SetColorScheme(scheme);
            arrowTransform.position = new Vector2(transform.position.x, arrowTransform.position.y);
        }
    }
}
