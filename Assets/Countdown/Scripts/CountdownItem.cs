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
        private const string timeUpString = "00<size=32>y</size> 000<size=32>d</size> 00<size=32>h</size> 00<size=32>m</size> 00<size=32>s</size>";

        private DateTime countdownTime, currentDateTime;
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
            tickClock = true;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!tickClock) return;
            currentDateTime = DateTime.Now;
            if (currentDateTime.Second == lastUpdateSecond) return;
            SetCountdownText();
        }

        private void SetCountdownText()
        {
            if (currentDateTime.CompareTo(countdownTime) >= 0)
            {
                countdownText.text = timeUpString;
                tickClock = false;
                return;
            }
            years = countdownTime.Year - currentDateTime.Year;
            countdownLength = countdownTime - currentDateTime.AddYears(years);
            days = countdownLength.Days;
            hours = countdownLength.Hours;
            minutes = countdownLength.Minutes;
            seconds = countdownLength.Seconds;
            StringBuilder sb = new StringBuilder();

            if (years < 10) sb.Append(0);
            sb.Append($"{years.ToString()}{startSmallString}y{endSmallString} ");
            if (days < 100) sb.Append(0);
            if (days < 10) sb.Append(0);
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
