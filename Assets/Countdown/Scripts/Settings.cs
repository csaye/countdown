using UnityEngine;
using UnityEngine.UI;

namespace Countdown
{
    public class Settings : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CountdownList countdownList = null;
        [SerializeField] private TimeInput timeInput = null;
        [SerializeField] private Toggle deleteAutomaticallyToggle = null, useTwelveHourTimeToggle = null;

        // Initialize settings by setting proper components
        private void Start()
        {
            deleteAutomaticallyToggle.isOn = (PlayerPrefs.GetInt("DeleteAutomatically", 0) == 1);
            useTwelveHourTimeToggle.isOn = (PlayerPrefs.GetInt("UseTwelveHourTime", 0) == 1);
        }

        public void SetDeleteAutomatically(bool deleteAutomatically)
        {
            int deleteInt = deleteAutomatically ? 1 : 0;
            PlayerPrefs.SetInt("DeleteAutomatically", deleteInt);
            countdownList.UpdateCountdowns();
        }

        public void SetUseTwelveHourTime(bool useTwelveHourTime)
        {
            int useInt = useTwelveHourTime ? 1 : 0;
            PlayerPrefs.SetInt("UseTwelveHourTime", useInt);
            timeInput.UpdateTimeDisplay();
        }
    }
}
