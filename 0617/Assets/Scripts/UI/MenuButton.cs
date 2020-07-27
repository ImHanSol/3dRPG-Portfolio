using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
	private Button[] button;

	private void Start()
	{
		button = gameObject.GetComponentsInChildren<Button>(); 	
	}

	public void MenuButtonEnabled()
	{
		foreach(Button btn in button)
		{
			if(btn.enabled)
			{
				btn.enabled = false;
			}
			else
			{
				btn.enabled = true;
			}
		}
	}
}
