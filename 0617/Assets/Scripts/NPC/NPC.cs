using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	private float questRange = 3f; // 퀘스트창을 띄우기위한 npc와 player의 거리

	private GameObject player;
	private PlayerAnimation playerAnimation;
	private Quest quest;

	private void Start()
	{
		player = GameObject.FindWithTag("Player");
		playerAnimation = player.GetComponent<PlayerAnimation>();
		quest = GetComponent<Quest>();
	}

	public void LoadQuestWindow()
	{
		var distance = Vector3.Distance(transform.position, player.transform.position);
		if(distance > questRange)
		{			
			playerAnimation.ToMove(transform.position);			
		}
		else
		{
			quest.OpenQuestWindow();
		}
	}
}
