using System;
using UnityEngine;

namespace Countdown
{
    public class CountdownList : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject countdownPrefab = null;

        // Creates and initializes a new countdown item object
        public void CreateCountdown(string title, DateTime time)
        {
            GameObject countdownObj = Instantiate(countdownPrefab, transform.position, Quaternion.identity, transform);
            countdownObj.GetComponent<CountdownItem>().Initialize(title, time);
        }
    }
}
