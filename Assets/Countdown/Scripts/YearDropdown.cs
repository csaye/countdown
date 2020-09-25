using TMPro;
using UnityEngine;

namespace Countdown
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class YearDropdown : MonoBehaviour
    {
        public int currentYear { get; private set; }

        private void Start()
        {
            currentYear = System.DateTime.Today.Year;
            
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();

            for (int i = 0; i <= 10; i++)
            {
                dropdown.options[i].text = (currentYear + i).ToString();
            }
        }
    }
}
