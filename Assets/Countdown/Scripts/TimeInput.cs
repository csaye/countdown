using System;
using TMPro;
using UnityEngine;

namespace Countdown
{
    public class TimeInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Dropdown hourDropdown = null;
        [SerializeField] private TMP_Dropdown twelveHourDropdown = null;
        [SerializeField] private TMP_Dropdown minuteDropdown = null;
        [SerializeField] private TMP_Dropdown secondDropdown = null;
        [SerializeField] private TMP_Dropdown ampmDropdown = null;

        public int hour
        {
            get
            {
                if (!useTwelveHourTime) return hourDropdown.value;
                return twelveHourDropdown.value + (ampmDropdown.value * 12);
            }
        }
        public int minute { get { return minuteDropdown.value; } }
        public int second { get { return secondDropdown.value; } }

        private bool useTwelveHourTime = false;

        private void Start()
        {
            for (int i = 0; i < 24; i++)
            {
                hourDropdown.options[i].text = i < 10 ? "0" + i.ToString() : i.ToString();
            }
        }

        public void UpdateTimeDisplay()
        {
            useTwelveHourTime = (PlayerPrefs.GetInt("UseTwelveHourTime", 0) == 1);

            // Activate dropdowns based on time system
            ampmDropdown.gameObject.SetActive(useTwelveHourTime);
            twelveHourDropdown.gameObject.SetActive(useTwelveHourTime);
            hourDropdown.gameObject.SetActive(!useTwelveHourTime);

            RectTransform rectTransform = (RectTransform)transform;
            rectTransform.localPosition = useTwelveHourTime ? new Vector2(-35, 0) : Vector2.zero;
        }
    }
}
