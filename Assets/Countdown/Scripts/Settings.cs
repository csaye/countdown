using UnityEngine;
using UnityEngine.UI;

namespace Countdown
{
    public class Settings : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CountdownList countdownList = null;
        [SerializeField] private Toggle deleteAutomaticallyToggle = null;

        // Initialize settings by setting proper components
        private void Start()
        {
            deleteAutomaticallyToggle.isOn = (PlayerPrefs.GetInt("DeleteAutomatically", 0) == 1);
        }

        public void SetAutomaticDelete(bool deleteAutomatically)
        {
            int deleteInt = deleteAutomatically ? 1 : 0;
            PlayerPrefs.SetInt("DeleteAutomatically", deleteInt);
            countdownList.UpdateCountdowns();
        }
    }
}
