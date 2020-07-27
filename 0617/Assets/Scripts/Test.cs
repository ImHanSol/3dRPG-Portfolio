using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class record : MonoBehaviour
{

    public List<string> inventory = new List<string>();
    public List<string> OnlyX = new List<string>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inventory.Add("F");


        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            inventory.Add("J");


        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            OnlyX.Add("X");


        }

        string filePath = Application.persistentDataPath + "EnvironmentData.csv";

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Inventory,OnlyX");

        for (int i = 0; i < Mathf.Max(inventory.Count, OnlyX.Count); ++i)
        {
            if (i < inventory.Count) writer.Write(inventory[i]);
            writer.Write(",");
            if (i < OnlyX.Count) writer.Write(OnlyX[i]);
            writer.Write(System.Environment.NewLine);
        }


        writer.Flush();
        writer.Close();
    }
}
