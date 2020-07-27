using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterMovement : MonoBehaviour
{
	private float distance; // 플레이어와의 거리
	[SerializeField] private float chaseDistance = 8.0f; // 플레이어 추적거리
    [HideInInspector] public Vector3 originalPosition;

    [HideInInspector] public NavMeshAgent nvAgent;
	private MonsterAnimation monsterAnimation;
	private MonsterAttack monsterAttack;
	private GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		nvAgent = GetComponent<NavMeshAgent>();
		monsterAnimation = GetComponent<MonsterAnimation>();
		monsterAttack = GetComponent<MonsterAttack>();
		player = GameObject.FindWithTag("Player");

        originalPosition = transform.position;
	}

	// 플레이어 추적
	private void Chase()
	{
		// 추적 최대 거리보다 작을 때 플레이어 추적
		if (player != null && distance <= chaseDistance && distance >= monsterAttack.attackDistance)
		{
			monsterAnimation.ChangeState(MonsterState.Run);
			monsterAnimation.ToMove(player.transform.position); // player 따라가도록

            PlayerOutRange();
        }
	}

	// 플레이어 추적 최대거리를 벗어났을 때
	private void PlayerOutRange()
	{
		if (distance > chaseDistance)
		{
			monsterAnimation.ToMove(originalPosition);
		}
	}

	private void Update()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);

		Chase();
	}
}
