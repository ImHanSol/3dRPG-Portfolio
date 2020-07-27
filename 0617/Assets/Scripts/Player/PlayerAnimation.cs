using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
	IDLE,
	MOVE,
	ATTACK,
    SKILL,
	DAMAGE,
	ALERT, // 공격당하거나 공격한 후 10초동안 경계동작
	DIE,
}

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAnimation : MonoBehaviour
{
	private Vector3 targetPos; // 이동 할 좌표(마우스 클릭 좌표)

	private float elapsedTime = 0f;
	private float resurrectionTimer = 20f; // 부활 타이머
	private float alertTimer = 10f; // 경계동작 타이머

    private int skillNumber;

	private State currentState;
	private Animator animator;
	private NavMeshAgent nvAgent;

	private PlayerAttack playerAttack;

	private void Start()
	{
		animator = GetComponent<Animator>();
		nvAgent = GetComponent<NavMeshAgent>();
		playerAttack = GetComponent<PlayerAttack>();

		currentState = State.IDLE;
	}

	public void ChangeState(State newState)
	{
		if (currentState == newState)
		{
			return;
		}

		currentState = newState;
	}

	private void UpdateState()
	{
		switch (currentState)
		{
			case State.IDLE:
				IdleState();
				nvAgent.isStopped = true;
				break;
			case State.MOVE:
				MoveState();
				nvAgent.isStopped = false;
				break;
			case State.ATTACK:
				AttackState();
				nvAgent.isStopped = true;
				break;
            case State.SKILL:
                SkillState();
				nvAgent.isStopped = true;
				break;
            case State.DAMAGE:
				DamageState();
				nvAgent.isStopped = true;
				break;
			case State.ALERT:
				AlertState();
				nvAgent.isStopped = true;
				break;
			case State.DIE:
				DieState();
				nvAgent.isStopped = true;
				break;
			default:
				break;
		}
	}

	void IdleState()
	{
		animator.SetBool("Idle", true);
	}

	void MoveState()
	{
		animator.SetBool("Move", true);
		nvAgent.SetDestination(targetPos);

		if(nvAgent.remainingDistance <= 0.1f && nvAgent.velocity.magnitude >= 0.1f)
		{			
			if(elapsedTime < alertTimer)
			{
				ChangeState(State.ALERT);
			animator.SetBool("Move", false);
			}
			else
			{
				ChangeState(State.IDLE);
				animator.SetBool("Move", false);
			}

		}
	}

	public void ToMove(Vector3 targetVec)
	{
		targetPos = targetVec;

		ChangeState(State.MOVE);
	}

	public void AttackState()
	{
		animator.SetTrigger("Attack");
		ChangeState(State.ALERT);
	}
    public void SkillState()
    {
        animator.SetInteger("Skill", skillNumber);
        Debug.Log(skillNumber);
    }

    public void GetSkillNum(int skillNum)
    {
        skillNumber = skillNum;
        ChangeState(State.SKILL);
    }

	public void DamageState()
	{
		animator.SetBool("Move", false);
		animator.SetTrigger("Damage");
		ChangeState(State.ALERT);
	}

	void AlertState()
	{
		animator.SetBool("Alert", true);
		elapsedTime += Time.deltaTime;

		if (elapsedTime > alertTimer)
		{
			animator.SetBool("Alert", false);
			ChangeState(State.IDLE);

			elapsedTime = 0f;
		}
	}

	void DieState()
	{
		animator.SetTrigger("Die");
		//animator.SetBool("Die", true);
		animator.SetBool("Move", false);
		animator.SetBool("Idle", false); 
		animator.SetBool("Alert", false);

		elapsedTime += Time.deltaTime;

		if (elapsedTime > resurrectionTimer)
		{
			animator.SetBool("Die", false);
			ChangeState(State.IDLE);

			elapsedTime = 0f;
		}
	}
	IEnumerator ElapsedTime()
	{
		Debug.Log(elapsedTime);
		yield return new WaitForSeconds(1f);
	}

	// Update is called once per frame
	void Update()
	{
		UpdateState();
		//StartCoroutine(ElapsedTime());
	}
}