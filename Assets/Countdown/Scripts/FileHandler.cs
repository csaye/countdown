using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Countdown
{
    public struct CountdownObject
    {
        public CountdownObject(string _title, DateTime _dateTime)
        {
            title = _title;
            dateTime = _dateTime;
        }

        public string title;
        public DateTime dateTime;
    }

    public class FileHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CountdownList countdownList = null;

        private List<CountdownObject> countdowns = new List<CountdownObject>();

        private string path;

        public void AddCountdown(string title, DateTime dateTime)
        {
            CountdownObject countdown = new CountdownObject(title, dateTime);
            countdowns.Add(countdown);
        }

        public void RemoveCountdownAt(int index)
        {
            countdowns.RemoveAt(index);
        }

        private void WriteFile()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (CountdownObject countdown in countdowns)
            {
                writer.WriteLine(countdown.title);
                DateTime dt = countdown.dateTime;
                // Convert DateTime into easily parsable format
                string dateTimeString = $"{dt.Year}/{dt.Month}/{dt.Day}/{dt.Hour}/{dt.Minute}/{dt.Second}";
                writer.WriteLine(dateTimeString);
            }
            writer.Close();
        }

        private void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            countdowns.Clear();
            string content = reader.ReadToEnd();
            // Split lines by line breaks
            string[] rawLines = content.Split('\n');
            string[] lines = GetValidLines(rawLines);
            // Take lines in pairs
            for (int i = 0; i < lines.Length; i += 2)
            {
                // Get title from first line
                string title = lines[i];
                // Parse DateTime value from string
                string dateTimeString = lines[i + 1];
                DateTime dateTime = ParseDateTime(dateTimeString);
                // Create and add new countdown object with parsed parameters
                CountdownObject countdown = new CountdownObject(title, dateTime);
                countdowns.Add(countdown);
            }
            reader.Close();
        }

        // Takes a string array and returns all of its non-null and non-whitespace strings
        private string[] GetValidLines(string[] array)
        {
            List<string> lines = new List<string>();
            foreach (string s in array)
            {
                if (!string.IsNullOrWhiteSpace(s)) lines.Add(s);
            }
            return lines.ToArray();
        }

        // Takes a string representing date and time in y/mo/d/h/mi/s format and returns a DateTime object
        private DateTime ParseDateTime(string dateTimeString)
        {
            string[] dtStrs = dateTimeString.Split('/');
            int[] dtInts = new int[dtStrs.Length];
            for (int i = 0; i < dtInts.Length; i++)
            {
                dtInts[i] = int.Parse(dtStrs[i]);
            }
            return new DateTime(dtInts[0], dtInts[1], dtInts[2], dtInts[3], dtInts[4], dtInts[5]);
        }

        private void GetPath()
        {
            path = $"{Application.persistentDataPath}/countdowns.txt";
            // Create countdowns text file if none exists
            if (!File.Exists(path)) File.WriteAllText(path, "");
        }

        private void Start()
        {
            GetPath();
            ReadFile();
            countdownList.Initialize(countdowns.ToArray());
        }

        private void OnApplicationQuit()
        {
            WriteFile();
        }
    }
}
