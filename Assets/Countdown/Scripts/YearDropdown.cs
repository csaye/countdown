using TMPro;
using UnityEngine;

namespace Countdown
{
    public class YearDropdown : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Dropdown dropdown = null;

        public int currentYear { get; private set; }

        private void Start()
        {
            currentYear = System.DateTime.Today.Year;

            for (int i = 0; i <= 10; i++)
            {
                dropdown.options[i].text = (currentYear + i).ToString();
            }
        }
    }
}
