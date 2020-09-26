using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Countdown
{
    public class SubmitButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Button button = null;
        [SerializeField] private TextMeshProUGUI text = null;
        [SerializeField] private TMP_InputField titleInput = null;
        [SerializeField] private DateInput dateInput = null;
        [SerializeField] private TimeInput timeInput = null;
        [SerializeField] private CountdownList countdownList = null;
        [SerializeField] private ColorSchemeScriptable lightMode = null;

        private DateTime dateTime;

        public void UpdateActive()
        {
            // Return if no title given
            if (string.IsNullOrWhiteSpace(titleInput.text))
            {
                button.interactable = false;
                text.color = lightMode.midColor;
                return;
            }

            int year = dateInput.year;
            int month = dateInput.month;
            int day = dateInput.day;

            int hour = timeInput.hour;
            int minute = timeInput.minute;
            int second = timeInput.second;
            
            try
            {
                dateTime = new DateTime(year, month, day, hour, minute, second);
                button.interactable = true;
                text.color = lightMode.minColor;
            }
            // Return if invalid date given
            catch
            {
                button.interactable = false;
                text.color = lightMode.midColor;
            }
        }

        public void OnClick()
        {
            countdownList.CreateCountdown(titleInput.text, dateTime, true);
        }
    }
}
