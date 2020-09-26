using System;
using System.Collections.Generic;
using UnityEngine;

namespace Countdown
{
    public class CountdownList : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject countdownPrefab = null;
        [SerializeField] private FileHandler fileHandler = null;

        private List<CountdownItem> countdowns = new List<CountdownItem>();
        private DateTime now, currentDateTime;
        private int lastUpdateSecond = -1;

        public void Initialize(CountdownObject[] countdowns)
        {
            foreach (CountdownObject countdown in countdowns)
            {
                CreateCountdown(countdown.title, countdown.dateTime, false);
            }
        }

        // Instantiates and initializes a new countdown item object
        public void CreateCountdown(string title, DateTime dateTime, bool addToFile)
        {
            GameObject countdownObj = Instantiate(countdownPrefab, transform.position, Quaternion.identity, transform);
            CountdownItem countdownItem = countdownObj.GetComponent<CountdownItem>();
            countdownItem.Initialize(this, title, dateTime);
            countdowns.Add(countdownItem);
            countdownObj.transform.SetSiblingIndex(0);
            if (addToFile) fileHandler.AddCountdown(title, dateTime);
            UpdateCountdowns();
        }

        private void Update()
        {
            now = DateTime.Now;
            currentDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            // Only tick once a second
            if (currentDateTime.Second == lastUpdateSecond) return;
            lastUpdateSecond = currentDateTime.Second;
            UpdateCountdowns();
        }

        public void UpdateCountdowns()
        {
            for (int i = 0; i < countdowns.Count; i++)
            {
                // Delete item from countdowns if null
                if (countdowns[i] == null)
                {
                    countdowns.RemoveAt(i);
                    fileHandler.RemoveCountdownAt(i);
                    i--;
                    continue;
                }
                countdowns[i].SetCountdownText(currentDateTime);
            }
        }
    }
}
