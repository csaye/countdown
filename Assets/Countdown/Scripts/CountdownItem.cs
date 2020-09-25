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

        private DateTime countdownTime, currentDateTime, now;
        private TimeSpan countdownLength;
        private int lastUpdateSecond = -1;
        int years, days, hours, minutes, seconds;

        private bool tickClock = false;

        public void Initialize(string title, DateTime dateTime)
        {
            titleText.text = title;
            countdownTime = dateTime;
            currentDateTime = DateTime.Now;
            SetCountdownText();
            // Start clock tick
            tickClock = true;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!tickClock) return;

            // Necessary to ensure milliseconds of current time is zero
            now = DateTime.Now;
            currentDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            
            // Only tick once a second
            if (currentDateTime.Second == lastUpdateSecond) return;
            lastUpdateSecond = currentDateTime.Second;
            SetCountdownText();
        }

        private void SetCountdownText()
        {
            // If time reached, stop clock tick
            if (currentDateTime.CompareTo(countdownTime) >= 0)
            {
                countdownText.text = timeUpString;
                tickClock = false;
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
