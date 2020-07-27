using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvWriter : MonoBehaviour
{
	public void CsvWrite(List<string> data, string filePath)
	{
		StreamWriter streamWriter = new StreamWriter(filePath);

		for (int i = 0; i < data.Count; i++)
		{
			streamWriter.WriteLine(data[i]);
		}
		streamWriter.Close();
	}
}
