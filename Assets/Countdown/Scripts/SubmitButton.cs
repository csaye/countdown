using TMPro;
using UnityEngine;

namespace Countdown
{
    public class SubmitButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI text = null;
        [SerializeField] private TMP_InputField titleInput = null;
        [SerializeField] private TMP_Dropdown monthInput = null;
        [SerializeField] private TMP_Dropdown dayInput = null;
        [SerializeField] private TMP_Dropdown yearInput = null;
        [SerializeField] private YearDropdown yearDropdown = null;
        // [SerializeField] private CountdownList countdownList = null;

        private bool _active;
        private bool active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                text.color = active ? Color.blue : Color.gray;
            }
        }

        public void UpdateActive()
        {
            int month = monthInput.value + 1;
            int day = dayInput.value + 1;
            int year = yearInput.value + yearDropdown.currentYear;
        }

        public void OnClick()
        {
            
        }
    }
}
