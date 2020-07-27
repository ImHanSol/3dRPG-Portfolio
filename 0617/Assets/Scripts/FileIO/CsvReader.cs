using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CsvReader : MonoBehaviour
{
	private static CsvReader instance = null;
	public static CsvReader Instance()
	{
		if(instance == null)
		{
			instance = new CsvReader();
		}
		return instance;
	}

	public TextAsset csvFile;
	protected string[] data;
	protected string[] lineData;
	protected string text;

	private void Awake()
	{
		CsvRead();
	}

	public void CsvRead()
	{
		instance = this;

		text = csvFile.text;
		lineData = text.Split('\n');
	}
}
