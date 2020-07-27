using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	private GameObject inventory;

	private void Start()
	{

	}

	public void OnClickInventoryButton()
	{
		inventory.SetActive(true);
	}

	public void OnClickCloseButton()
	{
		inventory.SetActive(false);
	}
}
