using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEnvironment : CsvWriter
{
    private List<string> data = new List<string>();
    private string  columns;

    public GameObject[] ParentObj;
    private GetValue getValue;

    // Start is called before the first frame update
    void Start()
    {
        getValue = GetComponent<GetValue>();

		EveryThingWrite();
	}

    private void Write(string fileName, GameObject parent)
    {
        columns = "Name,PosX,PosY,PosZ,RotX,RotY,RotZ,ScaleX,ScaleY,ScaleZ";
        data.Add(columns);
        columns = string.Empty;

        Transform child = parent.transform;

        for (int i = 0; i < child.childCount; i++)
        {
            Transform childObj = parent.transform.GetChild(i);
            columns =  getValue.Tr(childObj);

            data.Add(columns);          
        }     
        
        string filePath = Application.dataPath + "/Resources/GameData/" + fileName;
        CsvWrite(data, filePath);
    }

	void EveryThingWrite()
	{
		for (int i = 0; i < ParentObj.Length; i++)
		{
			if (ParentObj[i].transform.name == "EnvironmentObj")
			{
				Write("EnvironmentData.csv", ParentObj[i]);
			}
			else if (ParentObj[i].transform.name == "NPC")
			{
				Write("NPC.csv", ParentObj[i]);
			}
			else if (ParentObj[i].transform.name == "Monster")
			{
				Write("Monster.csv", ParentObj[i]);
			}
		}
	}
}
