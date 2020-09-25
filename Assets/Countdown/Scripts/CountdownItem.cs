using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Countdown
{
    public class CountdownItem : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI titleText = null;
        [SerializeField] TextMeshProUGUI countdownText = null;

        private const string startSmallString = "<size=32>", endSmallString = "</size>";
        private const string timeUpString = "0<size=32>d</size> 00<size=32>h</size> 00<size=32>m</size> 00<size=32>s</size>";

        private DateTime countdownTime, now;
        private TimeSpan countdownLength;
        int days, hours, minutes, seconds;

        public void Initialize(string title, DateTime dateTime)
        {
            titleText.text = title;
            countdownTime = dateTime;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetCountdownText(DateTime currentDateTime)
        {
            // If time reached, stop clock tick
            if (currentDateTime.CompareTo(countdownTime) >= 0)
            {
                if (PlayerPrefs.GetInt("DeleteAutomatically", 0) == 1) Destroy();
                countdownText.text = timeUpString;
                return;
            }

            // Calculate interval using System.TimeSpan class
            countdownLength = countdownTime - currentDateTime;
            days = countdownLength.Days;
            hours = countdownLength.Hours;
            minutes = countdownLength.Minutes;
            seconds = countdownLength.Seconds;

            StringBuilder sb = new StringBuilder();

            // Convert time span into readable format
            sb.Append($"{days.ToString()}{startSmallString}d{endSmallString} ");
            if (hours < 10) sb.Append(0);
            sb.Append($"{hours.ToString()}{startSmallString}h{endSmallString} ");
            if (minutes < 10) sb.Append(0);
            sb.Append($"{minutes.ToString()}{startSmallString}m{endSmallString} ");
            if (seconds < 10) sb.Append(0);
            sb.Append($"{seconds.ToString()}{startSmallString}s{endSmallString}");

            countdownText.text = sb.ToString();
        }
    }
}
