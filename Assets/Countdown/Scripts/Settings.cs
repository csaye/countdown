using UnityEngine;

namespace Countdown
{
    public class Settings : MonoBehaviour
    {
        public void SetAutomaticDelete(bool deleteAutomatically)
        {
            int deleteInt = deleteAutomatically ? 1 : 0;
            PlayerPrefs.SetInt("DeleteAutomatically", deleteInt);
        }
    }
}
