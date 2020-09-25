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
        [SerializeField] private TMP_Dropdown monthInput = null;
        [SerializeField] private TMP_Dropdown dayInput = null;
        [SerializeField] private TMP_Dropdown yearInput = null;
        [SerializeField] private YearDropdown yearDropdown = null;
        // [SerializeField] private CountdownList countdownList = null;

        public void UpdateActive()
        {
            int month = monthInput.value + 1;
            int day = dayInput.value + 1;
            int year = yearInput.value + yearDropdown.currentYear;
            
            try
            {
                DateTime date = new DateTime(year, month, day);
                button.enabled = true;
                text.color = ColorScheme.specialColor;
            }
            catch
            {
                button.enabled = false;
                text.color = ColorScheme.midColor;
            }
        }

        public void OnClick()
        {
            
        }
    }
}
