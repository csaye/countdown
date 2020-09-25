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

        public int year { get { return yearDropdown.value + YearDropdown.currentYear; } }
        public int month { get { return monthDropdown.value + 1; } }
        public int day { get { return dayDropdown.value + 1; } }
    }
}
