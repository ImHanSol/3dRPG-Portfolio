using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : MonoBehaviour
{
	private Quest quest;
	private MenuButton menuButton;

	public Text potionText;
	public Text GoldText;

	private void Start()
	{
		quest = GetComponent<Quest>();
		menuButton = GameObject.Find("Menu").GetComponent<MenuButton>();
	}

	// 퀘스트 수락 버튼 눌렀을 때
	public void OnClickAcceptButton()
	{
		quest.questWindow.SetActive(false);
		quest.attackSlot.SetActive(true);
		menuButton.MenuButtonEnabled();
		potionText.text = "10";
		GoldText.text = "10000";
	}

	// 퀘스트 거절 버튼 눌렀을 때
	public void OnClickRejectButton()
	{
		quest.questWindow.SetActive(false);
		quest.attackSlot.SetActive(true);
		menuButton.MenuButtonEnabled();
	}

}
