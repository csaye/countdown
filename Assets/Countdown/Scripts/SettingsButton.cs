using TMPro;
using UnityEngine;

namespace Countdown
{
    public class SettingsButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI text = null;
        [SerializeField] private CanvasGroup settingsCanvasGroup = null;

        private bool active = false;

        public void OnClick()
        {
            active = !active;
            settingsCanvasGroup.alpha = active ? 1 : 0;
            settingsCanvasGroup.blocksRaycasts = active;
            text.text = active ? "Back" : "Settings";
        }
    }
}
