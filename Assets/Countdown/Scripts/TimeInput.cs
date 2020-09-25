using TMPro;
using UnityEngine;

namespace Countdown
{
    public class TimeInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Dropdown hourDropdown = null;
        [SerializeField] private TMP_Dropdown minuteDropdown = null;
        [SerializeField] private TMP_Dropdown secondDropdown = null;

        public int hour { get { return hourDropdown.value; } }
        public int minute { get { return minuteDropdown.value; } }
        public int second { get { return secondDropdown.value; } }
    }
}
