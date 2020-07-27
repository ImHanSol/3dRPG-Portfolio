using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	public int damage = 10; // 공격력
	public float attackTime = 2f; // 공격주기
	private float elapsedTime = 0f; // 경과 시간

	public float distance; // 몬스터와 플레이어의 거리
	public float attackDistance = 2.0f; // 공격가능 거리
	 
	private GameObject player;
	private PlayerHealth playerHealth;
	private MonsterAnimation monsterAnimation;
    private MonsterMovement monsterMovement;

	private void Awake()
	{
		monsterAnimation = GetComponent<MonsterAnimation>();
        monsterMovement = GetComponent<MonsterMovement>();
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	private void Update()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);
		PlayerDie();
        Attack();
	}

	public void Attack()
	{
		if (player != null && !playerHealth.isDie && distance <= attackDistance)
		{	
		    elapsedTime += Time.deltaTime;

			if (elapsedTime > attackTime)
			{
				monsterAnimation.ChangeState(MonsterState.Attack);
				transform.LookAt(player.transform.position);
				playerHealth.TakeDamage(damage);
      
				elapsedTime = 0f;
			}
            monsterAnimation.ChangeState(MonsterState.Idle);
        }
	}

	private void PlayerDie()
	{
		if (playerHealth.isDie)
		{
			monsterAnimation.ToMove(monsterMovement.originalPosition);
		}
		else return;
	}
}

// list정렬 람다소트정렬
// 몬스터와의 거리 계산할 때 nIndex 구조체로 선언해주고 정렬
// list.sort((x,y) => x.nIndex.CompareTo(y.nIndex))

