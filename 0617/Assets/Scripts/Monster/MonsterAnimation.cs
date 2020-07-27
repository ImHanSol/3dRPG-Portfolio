using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterState
{
	None,
	Idle,
	Patrol,
	Run,
	Attack,
	Die,
}

public class MonsterAnimation : MonoBehaviour
{
	private MonsterState currentState = MonsterState.Patrol;
	private float elapsedTime = 0f;
	// 상태 변경할 시간
	private float changeTime = 5f;

	public Vector3 targetPos;
	private float distance;

	// 패트롤 할 위치 값
	public List<Vector3> patrolPositionList = new List<Vector3>();
	// 패트롤 순서 값
	public List<int> patrolOrder = new List<int>();
	// 패트롤 인덱스 값
	public int patrolIndex;

	private Animator animator;
	private NavMeshAgent nvAgent;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponentInChildren<Animator>();
		nvAgent = GetComponent<NavMeshAgent>();

		ChangeState(MonsterState.Patrol);
        FindPatrolPosition();
		changeTime = Random.Range(5, 10);
	}

	public void ChangeState(MonsterState newState)
	{
		if (currentState == newState)
		{
			return;
		}

		currentState = newState;
	}

	public void UpdateState()
	{
		switch (currentState)
		{
			case MonsterState.Idle:
				RandomIdle();
				nvAgent.isStopped = true;
				break;
			case MonsterState.Patrol:
				PatrolState();
				animator.SetInteger("IdleChange", 2);
				nvAgent.isStopped = false;
				break;
			case MonsterState.Run:
				RunState();
                animator.SetBool("Run", true);
				nvAgent.isStopped = false;
				break;
			case MonsterState.Attack:
                animator.SetBool("Run", false);
                animator.SetTrigger("Attack");
				nvAgent.isStopped = true;
				break;
			case MonsterState.Die:
                animator.SetTrigger("Die");
				nvAgent.isStopped = true;
				break;
			default:
				break;
		}
	}

	private void RandomIdle()
	{
		elapsedTime += Time.deltaTime;
        int random = Random.Range(0, 3);
        animator.SetInteger("IdleChange", random);

        if (elapsedTime > changeTime)
		{
			random = Random.Range(0, 3);
			changeTime = Random.Range(5, 10);
			animator.SetInteger("IdleChange", random);

			elapsedTime = 0;
		}
	}

	public void RunState()
	{
		nvAgent.SetDestination(targetPos);

		if (nvAgent.remainingDistance <= 0.1f && nvAgent.velocity.magnitude >= 0.1f)
		{
			ChangeState(MonsterState.Patrol);
		}
	}

	public void ToMove(Vector3 targetVec)
	{
		targetPos = targetVec;

		ChangeState(MonsterState.Run);
	}

	// 몬스터 자식오브젝트인 PatrolPosition를 찾아 리스트에 위치 값 저장
	private void FindPatrolPosition()
	{
		Transform patrolPositionParent = transform.Find("PatrolPosition");

		if(patrolPositionParent != null)
		{
			int childCount = patrolPositionParent.childCount;
			for (int i = 0; i < childCount; i++)
			{
                patrolPositionList.Add(patrolPositionParent.GetChild(i).position);
				patrolOrder.Add(i);
			}
            // 경로 얻은 후 패트롤포지션 오브젝트 비활성화
            patrolPositionParent.gameObject.SetActive(false);
		}
	}

	private void FindWay()
	{
		int size = patrolPositionList.Count;
		patrolOrder.Clear();
		patrolIndex = 0;

		while(patrolOrder.Count < size)
		{
			int index = Random.Range(0, size);
			if(patrolOrder.Contains(index) == false)
			{
				patrolOrder.Add(index);
			}
		}
	}

	private void PatrolState()
	{
		int index = patrolOrder[patrolIndex];
		Vector3 target = patrolPositionList[index];
		float distance = Vector3.Distance(transform.position, target);
		nvAgent.SetDestination(target);

		if(distance < 0.1f)
		{
			++patrolIndex;

			if(patrolIndex >= patrolPositionList.Count)
			{
				FindWay();
				patrolIndex = 0;
			}
		}

		elapsedTime += Time.deltaTime;

		if(elapsedTime >= changeTime)
		{
			ChangeState(MonsterState.Idle);
            elapsedTime = 0f;
		}
	}

    private void DieState()
    {
        animator.SetBool("Run", false);
        animator.SetBool("PlayerDie", false);

        nvAgent.enabled = false;
        GetComponent<MonsterMovement>().enabled = false;
        GetComponent<MonsterAttack>().enabled = false;
    }

	// Update is called once per frame
	void Update()
	{
		UpdateState();
		transform.SendMessage(currentState.ToString(),
			SendMessageOptions.DontRequireReceiver);
	}
}
