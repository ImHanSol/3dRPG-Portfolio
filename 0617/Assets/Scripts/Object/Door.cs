using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private Animator animator;
	private GameObject player;
	private float distance;
    private float openDistance = 4f;

	void Start ()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player");
	}

    private void DoorAnimation()
    {
        if(distance < openDistance)
        {
            animator.SetBool("Open", true);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            animator.SetBool("Open", false);
        }
    }

	private void Update()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);
        DoorAnimation();
	}
}



