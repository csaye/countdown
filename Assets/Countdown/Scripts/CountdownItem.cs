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

        private const string timeUpString = "00<size=32>y</size> 000<size=32>d</size> 00<size=32>h</size> 00<size=32>m</size> 00<size=32>s</size>";

        private DateTime countdownTime, currentDateTime;
        private TimeSpan countdownLength;
        private int lastUpdateSecond = -1;

        private bool tickClock = false;

        public void Initialize(string title, DateTime dateTime)
        {
            titleText.text = title;
            countdownTime = dateTime;

            currentDateTime = DateTime.Now;
            SetCountdownText();
            tickClock = true;
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
            countdownLength = countdownTime - currentDateTime;
            StringBuilder sb = new StringBuilder();
            countdownText.text = sb.ToString();
        }
    }
}
