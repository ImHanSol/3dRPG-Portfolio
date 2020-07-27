using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadEnvironment : CsvReader
{
	public GameObject[] environments; // Instantiate할 Original Prefabs 
	private GameObject environmentPrefab; // 현재 Instantiate할 Prefab
	private GameObject emptyGameObject; // Instantiate할 오브젝트의 부모 오브젝트

	private StringReader stringReader;
	private string leadLine; // csv파일을 한 줄씩 읽어오기 위한 값
	private int lineCount; // csv파일이 몇 줄인지 받아오는 값

	[MenuItem("Load/Environment _e")]
	private static void EnvironmentMenu()
	{

	}

	private void Start()
	{
		Create();
	}

	private void Create()
	{
		environments = Resources.LoadAll<GameObject>("Prefabs/");
		emptyGameObject = new GameObject("EnvironmentObj");

		stringReader = new StringReader(csvFile.text);
		leadLine = stringReader.ReadLine();

		int i = 0;
		while (leadLine != null)
		{
			leadLine = stringReader.ReadLine();
			i++;
		}

		lineCount = i - 1;
		for (int j = 1; j <= lineCount; j++)
		{
			int index = 0;
			string name = GetName(j);

			for (int k = 0; k < environments.Length;)
			{
				if (name == environments[k].name)
				{
					index = k;
					break;
				}
				else
				{
					k++;
				}
			}

			environmentPrefab = Instantiate(environments[index].gameObject, 
				new Vector3(GetPosX(j), GetPosY(j), GetPosZ(j)), Quaternion.identity, emptyGameObject.transform) as GameObject;
			environmentPrefab.transform.eulerAngles = new Vector3(GetRotX(j), GetRotY(j), GetRotZ(j));
		}
	}

	#region GetValue

	public string GetName(int index)
	{
		data = lineData[index].Split(',');
		return data[0];
	}

	public float GetPosX(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[1]);
	}

	public float GetPosY(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[2]);
	}

	public float GetPosZ(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[3]);
	}

	public float GetRotX(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[4]);
	}

	public float GetRotY(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[5]);
	}

	public float GetRotZ(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[6]);
	}

	public float GetScaleX(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[7]);
	}

	public float GetScaleY(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[8]);
	}

	public float GetScaleZ(int index)
	{
		data = lineData[index].Split(',');
		return float.Parse(data[9]);
	}

	#endregion GetValue
}

