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

        public void RemoveCountdown(string title, DateTime dateTime)
        {
            for (int i = 0; i < countdowns.Count; i++)
            {
                if (countdowns[i].title == title && countdowns[i].dateTime == dateTime)
                {
                    countdowns.RemoveAt(i);
                    break;
                }
            }
        }

        private void WriteFile()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (CountdownObject countdown in countdowns)
            {
                writer.WriteLine(countdown.title);
                writer.WriteLine(countdown.dateTime);
            }
            writer.Close();
        }

        private void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            countdowns.Clear();
            string content = reader.ReadToEnd();
            string[] lines = content.Split('\n');
            for (int i = 0; i < lines.Length; i += 2)
            {
                // string title = lines[i];
                // string dateTime = new DateTime(lines[i + 1]);
                CountdownObject countdown = new CountdownObject();
                countdowns.Add(countdown);
            }
            reader.Close();
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
