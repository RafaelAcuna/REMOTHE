using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.ScreenSpace.BarChart.Scripts;

public class UpdateStatsGraph : MonoBehaviour
{
    public BarChartManager chartManager;
    public Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        List<string> dates = new List<string>();
        List<int> values = new List<int>();
        string line;

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/REMOTHE/" + playerName.text + ".txt";
        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != null && line.Length > 0)
        {
            if (dates.Contains(line.Split('-')[0]))
            {
                int index = dates.IndexOf(line.Split('-')[0]);
                values[index] += (int)Math.Ceiling(float.Parse(line.Split('-')[1]));
            }
            else
            {
                dates.Add(line.Split('-')[0]);
                values.Add((int)Math.Ceiling(float.Parse(line.Split('-')[1])));
            }
        }
        file.Close();

        foreach(int val in values)
        {
            chartManager.AddNewBar(0, 60, (int)Math.Ceiling((float)(val/60)), true);
        }
    }
}
