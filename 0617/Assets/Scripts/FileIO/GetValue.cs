using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValue : MonoBehaviour
{
	public string Tr(Transform obj)
	{
		string value = GetName(obj) + "," + GetPosX(obj) + "," + GetPosY(obj) + "," + GetPosZ(obj) + ","
			+ GetRotX(obj) + "," + GetRotY(obj) + "," + GetRotZ(obj) + "," 
			+ GetScaleX(obj) + "," + GetScaleY(obj) + "," + GetScaleZ(obj);

		return value;
	}

	// csv파일에 쓸 오브젝트들 각각의 값
	#region WriteTransform

	public string GetName(Transform obj)
	{
		return obj.name;
	}

	public string GetPosX(Transform obj)
	{
		return obj.transform.position.x.ToString();
	}

	public string GetPosY(Transform obj)
	{
		return obj.transform.position.y.ToString();
	}

	public string GetPosZ(Transform obj)
	{
		return obj.transform.position.z.ToString();
	}

	public string GetRotX(Transform obj)
	{
		return obj.transform.localEulerAngles.x.ToString();
	}

	public string GetRotY(Transform obj)
	{
		return obj.transform.localEulerAngles.y.ToString();
	}

	public string GetRotZ(Transform obj)
	{
		return obj.transform.localEulerAngles.z.ToString();
	}

	public string GetScaleX(Transform obj)
	{
		return obj.transform.localScale.x.ToString();
	}

	public string GetScaleY(Transform obj)
	{
		return obj.transform.localScale.y.ToString();
	}

	public string GetScaleZ(Transform obj)
	{
		return obj.transform.localScale.z.ToString();
	}
	#endregion
}
