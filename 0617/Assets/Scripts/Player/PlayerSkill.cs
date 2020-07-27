using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
	private Sprite skillImg;
    private GameObject[] buttonObj;

    private char[] trim = { 'S','k','i','l'};
    private int skillNum;

    private GameObject player;
    private PlayerAnimation playerAnimation;

	private void Start()
	{
        player = GameObject.FindWithTag("Player");
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }

    private void Skill()
    {
        skillImg = this.GetComponentsInChildren<Image>()[0].sprite;
        string name = skillImg.name.Trim(trim);
        skillNum = int.Parse(name);
        Debug.Log(skillNum);
        playerAnimation.GetSkillNum(skillNum);
    }

	public void OnClickSkillButton()
	{
        Skill();
	}
}
