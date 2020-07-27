using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// id, npc이름, 퀘스트번호(순서), 퀘스트내용, 보상

public class Quest : CsvReader
{
	// id, 한줄전체
	private Dictionary<int, string> quest = new Dictionary<int, string>();

	List<string> contentsText = new List<string>(); // 퀘스트내용text

	public GameObject attackSlot;
	public GameObject questWindow;
	[SerializeField] private Text npcName;
	[SerializeField] private Text questContents;

	private MenuButton menuButton;
	private StringReader stringReader;
	int i = 0;

	// Start is called before the first frame update
	void Start()
	{
		menuButton = GameObject.Find("Menu").GetComponent<MenuButton>();

		QuestTextReader();
	}

	public void QuestTextReader()
	{
		if (i == 0)
		{
			stringReader = new StringReader(csvFile.text);

			var leadLine = lineData[1];
			var stringLine = leadLine.Split(',');

			npcName.text = stringLine[1];
			questContents.text = stringLine[3];

			text = questContents.text;
			text += "\n임무 : " + stringLine[4];
			text += "\n보상 : " + stringLine[5];

			i++;
		}
		else
		{
			text += "정말 고마워 10000골드와 HP물약 10개야 다음에 또 와!";
		}
		

		
	}

	public void OpenQuestWindow()
	{
		questContents.text = string.Empty;

		questWindow.SetActive(true);
		attackSlot.SetActive(false);
		menuButton.MenuButtonEnabled();

		StartCoroutine(TypingAnimation());
	}

	IEnumerator TypingAnimation()
	{
		foreach (char c in text)
		{
			questContents.text += c;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
