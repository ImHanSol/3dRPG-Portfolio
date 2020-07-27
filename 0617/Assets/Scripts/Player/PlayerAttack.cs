using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[HideInInspector] public int damage = 10;
	private float attackDistance = 2f; // 기본공격 가능 거리

	private PlayerAnimation playerAnimation;
	private GameObject monster;
	private MonsterHealth monsterHealth;

	// Start is called before the first frame update
	void Start()
    {
		playerAnimation = GetComponent<PlayerAnimation>();
		monster = GameObject.FindWithTag("Monster");
		monsterHealth = monster.GetComponent<MonsterHealth>();
    }

	public void Attack()
	{
		float distance = Vector3.Distance(transform.position, monster.transform.position);
		playerAnimation.ChangeState(State.ATTACK);
        transform.LookAt(monster.transform.position);

		if(monster != null && distance < attackDistance && !monsterHealth.isMonsterDie)
		{
			monsterHealth.TakeDamage(damage);
		}
	}

	public void OnClickAttackButton()
	{
		Attack();
	}
}
