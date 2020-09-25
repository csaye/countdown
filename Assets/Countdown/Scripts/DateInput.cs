using System;
using TMPro;
using UnityEngine;

namespace Countdown
{
    public class DateInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Dropdown yearDropdown = null;
        [SerializeField] private TMP_Dropdown monthDropdown = null;
        [SerializeField] private TMP_Dropdown dayDropdown = null;

        public int year { get { return yearDropdown.value + DateInput.currentYear; } }
        public int month { get { return monthDropdown.value + 1; } }
        public int day { get { return dayDropdown.value + 1; } }

        public static int currentYear { get; private set; }

        // Initialize all date dropdowns with current date
        private void Start()
        {
            DateTime now = System.DateTime.Now;

            currentYear = now.Year;

            for (int i = 0; i < 100; i++)
            {
                yearDropdown.options[i].text = (currentYear + i).ToString();
            }

            monthDropdown.value = now.Month - 1;
            dayDropdown.value = now.Day - 1;
        }
    }
}
